using KGA_OOPConsoleProject.GameObjects;
using KGA_OOPConsoleProject.Items;

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

        }
        public override void Render()
        {
            PrintMap();
            foreach (GameObject go in gameObjects)
            {
                go.Print();
            }

            GameManager.Player.PrintPlayer();
            Console.SetCursorPosition(0, map.GetLength(0) + 2);
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
        public override void Enter()
        {
            GameManager.Player.map = map;
            SetByPrevScene();
        }
    }
}
