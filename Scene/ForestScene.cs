using KGA_OOPConsoleProject.GameObjects;
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
                    "#############",
                    "#   #  ##   #",
                    "#        #  #",
                    "#   # #     #",
                    "#  # # # # ##",
                    "#############",
                };
            map = new bool[mapData.Length, mapData[0].Length];
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }
            gameObjects = new List<GameObject>();
            MonsterFactory slimeFactory = new MonsterFactory();
            Monster slime0 = slimeFactory.MonsterCreate("슬라임", new Vector2(5, 1));
            gameObjects.Add(new Place("NormalField", 'N', new Vector2(1, 4)));
            gameObjects.Add(slime0);
        }
        public override void SetByPrevScene()
        {
            if (GameManager.prevSceneName == "NormalField")
            {
                GameManager.Player.position = new Vector2(1, 3);
            }
        }

    }
}
