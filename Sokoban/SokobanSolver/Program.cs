using System;
using System.IO;

namespace SokobanSolver
{
    class Program
    {
        private string fileLabirint = "labirint.txt";
        private char[,] map;
        private int w, h;
        private Place mouse, apple, home;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            LoadLabirint();
            MouseSolver mouseSolver = new MouseSolver(map);
            //string path = mouseSolver.MoveAlfa(mouse, home);

            AppleSolver appleSolver = new AppleSolver(map);
            string path = appleSolver.MoveApple(mouse, apple, home);  
            Console.WriteLine(path);

            Console.ReadKey();
        }

        private void LoadLabirint()
        {
            var lines = File.ReadAllLines(fileLabirint);
            var firstLine = lines[0].Split();
            w = int.Parse(firstLine[0]);
            h = int.Parse(firstLine[1]);
            
            map = new char[w, h];
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    map[x, y] = lines[y + 1][x];
                    if (map[x, y] == 'A')
                    {
                        mouse.x = x;
                        mouse.y = y;
                        map[x, y] = ' ';
                    }
                    if (map[x, y] == '.')
                    {
                        home.x = x;
                        home.y = y;
                        map[x, y] = ' ';
                    }
                    if (map[x, y] == '!')
                    {
                        apple.x = x;
                        apple.y = y;
                        //map[x, y] = ' ';
                    }
                }
            }
        }
    }
}
