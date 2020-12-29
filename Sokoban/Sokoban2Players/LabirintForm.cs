using System.Drawing;
using System.Windows.Forms;

namespace Sokoban2Players
{
    public delegate void ShowItem(Place place, Cell cell);
    public delegate void ShowStat(int placed, int total);

    public partial class LabirintForm : Form
    {
        private int level, lastLevel;
        private int width, height;
        private PictureBox[,] boxes;
        private Game game;
        private string path;
        private Phone phone;

        private int myUser;
        private int otherUser;

        public LabirintForm()
        {
            InitializeComponent();
            lastLevel = 1;
            game = new Game(ShowItem, ShowStat);
        }

        public LabirintForm(string port) : this()//server
        {
            phone = new PhoneServer(int.Parse(port));
            phone.Receive += Receive;
            phone.Start();
            myUser = 1;
            otherUser = 2;
        }

        public LabirintForm(string host, string port) : this()//client
        {
            phone = new PhoneClient(host, int.Parse(port));
            phone.Receive += Receive;
            phone.Start();
            myUser = 2;
            otherUser = 1;
        }

        public void OpenLevel(int level)
        {
            if (level > lastLevel || level < 1) return;

            this.level = level;
            if (!game.Init(level, out width, out height))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            InitPictures();
            game.ShowLevel();
        }

        private void InitPictures()
        {
            int bw, bh;
            bw = panel.Width / width;
            bh = panel.Height / height;

            if (bw < bh) bh = bw;
            else bw = bh;

            panel.Controls.Clear();
            boxes = new PictureBox[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    PictureBox pb = new PictureBox
                    {
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(x * (bw - 1), y * (bh - 1)),
                        Size = new Size(bw, bh),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = new Place(x, y)
                    };
                    boxes[x, y] = pb;
                    panel.Controls.Add(pb);
                }
            }
        }

        public void ShowItem(Place place, Cell cell)
        {
            boxes[place.x, place.y].Image = CellToPicture(cell);
        }

        private Image CellToPicture(Cell cell)
        {
            switch (cell)
            {
                case Cell.None: return Properties.Resources.none;
                case Cell.Wall: return Properties.Resources.wall;
                case Cell.Abox: return Properties.Resources.abox;
                case Cell.Here: return Properties.Resources.here;
                case Cell.Done: return Properties.Resources.done;
                case Cell.User1: return Properties.Resources.user;
                case Cell.User2: return Properties.Resources.user2;
                default: return Properties.Resources.none;
            }
        }

        public void ShowStat(int placed, int total)
        {
            lbBoxes.Text = placed + " из " + total;
            lbLevel.Text = level.ToString();
            lbDone.Visible = placed == total;
            if (placed == total)
            {
                if (level == lastLevel) lastLevel = level + 1;
            }
        }

        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            if (!phone.Send(3)) return;
            OpenLevel(level - 1);
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (!phone.Send(9)) return;
            OpenLevel(level + 1);
        }

        private void Receive(byte data)
        {
            switch (data)
            {
                case 4:
                    game.Step(otherUser, -1, 0);
                    break;
                case 6:
                    game.Step(otherUser, 1, 0);
                    break;
                case 2:
                    game.Step(otherUser, 0, 1);
                    break;
                case 8:
                    game.Step(otherUser, 0, -1);
                    break;
                case 0:
                    RestartLevel();
                    break;
                case 3:
                    path = "3";
                    break;
                case 9:
                    path = "9";
                    break;
            }
        }

        private void LabirintForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(path))
            {
                path = "";
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (phone.Send(4)) game.Step(myUser, -1, 0);
                    break;
                case Keys.Right:
                    if (phone.Send(6)) game.Step(myUser, 1, 0);
                    break;
                case Keys.Down:
                    if (phone.Send(2)) game.Step(myUser, 0, 1);
                    break;
                case Keys.Up:
                    if (phone.Send(8)) game.Step(myUser, 0, -1);
                    break;
                case Keys.Escape:
                    if (phone.Send(0))
                        RestartLevel();
                    break;
            }
        }

        private void LabirintForm_Resize(object sender, System.EventArgs e)
        {
            int bw, bh;
            bw = panel.Width / width;
            bh = panel.Height / height;

            if (bw < bh) bh = bw;
            else bw = bh;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    boxes[x, y].Size = new Size(bw, bh);
                    boxes[x, y].Location = new Point(x * (bw - 1), y * (bh - 1));
                }
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            if (path == "3") OpenLevel(level - 1);
            if (path == "9") OpenLevel(level + 1);

            path = "";
        }

        private void btnRestart_Click(object sender, System.EventArgs e)
        {
            RestartLevel();
        }

        private void RestartLevel()
        {
            game.Init(level, out width, out height);
            game.ShowLevel();
        }
    }
}
