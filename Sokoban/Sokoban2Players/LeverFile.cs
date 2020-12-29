using System;
using System.IO;
using System.Windows.Forms;

namespace Sokoban2Players
{
    public class LeverFile
    {
        private string filename;
        private int newLevelSize = 10;

        public LeverFile(string filename)
        {
            this.filename = filename;
        }

        public Cell [,] LoadLevel(int level)
        {
            Cell[,] cells = null;
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch
            {
                return cells;
            }

            int currentLine = 0, curLevel = 0, width = 0, height = 0;
            while (currentLine < lines.Length)
            {
                ReadLevelHeader(lines[currentLine], out curLevel, out width, out height);
                if (level == curLevel)
                {
                    cells = new Cell[width, height];
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            cells[x, y] = CharToCell(lines[currentLine + 1 + y][x]);
                        }
                    }
                    break;
                }
                else
                {
                    currentLine = currentLine + 1 + height;
                }
            }

            return cells;
        }

        public Cell CharToCell(char x)
        {
            switch (x)
            {
                case ' ': return Cell.None;
                case '#': return Cell.Wall;
                case 'O': return Cell.Abox;
                case '.': return Cell.Here;
                case 'C': return Cell.Done;
                case '1': return Cell.User1;
                case '2': return Cell.User2;
                default: return Cell.None;
            }
        }

        public char CellToChar(Cell c)
        {
            switch (c)
            {
                case Cell.None: return ' ';
                case Cell.Wall: return '#';
                case Cell.Abox: return 'O';
                case Cell.Here: return '.';
                case Cell.Done: return 'C';
                case Cell.User1: return '1';
                case Cell.User2: return '2';
                default: return ' ';
            }
        }

        private void ReadLevelHeader(string line, out int level, out int width, out int height)
        {
            var parts = line.Split();
            level = 0;
            width = 0;
            height = 0;

            if (parts.Length != 3) return;

            int.TryParse(parts[0], out level);
            int.TryParse(parts[1], out width);
            int.TryParse(parts[2], out height);
        }

        public void SaveLevel(int currentLevel, Cell[,] cells)
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch
            {
                return;
            }

            int currentLine = 0, curLevel = 0, width = 0, height = 0;
            while (currentLine < lines.Length)
            {
                ReadLevelHeader(lines[currentLine], out curLevel, out width, out height);
                if (currentLevel == curLevel)
                {
                    break;
                }
                else
                {
                    currentLine = currentLine + 1 + height;
                }
            }

            int oldLength = lines.Length;
            int delta = cells.GetLength(1) - height;
            int newLenght = oldLength - height + cells.GetLength(1);
            if (newLenght > oldLength)
            {
                Array.Resize(ref lines, newLenght);
                for (int z = newLenght - 1; z > currentLine; z--)
                {
                    try
                    {
                        lines[z] = lines[z - delta];
                    }
                    catch { }
                }
            }
            if(newLenght < oldLength)
            {
                for (int z = currentLine; z < newLenght; z++)
                {
                    lines[z] = lines[z - delta];
                }
                Array.Resize(ref lines, newLenght);
            }

            int w = cells.GetLength(0);
            int h = cells.GetLength(1);
            lines[currentLine] = currentLevel + " " + w + " " + h;
            
            for (int y = 0; y < h; y++)
            {
                lines[currentLine + 1 + y] = "";
                for (int x = 0; x < w; x++)
                {
                    lines[currentLine + 1 + y] += CellToChar(cells[x, y]);
                }
            }

            try
            {
                File.WriteAllLines(filename, lines);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
