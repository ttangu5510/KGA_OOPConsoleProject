namespace KGA_OOPConsoleProject.Scene
{
    public class FieldScene : BaseScene
    {
        private ConsoleKey input;
        private string[] mapData;
        private bool[,] map;
        public FieldScene()
        {
            mapData = new string[]
                {
                    "########",
                    "#      #",
                    "#      #",
                    "#      #",
                    "#      #",
                    "########",
                };
            map = new bool[6, 8];
            for(int y = 0;y<6;y++)
            {
                for(int x= 0;x<8;x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }

        }

        public override void Render()
        {
            PrintMap();
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }


        public override void Update()
        {
        }

        public override void Result()
        {
        }

        private void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y,x]==false)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
