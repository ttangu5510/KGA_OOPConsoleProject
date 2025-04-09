using KGA_OOPConsoleProject.GameObjects;

namespace KGA_OOPConsoleProject.Scene
{
    public class ShopScene : FieldScene
    {
        public TownScene()
        {
            name = "Town";
            mapData = new string[]
               {
            "┌-------------------------------------------------┐",
            "|▧▧▧▧▧▧▧▧            ▤▤▤▤SHOP▤▤▤       ▤▤DOC▤▤▧▧▧▧|",
            "|▤▤HOME▤▤            ▤▤▤▤▤ ▤▤▤▤▤  #    ▤□▤▤▤□▤▧□□▧|",
            "|▤▨□▤▤▨□▤                              ▤▤▤ ▤▤▤▧▧▧▧|",
            "|▤▤▤ ▤▤▤▤               ●●●                       |",
            "|                     ●●●●●●●          #           ",
            "|               #       ●●●                       |",
            "|▧▧▧▧▧▧▧                      #           ▧▧▧▧▧▧▧ |",
            "|▤▤▤▤▨□▤                                  ▤▤▤▤□□▤ |",
            "└-------------------------------------------------┘"
               };
            map = new bool[mapData.Length, mapData[0].Length];
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y][x] == ' ' ? true : false;
                }
            }
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("NormalField", '▶', new Vector2(49, 5)));
            gameObjects.Add(new Place("Home", '▲', new Vector2(4, 4)));
            gameObjects.Add(new TownNPC(new Vector2(16, 6), 1));
            gameObjects.Add(new TownNPC(new Vector2(34, 2), 2));
            gameObjects.Add(new TownNPC(new Vector2(30, 7), 3));
            gameObjects.Add(new TownNPC(new Vector2(39, 5), 4));
        }
        protected override void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < mapData.Length; y++)
            {
                for (int x = 0; x < mapData[y].Length; x++)
                {
                    if (mapData[y][x] == ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '▤')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '▨')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '□')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '▧')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '●')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(mapData[y][x]);
                    }
                }
                Console.WriteLine();
            }
        }
        public override void SetByPrevScene()
        {
            GameManager.Player.position = new Vector2(6, 6);
        }
    }
}
