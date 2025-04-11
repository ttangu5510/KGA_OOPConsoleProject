namespace KGA_OOPConsoleProject.Scene
{
    public class FieldScene : BaseScene
    {
        protected ConsoleKey input;
        protected string[] mapData;
        protected bool[,] map;
        protected List<GameObject> gameObjects;
        protected Vector2 monsterPosition;
        public FieldScene()
        {

        }
        public override void Render()
        {
            PrintMap();
            GameManager.Player.PrintPlayer();
            foreach (GameObject go in gameObjects)
            {
                go.Print();
            }
        }
        public override void Input()
        {
            input = InputHelp.InputKey();

        }


        public override void Update()
        {
            GameManager.Player.PlayerAction(input);
        }

        public override void Result()
        {
            foreach (GameObject go in gameObjects)
            {
                if (GameManager.Player.position == go.position)
                {
                    go.Interact(GameManager.Player);

                    if (go.isOnce == true && go.isDead == true)
                    {
                        gameObjects.Remove(go);
                    }
                    break;
                }
                else if (GameManager.Player.nextObj == go.position && input == ConsoleKey.A)
                {
                    go.Interact(GameManager.Player);
                    if (go.isOnce == true && go.isDead == true)
                    {
                        gameObjects.Remove(go);
                    }
                    break;
                }
            }
        }

        protected virtual void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == false)
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
