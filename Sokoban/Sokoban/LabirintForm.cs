using System.Drawing;
using System.Windows.Forms;

namespace Sokoban
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
        private Place apple = new Place(-1, -1);

        public LabirintForm()
        {
            InitializeComponent();
            lastLevel = 1;
            game = new Game(ShowItem, ShowStat);
        }

        public void OpenLevel(int level)
        {
            if (level > lastLevel) return;

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
                    pb.MouseClick += pb_MouseClick;
                    pb.MouseDoubleClick += pb_MouseDoubleClick;
                    boxes[x, y] = pb;
                    panel.Controls.Add(pb);
                }
            }
        }

        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            Place place = (Place)(sender as PictureBox).Tag;
            string myPath = "";
            if (apple.x == -1) myPath = game.SolveMouse(place);
            else
            {
                myPath = game.SolveApple(apple, place);
                apple.x = -1;
                apple.y = -1;
            }
            path = myPath;
        }

        private void pb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            apple = (Place)(sender as PictureBox).Tag;
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
                case Cell.User: return Properties.Resources.user;
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
            if (level > 1) OpenLevel(level - 1);
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            OpenLevel(level + 1);
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
                    game.Step(-1, 0);
                    break;
                case Keys.Right:
                    game.Step(1, 0);
                    break;
                case Keys.Down:
                    game.Step(0, 1);
                    break;
                case Keys.Up:
                    game.Step(0, -1);
                    break;
                case Keys.Escape:
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
            if (string.IsNullOrEmpty(path)) return;

            switch (path[0])
            {
                case '4':
                    game.Step(-1, 0);
                    break;
                case '6':
                    game.Step(1, 0);
                    break;
                case '2':
                    game.Step(0, 1);
                    break;
                case '8':
                    game.Step(0, -1);
                    break;
            }

            path = path.Substring(1);
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
