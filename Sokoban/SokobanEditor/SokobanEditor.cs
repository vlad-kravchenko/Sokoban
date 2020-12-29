using System;
using System.Drawing;
using System.Windows.Forms;

namespace SokobanEditor
{
    public partial class SokobanEditor : Form
    {
        #region Attributes

        private static int minHeight = 5;
        private static int maxHeight = 32;
        private static int minWidth = 5;
        private static int maxWidth = 32;

        private PictureBox [,] boxes;
        private Cell[,] cells;
        private int width, height;
        private Cell currentCell = Cell.None;

        private LeverFile level;
        private int currentLevel = 1;

        private int lastMouseX = -1;
        private int lastMouseY = -1;

        #endregion

        public SokobanEditor()
        {
            InitializeComponent();
        }

        #region Setting current cell

        private void toolWall_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.Wall);
        }

        private void toolAbox_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.Abox);
        }

        private void toolHere_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.Here);
        }

        private void toolDone_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.Done);
        }

        private void toolNone_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.None);
        }

        private void toolUser_Click(object sender, EventArgs e)
        {
            SetCurrentCell(Cell.User);
        }

        #endregion

        #region Resizing Labirint

        private void SokobanEditor_Resize(object sender, EventArgs e)
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

        private void toolResizeAddRow_Click(object sender, EventArgs e)
        {
            ResizeLevel(width, height + 1);
        }

        private void toolResizeRemoveRow_Click(object sender, EventArgs e)
        {
            ResizeLevel(width, height - 1);
        }

        private void toolResizeAddColumn_Click(object sender, EventArgs e)
        {
            ResizeLevel(width + 1, height);
        }

        private void toolResizeRemoveColumn_Click(object sender, EventArgs e)
        {
            ResizeLevel(width - 1, height);
        }

        private void ResizeLevel(int newWidth, int newHeight)
        {
            if (newWidth < minWidth || 
                newHeight < minHeight || 
                newWidth > maxWidth || 
                newHeight > maxHeight) return;

            Cell [,] newCells = new Cell[newWidth, newHeight];

            for (int x = 0; x < Math.Min(width, newWidth); x++)
            {
                for (int y = 0; y < Math.Min(height, newHeight); y++)
                {
                    newCells[x, y] = cells[x, y];
                }
            }

            width = newWidth;
            height = newHeight;

            cells = null;
            panel.Controls.Clear();

            cells = newCells;
            InitPictures();
            LoadPictures();

            toolLabirintSize.Text = width + "x" + height;
        }

        private void toolSetSize_Click(object sender, EventArgs e)
        {
            string[] dl = { "x" };
            string[] wh = toolLabirintSize.Text.Split(dl, StringSplitOptions.RemoveEmptyEntries);
            int w = int.Parse(wh[0]);
            int h = int.Parse(wh[1]);
            ResizeLevel(w, h);
        }

        private void toolLabirintSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) toolSetSize_Click(sender, null);
        }

        #endregion

        #region Load & Save events

        private void SokobanEditor_Load(object sender, EventArgs e)
        {
            level = new LeverFile("levels.txt");
            currentLevel = 1;
            LoadLevel();
        }

        public void InitPictures()
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
                        Tag = new Point(x, y)
                    };
                    pb.MouseClick += pb_MouseClick;
                    pb.MouseDoubleClick += pb_MouseDoubleClick;
                    boxes[x, y] = pb;
                    panel.Controls.Add(pb);
                }
            }
        }

        public void LoadPictures()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    boxes[x, y].Image = CellToPicture(cells[x, y]);
                }
            }
        }

        private void tooSave_Click(object sender, EventArgs e)
        {
            SaveLevel();
        }

        private void SaveLevel()
        {
            string error = IsGoodLevel();
            if (error != "")
            {
                MessageBox.Show(error);
                return;
            }

            level.SaveLevel(currentLevel, cells);
        }

        private void LoadLevel()
        {
            cells = level.LoadLevel(currentLevel);
            width = cells.GetLength(0);
            height = cells.GetLength(1);
            toolLabirintSize.Text = width + "x" + height;
            panel.Controls.Clear();
            InitPictures();
            LoadPictures();
            CalcStat();
        }

        #endregion

        #region Mouse events

        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            int x = ((Point)((sender as PictureBox).Tag)).X;
            int y = ((Point)((sender as PictureBox).Tag)).Y;

            Cell curr = Cell.None;

            if (e.Button == MouseButtons.Left)
            {
                curr = currentCell;
            }
            else if (e.Button == MouseButtons.Right)
            {
                curr = Cell.None;
            }

            if (lastMouseX == -1)
            {
                ShowCell(curr, x, y);
            }
            else
            {
                ShowRectCell(x, y, curr);
                lastMouseX = -1;
                lastMouseY = -1;
            }
        }

        private void pb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lastMouseX = ((Point)((sender as PictureBox).Tag)).X;
            lastMouseY = ((Point)((sender as PictureBox).Tag)).Y;
        }

        #endregion

        private Image CellToPicture(Cell cell)
        {
            switch (cell)
            {
                case Cell.None: return Properties.Resources.none;
                case Cell.Wall: return Properties.Resources.wall;
                case Cell.Abox: return Properties.Resources.abox;
                case Cell.Here: return Properties.Resources.here;
                case Cell.Done: return Properties.Resources.done;
                case Cell.User: return Properties.Resources.user1;
                default: return Properties.Resources.none;
            }
        }

        private void SetCurrentCell(Cell selectedCell)
        {
            currentCell = selectedCell;
            toolWall.Checked = currentCell == Cell.Wall;
            toolAbox.Checked = currentCell == Cell.Abox;
            toolDone.Checked = currentCell == Cell.Done;
            toolHere.Checked = currentCell == Cell.Here;
            toolNone.Checked = currentCell == Cell.None;
            toolUser.Checked = currentCell == Cell.User;
        }

        private void ShowRectCell(int x, int y, Cell cell)
        {
            int x1, x2, y1, y2;
            x1 = Math.Min(x, lastMouseX);
            x2 = Math.Max(x, lastMouseX);
            y1 = Math.Min(y, lastMouseY);
            y2 = Math.Max(y, lastMouseY);
            for (int xx = x1; xx <= x2; xx++)
            {
                for (int yy = y1; yy <= y2; yy++)
                {
                    ShowCell(cell, xx, yy);
                }
            }
        }
        
        private void ShowCell(Cell cell, int x, int y)
        {
            if (cell == Cell.User)
            {
                for (int xx = 0; xx < width; xx++)
                {
                    for (int yy = 0; yy < height; yy++)
                    {
                        if (cells[xx, yy] == Cell.User)
                        {
                            ShowCell(Cell.None, xx, yy);
                        }
                    }
                }
            }

            cells[x, y] = cell;
            boxes[x, y].Image = CellToPicture(cells[x, y]);

            CalcStat();
        }

        private void CalcStat()
        {
            int boxes = 0;
            int places = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (cells[x, y] == Cell.Abox) boxes++;
                    if (cells[x, y] == Cell.Here) places++;
                }
            }

            boxCount.Text = boxes.ToString();
            placeCount.Text = places.ToString();
        }

        private string IsGoodLevel()
        {
            int users = CountItems(Cell.User);
            if (users == 0) return "На карте нет игрока!";
            if (users > 1) return "На карте больше одного игрока!";

            int aboxes = CountItems(Cell.Abox);
            int heres = CountItems(Cell.Here);
            if (aboxes == 0) return "Нужно поставить хотя-бы один ящик!";
            if (aboxes != heres) return "Количество ящиков должно соответствовать количеству мест для них!";

            return "";
        }

        private void toolPrev_Click(object sender, EventArgs e)
        {
            if (currentLevel > 1)
            {
                SaveLevel();
                currentLevel--;
                LoadLevel();
            }
        }

        private void toolNext_Click(object sender, EventArgs e)
        {
            SaveLevel();
            currentLevel++;
            LoadLevel();
        }

        private int CountItems(Cell item)
        {
            int count = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (cells[x, y] == item)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
