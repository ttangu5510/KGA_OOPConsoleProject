using KGA_OOPConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public class NormalFieldScene :FieldScene
    {
        public NormalFieldScene()
        {
            name = "NormalField";
            mapData = new string[]
               {
                    "#############",
                    "#      ##   #",
                    "#      #    #",
                    "#           #",
                    "#        ####",
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
            gameObjects.Add(new Place("Field", 'B', new Vector2(0, 1)));
            gameObjects.Add(new Place("Forest", 'F', new Vector2(12, 1)));

            GameManager.Player.position = new Vector2(1, 1);
            GameManager.Player.map = map;
        }
    }
}
