namespace KGA_OOPConsoleProject.Scene
{
    public class FieldScene : BaseScene
    {
        protected ConsoleKey input;
        protected string[] mapData;
        protected bool[,] map;
        protected BattleScene battleScene;
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
            input = Console.ReadKey(true).Key;
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
                    if(go.isDead==false)
                    {
                        battleScene = new BattleScene();
                        battleScene.Battle(GameManager.Player,(Monster)go);                 
                    }
                    go.Interact(GameManager.Player);
                    if (go.isOnce == true && go.isDead == true)
                    {
                        gameObjects.Remove(go);
                    }
                    break;
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
