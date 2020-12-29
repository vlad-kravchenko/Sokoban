using System.Collections.Generic;

namespace Sokoban
{
    public class AppleSolver
    {
        private List<Dirs> directions;
        private Cell[,] map;
        private Cell[,] top;
        private int w, h;

        struct Brain
        {
            public Place mouse;
            public Place apple;
            public string path;

            public Brain(Place mouse, Place apple, string p)
            {
                this.mouse = mouse;
                this.apple = apple;
                path = p;
            }
        }

        struct MouseApple
        {
            public Place mouse;
            public Place apple;
        }

        struct Dirs
        {
            public int x;
            public int y;
            public string path;

            public Dirs(int x, int y, string path)
            {
                this.x = x;
                this.y = y;
                this.path = path;
            }
        }

        public AppleSolver(Cell[,] map, Cell[,] top)
        {
            this.map = map;
            this.top = top;
            w = map.GetLength(0);
            h = map.GetLength(1);

            directions = new List<Dirs>
            {
                new Dirs(0, 1, "2"),
                new Dirs(-1, 0, "4"),
                new Dirs(1, 0, "6"),
                new Dirs(0, -1, "8")
            };
        }

        public string MoveApple(Place mouse, Place start, Place finish)
        {
            //mouse - where's mouse
            //start - where's box
            //finish - target place for box

            if (start.x == finish.x && start.y == finish.y) return "";

            top[start.x, start.y] = Cell.None;

            bool[,,,] visited = new bool[w, h, w, h];

            Queue<Brain> queue = new Queue<Brain>();//for algoritm search in wide
            //Dictionary<MouseApple, bool> visited = new Dictionary<MouseApple, bool>();//list of points where we already were

            Brain brain = new Brain
            {
                mouse = mouse,
                apple = start,
                path = ""
            };

            Place newMouse;
            Place newApple;
            queue.Enqueue(brain);

            while (queue.Count > 0)
            {
                brain = queue.Dequeue();
                foreach (var side in directions)
                {
                    newMouse.x = brain.mouse.x + side.x;
                    newMouse.y = brain.mouse.y + side.y;

                    if (!InRange(newMouse)) continue;

                    if (newMouse.x == brain.apple.x && newMouse.y == brain.apple.y)
                    {
                        newApple.x = newMouse.x + side.x;
                        newApple.y = newMouse.y + side.y;
                        if (!InRange(newApple)) continue;
                    }
                    else
                    {
                        newApple = brain.apple;
                    }

                    if (visited[newMouse.x, newMouse.y, newApple.x, newApple.y]) continue;
                    visited[newMouse.x, newMouse.y, newApple.x, newApple.y] = true;

                    Brain step = new Brain(newMouse, newApple, brain.path + side.path);

                    if (newApple.x == finish.x && newApple.y == finish.y)
                    {
                        top[start.x, start.y] = Cell.Abox;
                        return step.path;
                    }

                    queue.Enqueue(step);
                }
            }
            top[start.x, start.y] = Cell.Abox;
            return "NO";
        }

        private bool InRange(Place place)
        {
            if (place.x < 0 || place.x >= w) return false;
            if (place.y < 0 || place.y >= h) return false;
            if (map[place.x, place.y] == Cell.None && (top[place.x, place.y] == Cell.None || top[place.x, place.y] == Cell.User)) return true;
            if (map[place.x, place.y] == Cell.Here && (top[place.x, place.y] == Cell.None || top[place.x, place.y] == Cell.User)) return true;
            return false;
        }
    }
}
