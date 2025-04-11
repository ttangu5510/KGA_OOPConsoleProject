namespace KGA_OOPConsoleProject
{
    public class Tile
    {
        private enum TileType { 집, 마을, 필드, 숲, 상점, 상점2, 의사, 던전입구, 던전1 }
        private TileType tile;
        public void TilePrint(string[] map, int x, int y, string tileType)
        {
            Enum.TryParse(tileType,out tile);
            for (int i = 0; i < map.GetLength(0);)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    switch (map[y][x])
                    {

                        case ' ':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(map[y][x]);
                            break;
                        case '▧':
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[y][x]);
                            break;
                        case '▤':
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(map[y][x]);
                            break;
                        case '※':
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[y][x]);
                            break;
                        case '1':
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(map[y][x]);
                            break;
                        default:
                            Console.Write(map[y][x]);
                            break;
                    }
                    Console.ResetColor();
                }
            }
        }
    }
}
