using KGA_OOPConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public class HomeScene : FieldScene
    {
        public Action PrevTown;
        public HomeScene()
        {
            name = "Home";
            mapData = new string[]
               {
            "┌-------------------------------------------------┐",
            "|▦▦□4▦▦¤▦▦▦▦▦□44□▦▦▦▦▦□4□¤□▦1111111111111111111111|",
            "|▦ 23    ※ ▦ 23      ▦    §▦1111111111111111111111|",
            "|▦         ▦ 23      ▦     ▦1111111111111111111111|",
            "|▦         ▦         ▦     ▦1111111111111111111111|",
            "|▦▦▦▦  ▦▦▦▦▦▦▦▦  ▦▦▦▦▦     ▦1111111111111111111111|",
            "|                          ▦1111111111111111111111|",
            "|                          ▦1111111111111111111111|",
            "|▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦▦ ▦▦▦▦▦1111111111111111111111|",
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
            gameObjects.Add(new Place("Town", '▼', new Vector2(22, 8)));
            gameObjects.Add(new HomeNPC(new Vector2(26, 2)));


        }
        //protected override void PrintMap()
        //{
        //    // 이전 씬이 마을이면 수행
        //    if(PrevTown!=null)
        //    {
        //        PrevTown.Invoke();
        //        PrevTown -= Console.Clear;
        //    }    

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
        //            else if (mapData[y][x] == '▥')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkGray;
        //                Console.ForegroundColor = ConsoleColor.Gray;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '▨')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkBlue;
        //                Console.ForegroundColor = ConsoleColor.Blue;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '□')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkYellow;
        //                Console.ForegroundColor = ConsoleColor.Gray;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '▧')
        //            {
        //                Console.BackgroundColor = ConsoleColor.Blue;
        //                Console.ForegroundColor = ConsoleColor.DarkBlue;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '▤')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkGray;
        //                Console.ForegroundColor = ConsoleColor.White;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '◎')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkGray;
        //                Console.ForegroundColor = ConsoleColor.Cyan;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '※')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkGray;
        //                Console.ForegroundColor = ConsoleColor.Yellow;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '■')
        //            {
        //                Console.BackgroundColor = ConsoleColor.DarkYellow;
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.Write(mapData[y][x]);
        //                Console.ResetColor();
        //            }
        //            else if (mapData[y][x] == '1')
        //            {
        //                Console.BackgroundColor = ConsoleColor.Black;
        //                Console.ForegroundColor = ConsoleColor.Black;
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
            if (GameManager.prevSceneName == "Town")
            {
                GameManager.Player.position = new Vector2(24, 7);

            }
            else
            {
                GameManager.Player.position = new Vector2(3, 3);
            }
        }
    }
}
