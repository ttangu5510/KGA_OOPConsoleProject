using KGA_OOPConsoleProject.GameObjects;

namespace KGA_OOPConsoleProject.Scene
{
    public class FieldScene : BaseScene
    {
        protected ConsoleKey input;
        protected string[] mapData;
        protected bool[,] map;

        protected List<GameObject> gameObjects;
        public FieldScene()
        {
            name = "Field";
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
            for(int y = 0;y<map.GetLength(0);y++)
            {
                for(int x= 0;x<map.GetLength(1);x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("Town", 'T', new Vector2(3, 1)));
            gameObjects.Add(new Place("NormalField", 'N', new Vector2(12, 1)));

            GameManager.Player.position = new Vector2(1, 1);
            GameManager.Player.map = map;
        }

        public override void Render()
        {
            PrintMap();
            foreach (GameObject go in gameObjects)
            {
                go.Print();
            }

            GameManager.Player.PrintPlayer();
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }


        public override void Update()
        {
            GameManager.Player.Move(input);
        }

        public override void Result()
        {
            foreach (GameObject go in gameObjects)
            {
                if (GameManager.Player.position == go.position)
                {
                    go.Interact(GameManager.Player);
                }
            }
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
