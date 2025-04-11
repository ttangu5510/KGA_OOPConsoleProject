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
                    "|※※          ▥   ▥      ※▥      ※ ▥    ※■■§■■■※ ▥▥|",
                    "|※※                  ※   ▥※             ※  ※   ※▥▥|",
                    "|▥▥           ※     ※          ※     ※          ▥ |",
                    "|▥▥       ※   ※    ※   ※       ▥※             ※   |",
                    "|※§      ※          ▥   ▥                   ※     |",
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
            gameObjects.Add(new Place("DungeonEnt", '▼', new Vector2(41, 8)));
            gameObjects.Add(new FieldNPC(new Vector2(42, 2), 1));
            gameObjects.Add(new FieldNPC(new Vector2(2, 6), 2));
            gameObjects.Add(new BrownPotion(new Vector2(46, 3)));

            //몬스터 생성
            MonsterFactory monsterFactory = new MonsterFactory();
            Monster slime0 = monsterFactory.MonsterCreate("슬라임", new Vector2(24, 6));
            Monster slime1 = monsterFactory.MonsterCreate("슬라임", new Vector2(25, 7));
            Monster slime2 = monsterFactory.MonsterCreate("슬라임", new Vector2(35, 4));
            Monster goblin0 = monsterFactory.MonsterCreate("고블린", new Vector2(27, 5));
            Monster goblin1 = monsterFactory.MonsterCreate("고블린", new Vector2(28, 2));
            Monster thief0 = monsterFactory.MonsterCreate("도적", new Vector2(22, 1));
            Monster thief1 = monsterFactory.MonsterCreate("도적", new Vector2(45, 4));
            gameObjects.Add(slime0);
            gameObjects.Add(slime1);
            gameObjects.Add(slime2);
            gameObjects.Add(goblin0);
            gameObjects.Add(goblin1);
            gameObjects.Add(thief0);
            gameObjects.Add(thief1);
        }
        //protected override void PrintMap()
        //{
        //    Console.SetCursorPosition(0, 0);
        //    for (int y = 0; y < mapData.Length; y++)
        //    {
        //        for (int x = 0; x < mapData[y].Length; x++)
        //        {
        //            if (mapData[y][x] == ' ')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkYellow;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '※')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkGreen;
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '▥')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkRed;
        //                Console.ForegroundColor = ConsoleColor.DarkYellow;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '■')
        //            {
        //                Console.BackgroundColor = ConsoleColor.Blue;
        //                Console.ForegroundColor = ConsoleColor.Blue;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else
        //            {
        //                Console.Write(mapData[y][x]);
        //            }
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public override void SetByPrevScene()
        {
            if (GameManager.prevSceneName == "NormalField")
            {
                GameManager.Player.position = new Vector2(3, 2);

            }
            else if (GameManager.prevSceneName == "DungeonEnt")
            {
                GameManager.Player.position = new Vector2(41, 7);
            }
            else
            {
                GameManager.Player.position = new Vector2(3, 5);
            }
        }

    }
}
