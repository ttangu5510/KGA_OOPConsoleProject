namespace KGA_OOPConsoleProject
{
    // TODO 타일 , 팔레트
    public static class Tile
    {
        //TODO Tile Print
        private enum TileType { Home, Town, NormalField, Forest, Shop, Shop2, Doctor, DungeonEnt, Dungeon }
        private static TileType tile;
        private static int tilePalette;

        //TODO 전체 맵프린트
        public static void PrintMap(string[] map, string sceneName)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Enum.TryParse(sceneName, out tile);
            switch (tile)
            {
                case TileType.Home:
                    tilePalette = 8;
                    break;
                case TileType.Town:
                    tilePalette = 8;
                    break;
                case TileType.NormalField:
                    tilePalette = 8;
                    break;
                case TileType.Forest:
                    tilePalette = 8;
                    break;
                case TileType.Shop:
                    break;
                case TileType.Shop2:
                    break;
                case TileType.Doctor:
                    break;
                case TileType.DungeonEnt:
                    tilePalette = 7;
                    break;
                case TileType.Dungeon:
                    break;
                default:
                    break;
            }
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    switch (map[y][x])
                    {

                        case ' ': // 길
                            Console.BackgroundColor = (ConsoleColor)tilePalette - 2; // 6
                            Console.ForegroundColor = (ConsoleColor)tilePalette - 2;
                            Console.Write(map[y][x]);
                            break;
                        //case '▧': // 창문
                        //    Console.BackgroundColor = (ConsoleColor)tilePalette - 4; // 4
                        //    Console.ForegroundColor = (ConsoleColor)tilePalette + 4;
                        //    Console.Write(map[y][x]);
                        //    break;
                        case '※': // 나무
                            Console.BackgroundColor = (ConsoleColor)tilePalette - 6;
                            Console.ForegroundColor = (ConsoleColor)tilePalette + 2; //10
                            Console.Write(map[y][x]);
                            break;
                        case '▦':// 벽
                            Console.BackgroundColor = (ConsoleColor)tilePalette - 1;
                            Console.ForegroundColor = (ConsoleColor)tilePalette;
                            Console.Write(map[y][x]);
                            break;
                        case '▨': // 지붕
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[y][x]);
                            break;
                        case '▤': // 상자
                            Console.BackgroundColor = (ConsoleColor)tilePalette - 2; // 8
                            Console.ForegroundColor = (ConsoleColor)tilePalette - 4;
                            Console.Write(map[y][x]);
                            break;
                        case '□': // 창문
                            Console.BackgroundColor = (ConsoleColor)tilePalette - 7;
                            Console.ForegroundColor = (ConsoleColor)tilePalette + 1;
                            Console.Write(map[y][x]);
                            break;
                        case '¤': // 장식품
                            Console.BackgroundColor = (ConsoleColor)tilePalette - 1;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(map[y][x]);
                            break;
                        case '1': // 검정
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[y][x]);
                            break;
                        case '2': // 하양
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[y][x]);
                            break;
                        case '3': // 레드
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[y][x]);
                            break;
                        case '4': // 하늘, 물
                            Console.BackgroundColor = (ConsoleColor)tilePalette + 1;
                            Console.ForegroundColor = (ConsoleColor)tilePalette + 1;
                            Console.Write(map[y][x]);
                            break;
                        default:
                            Console.Write(map[y][x]);
                            break;
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }

        // 타일 하나 프린트
        public static void TilePrint(string[] map, int x, int y, string sceneName)
        {
            Console.SetCursorPosition(x, y);
            Enum.TryParse(sceneName, out tile);
            switch (map[y][x])
            {
                case ' ': // 길
                    Console.BackgroundColor = (ConsoleColor)tilePalette - 2; // 6
                    Console.ForegroundColor = (ConsoleColor)tilePalette - 2;
                    Console.Write(map[y][x]);
                    break;
                //case '▧': // 창문
                //    Console.BackgroundColor = (ConsoleColor)tilePalette - 1; // 4
                //    Console.ForegroundColor = (ConsoleColor)tilePalette + 1;
                //    Console.Write(map[y][x]);
                //    break;
                case '▤': // 상자
                    Console.BackgroundColor = (ConsoleColor)tilePalette; // 8
                    Console.ForegroundColor = (ConsoleColor)tilePalette - 1;
                    Console.Write(map[y][x]);
                    break;
                case '※': // 나무
                    Console.BackgroundColor = (ConsoleColor)tilePalette;
                    Console.ForegroundColor = (ConsoleColor)tilePalette + 2; //10
                    Console.Write(map[y][x]);
                    break;
                case '□': // 창문
                    Console.BackgroundColor = (ConsoleColor)tilePalette - 7;
                    Console.ForegroundColor = (ConsoleColor)tilePalette + 1;
                    Console.Write(map[y][x]);
                    break;
                case '▦':// 벽
                    Console.BackgroundColor = (ConsoleColor)tilePalette - 1;
                    Console.ForegroundColor = (ConsoleColor)tilePalette;
                    Console.Write(map[y][x]);
                    break;
                case '▨': // 지붕
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(map[y][x]);
                    break;
                case '◎': // 장식품
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(map[y][x]);
                    break;
                case '■': // 하늘, 물
                    Console.BackgroundColor = (ConsoleColor)tilePalette + 1;
                    Console.ForegroundColor = (ConsoleColor)tilePalette + 1;
                    Console.Write(map[y][x]);
                    break;
                case '1': // 검정
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
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

