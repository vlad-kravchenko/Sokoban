namespace Sokoban2Players
{
    public class Game
    {
        private ShowItem ShowItem;
        private ShowStat ShowStat;
        private Cell[,] map;
        private Cell[,] top;
        private int w, h;
        private Place[] mouse = new Place[3];
        private int placed, total;

        public Game(ShowItem showItem, ShowStat showStat)
        {
            ShowStat = showStat;
            ShowItem = showItem;
        }

        public bool Init(int level, out int width, out int height)
        {
            LeverFile levelFile = new LeverFile("levels.txt");
            map = levelFile.LoadLevel(level);
            if (map == null)
            {
                width = 1;
                height = 1;
                return false;
            }
            width = w = map.GetLength(0);
            height = h = map.GetLength(1);
            top = new Cell[width, height];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    switch (map[x,y])
                    {
                        case Cell.User1:
                            mouse[1] = new Place(x, y);
                            map[x, y] = Cell.None;
                            top[x, y] = Cell.User1;
                            break;
                        case Cell.User2:
                            mouse[2] = new Place(x, y);
                            map[x, y] = Cell.None;
                            top[x, y] = Cell.User2;
                            break;
                        case Cell.None:
                        case Cell.Wall:
                        case Cell.Here:
                            top[x, y] = Cell.None;
                            break;
                        case Cell.Abox:
                            map[x, y] = Cell.None;
                            top[x, y] = Cell.Abox;
                            break;
                        case Cell.Done:
                            map[x, y] = Cell.Here;
                            top[x, y] = Cell.Abox;
                            break;
                    }
                }
            }

            return true;
        }

        public void ShowLevel()
        {
            placed = total = 0;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    ShowMapTop(x, y);
                    if (map[x, y] == Cell.Here)
                    {
                        total++;
                        if (map[x, y] == Cell.Done)
                        {
                            placed++;
                        }
                    }
                }
            }

            ShowStat(placed, total);
        }

        private void ShowMapTop(int x, int y)
        {
            if (top[x, y] == Cell.None) ShowItem(new Place(x, y), map[x, y]);
            else if (top[x, y] == Cell.Abox && map[x, y] == Cell.Here) ShowItem(new Place(x, y), Cell.Done);
            else ShowItem(new Place(x, y), top[x, y]);
        }

        public void Step(int user, int sx, int sy)
        {
            if (user < 1 || user > 2) return;

            Place place = new Place(mouse[user].x + sx, mouse[user].y + sy);
            if (!InRange(place)) return;

            if (top[place.x, place.y] == Cell.None)
            {
                top[mouse[user].x, mouse[user].y] = Cell.None; ShowMapTop(mouse[user].x, mouse[user].y);
                top[place.x, place.y] = CellUser(user); ShowMapTop(place.x, place.y);
                mouse[user] = place;
            }
            if (top[place.x, place.y] == Cell.Abox)
            {
                Place after = new Place(place.x + sx, place.y + sy);
                if (!InRange(after)) return;
                if (top[after.x, after.y] != Cell.None) return;

                if (map[place.x, place.y] == Cell.Here) placed--;
                if (map[after.x, after.y] == Cell.Here) placed++;
                ShowStat(placed, total);

                top[mouse[user].x, mouse[user].y] = Cell.None; ShowMapTop(mouse[user].x, mouse[user].y);
                top[place.x, place.y] = CellUser(user); ShowMapTop(place.x, place.y);
                top[after.x, after.y] = Cell.Abox; ShowMapTop(after.x, after.y);
                mouse[user] = place;
            }
        }

        private Cell CellUser(int user)
        {
            if (user == 1) return Cell.User1;
            else return Cell.User2;
        }

        private bool InRange(Place place)
        {
            if (place.x < 0 || place.x >= w) return false;
            if (place.y < 0 || place.y >= h) return false;
            if (map[place.x, place.y] == Cell.None) return true;
            if (map[place.x, place.y] == Cell.Here) return true;
            return false;
        }
    }
}
