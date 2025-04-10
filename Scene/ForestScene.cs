using KGA_OOPConsoleProject.GameObjects;
using KGA_OOPConsoleProject.Items;
using KGA_OOPConsoleProject.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public class ForestScene : FieldScene
    {
        public ForestScene()
        {
            name = "Forest";
            mapData = new string[]
               {
                    "┌-- ----------------------------------------------┐",
                    "|※※ ※※※※※※※※※※※※※※※※※   ※※※※※※※ ※※※※※■■■■■■■■■■■▥▥|",
                    "|※※          ▥   ▥      ※▥      ※ ▥    ※■■■■■■※ ▥▥|",
                    "|※※                  ※   ▥※             ※  ※   ※▥▥|",
                    "|▥▥           ※     ※          ※     ※          ▥ |",
                    "|▥▥       ※   ※    ※   ※       ▥※             ※   |",
                    "|※      ※          ▥   ▥                   ※      |",
                    "|※※※※ ※※※ ※※※※ ※※※ ※※※ ※※※※※ ※※※※※※ ※※※※※  ※※※ ※※※|",
                    "|▥※▥※※ ▥※※※ ▥※※ ※▥※※▥※※▥▥▥ ※※※※※※※ ※※▥※※▥  ▥ ※※※※※|",
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
            gameObjects.Add(new Place("NormalField", '▲', new Vector2(3, 1)));

            //몬스터 생성
            MonsterFactory slimeFactory = new MonsterFactory();
            Monster slime0 = slimeFactory.MonsterCreate("슬라임", new Vector2(12, 4));
            Monster slime1 = slimeFactory.MonsterCreate("슬라임", new Vector2(13, 6));
            Monster slime2 = slimeFactory.MonsterCreate("슬라임", new Vector2(24, 6));
            Monster slime3 = slimeFactory.MonsterCreate("슬라임", new Vector2(25, 7));
            Monster slime4 = slimeFactory.MonsterCreate("슬라임", new Vector2(35, 4));
            Monster slime5 = slimeFactory.MonsterCreate("슬라임", new Vector2(42, 2));
            Monster slime6 = slimeFactory.MonsterCreate("슬라임", new Vector2(45, 5));
            gameObjects.Add(slime0);
            gameObjects.Add(slime1);
            gameObjects.Add(slime2);
            gameObjects.Add(slime3);
            gameObjects.Add(slime4);
            gameObjects.Add(slime5);
            gameObjects.Add(slime6);
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
                    else if (mapData[y][x] == '※')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '▥')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(mapData[y][x]);
                        Console.ResetColor();
                    }
                    else if (mapData[y][x] == '■')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
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
            if (GameManager.prevSceneName == "NormalField")
            {
                GameManager.Player.position = new Vector2(2, 5);

            }
            else if (GameManager.prevSceneName == "Forest")
            {
                GameManager.Player.position = new Vector2(49, 6);
            }
            else
            {
                GameManager.Player.position = new Vector2(3, 5);
            }
        }

    }
}
