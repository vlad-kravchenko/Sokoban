using System.Collections.Generic;

namespace SokobanSolver
{
    public class MouseSolver
    {
        private List<Brain> directions;
        private char[,] map;
        private int w, h;

        struct Brain
        {
            public int x;
            public int y;
            public string path;

            public Brain(int x, int y, string path) : this()
            {
                this.x = x;
                this.y = y;
                this.path = path;
            }
        }

        public MouseSolver(char[,] map)
        {
            this.map = map;
            w = map.GetLength(0);
            h = map.GetLength(1);

            directions = new List<Brain>
            {
                new Brain(-1, 0, "4"),
                new Brain(1, 0, "6"),
                new Brain(0, 1, "2"),
                new Brain(0, -1, "8")
            };
        }

        public string MoveAlfa(Place start, Place finish)
        {
            if (start.x == finish.x && start.y == finish.y) return "";

            Queue<Brain> queue = new Queue<Brain>();//for algoritm search in wide
            List<Place> visited = new List<Place>();//list of points where we already were

            Brain brain;
            brain.x = start.x;
            brain.y = start.y;
            brain.path = "";
            Place place;

            queue.Enqueue(brain);

            while (queue.Count > 0)
            {
                brain = queue.Dequeue();
                foreach (var side in directions)
                {
                    place.x = brain.x + side.x;
                    place.y = brain.y + side.y;

                    if (InRange(place)) continue;
                    if (visited.Contains(place)) continue;

                    visited.Add(place);

                    Brain step = new Brain
                    {
                        x = place.x,
                        y = place.y,
                        path = brain.path + side.path
                    };

                    if (place.Equals(finish)) return step.path;
                    queue.Enqueue(step);
                }
            }

            return "NO";
        }

        private bool InRange(Place place)
        {
            if (place.x < 0 || place.x >= w) return true;
            if (place.y < 0 || place.y >= h) return true;
            if (map[place.x, place.y] != ' ') return true;
            return false;
        }
    }
}
