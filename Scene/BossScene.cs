using KGA_OOPConsoleProject.GameObjects;
using KGA_OOPConsoleProject.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public class BossScene : FieldScene
    {
        public BossScene()
        {
            name = "Dungeon";
            mapData = new string[]
               {
                    "┌-------------------------------------------------┐",
                    "|▒3§                                           ¤41|",
                    "|▒¤▒¤▒¤▒4 4▒▒▒▒▒▒▒▒▒4 4▒▒▒▒▒▒▒▒▒4▒▒▒▒▒▒▒▒▒▒¤ ▒  ¤1|",
                    "|▒▒▒▒▒▒▒4 ¤           ▒▒▒▒▒▒▒▒▒▒¤▒▒▒▒▒▒▒▒▒   ▒   ¤|",
                    "          4 ▒▒▒4¤4▒▒4 4▒▒▒▒▒▒        ▒▒▒▒  ¤4▒     ",
                    "|▒¤▒¤▒¤▒¤   ▒       ▒         ▒▒▒▒▒▒      4▒▒▒   ¤|",
                    "|         4▒▒ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒4 4▒▒▒▒▒▒▒▒  ¤1|",
                    "| ¤4▒▒▒▒▒▒▒             ¤4▒▒▒▒▒▒            ¤▒ ¤41|",
                    "|           ▒▒▒▒▒▒▒▒▒▒▒          ▒▒▒▒▒▒▒▒▒▒▒▒▒    ▦",
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
            gameObjects.Add(new Place("DungeonEnt", '◀', new Vector2(0, 4)));
            // 비밀방
            //gameObjects.Add(new Place("Secret", '▶', new Vector2(50, 8)));

            //몬스터 생성                                                               
            MonsterFactory monsterFactory = new MonsterFactory();
            Monster slime0 = monsterFactory.MonsterCreate("슬라임", new Vector2(13, 4));
        }
        public override void SetByPrevScene()
        {
            if (GameManager.prevSceneName == "DungeonEnt")
            {
                GameManager.Player.position = new Vector2(1, 4);

            }
            else if (GameManager.prevSceneName == "Secret")
            {
                GameManager.Player.position = new Vector2(49, 8);
            }
            else
            {
                GameManager.Player.position = new Vector2(1, 4);
            }
        }
    }
}
