using KGA_OOPConsoleProject.GameObjects;
using KGA_OOPConsoleProject.Items;
using KGA_OOPConsoleProject.NPCs;

namespace KGA_OOPConsoleProject.Scene
{
    public class ShopScene : FieldScene
    {
        public ShopScene()
        {
            name = "Shop";
            mapData = new string[]
               {
            "┌-------------------------------------------------┐",
            "|1111111111111111 ■■■■■■■■■■■■■■■■■■■1111111111111|",
            "|1111111111111111 ■▤▤▤▤▤▤▤▤▤▤▤▤▤▤▤▤▤■1111111111111|",
            "|1111111111111111 ■        §        ■1111111111111|",
            "|1111111111111111 ■▤▤▤▤▤▤▤   ▤▤▤▤▤▤▤■1111111111111|",
            "|1111111111111111 ■                 ■1111111111111|",
            "|1111111111111111 ■   §             ■1111111111111|",
            "|1111111111111111 ■                 ■1111111111111|",
            "|1111111111111111 ■■■■■■■■■ ■■■■■■■■■1111111111111|",
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
            gameObjects.Add(new Place("Town", '▼', new Vector2(27, 8)));
            gameObjects.Add(new ShopNPC(new Vector2(27, 3),1));
            gameObjects.Add(new TownNPC(new Vector2(22, 6), 2));
            gameObjects.Add(new LetherJacket(new Vector2(25, 5)));
            gameObjects.Add(new ShortKnife(new Vector2(26, 5)));
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
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '1')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '■')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '▤')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
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
            GameManager.Player.position = new Vector2(27, 7);
        }
    }
}
