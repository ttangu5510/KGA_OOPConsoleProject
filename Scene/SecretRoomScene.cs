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
    public class SecretRoomScene : FieldScene
    {
        public SecretRoomScene()
        {
            name = "Secret";
            mapData = new string[]
               {
                    "┌-------------------------------------------------┐",
                    "|1111111111111111111111111111111111111111111111111|",
                    "|1111111222222211111111111111111111111111111111111|",
                    "|1111122       22111111111111111111111111111111111|",
                    "|11122   44444   221111111111111111111111111111111|",
                    "|112        ¤444   2111111111111111111111111111111|",
                    "|12  2   44444   221111111111111111111111111111111|",
                    "|2  2122       22111111111111111111111111111111111|",
                    "   21111222222211111111111111111111111111111111111|",
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
            gameObjects.Add(new Place("Dungeon", '◀', new Vector2(0, 8)));

            ////몬스터 생성
            //MonsterFactory monsterFactory = new MonsterFactory();
            //Monster slime0 = monsterFactory.MonsterCreate("슬라임", new Vector2(12, 4));
        }
        public override void SetByPrevScene()
        {
            if (GameManager.prevSceneName == "Dungeon")
            {
                GameManager.Player.position = new Vector2(1, 8);

            }
            else
            {
                GameManager.Player.position = new Vector2(1, 8);
            }
        }
    }
}
