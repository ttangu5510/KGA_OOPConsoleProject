using KGA_OOPConsoleProject.GameObjects;
using KGA_OOPConsoleProject.Items;
using KGA_OOPConsoleProject.NPCs;

namespace KGA_OOPConsoleProject.Scene
{
    public class DungeonEntranceScene : FieldScene
    {
        public DungeonEntranceScene()
        {
            name = "DungeonEnt";
            mapData = new string[]
               {
                    "┌- -----------------------------------------------┐",
                    "|※   ※※※  ※※※※   ※※※※   ※  ※※411414444▒4▒▒44▒▒▒444|",
                    "|※※          ▤           ▤                    4▒▒▒|",
                    "|※ ※    ※        ※   ※                  ※  ※ 4▒▒4▒|",
                    "|※                  ※                 ※          ▒|",
                    "|1        ※   ※    ※                         4▒▒4▒|",
                    "|※       ※                                 §▒4▒▒▒4|",
                    "|※  ※ ※※  ※※※※ ※※※       ※※※     ※※    114  ▒▒4▒▒▒|",
                    "|1  ※※11※※※ ▤※※ ※▤※※▤※※▤▤111         1114▒▒ ▒▒▒4▒▒|",
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
            gameObjects.Add(new Place("Forest", '▲', new Vector2(2, 0)));
            gameObjects.Add(new Place("Dungeon", '▶', new Vector2(48, 4)));
            gameObjects.Add(new Place("Shop2", '▼', new Vector2(43, 8)));
            gameObjects.Add(new FieldNPC(new Vector2(43, 6), 3));
            gameObjects.Add(new BrownPotion(new Vector2(2, 8)));
            gameObjects.Add(new Elixer(new Vector2(2, 7)));

            //몬스터 생성
            MonsterFactory monsterFactory = new MonsterFactory();
            Monster slime0 = monsterFactory.MonsterCreate("슬라임", new Vector2(13, 4));
            Monster goblin0 = monsterFactory.MonsterCreate("고블린", new Vector2(30, 3));
            Monster goblin1 = monsterFactory.MonsterCreate("고블린", new Vector2(21, 7));
            Monster goblin2 = monsterFactory.MonsterCreate("고블린", new Vector2(5, 5));
            Monster thief0 = monsterFactory.MonsterCreate("도적", new Vector2(39, 2));
            Monster thief1 = monsterFactory.MonsterCreate("도적", new Vector2(3, 8));
            Monster orc0 = monsterFactory.MonsterCreate("오크", new Vector2(45, 4));
            gameObjects.Add(slime0);
            gameObjects.Add(goblin0);
            gameObjects.Add(goblin1);
            gameObjects.Add(goblin2);
            gameObjects.Add(thief0);
            gameObjects.Add(thief1);
            gameObjects.Add(orc0);
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
            if (GameManager.prevSceneName == "Forest")
            {
                GameManager.Player.position = new Vector2(2, 1);

            }
            else if (GameManager.prevSceneName == "Shop2")
            {
                GameManager.Player.position = new Vector2(43, 7);
            }
            else
            {
                GameManager.Player.position = new Vector2(3, 5);
            }
        }
    }
}
