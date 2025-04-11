namespace KGA_OOPConsoleProject.Scene
{
    public class FieldScene : BaseScene
    {
        protected ConsoleKey input;
        protected string[] mapData;
        protected bool[,] map;
        protected List<GameObject> gameObjects;
        protected Vector2 monsterPosition;
        //TODO 프린트맵 테스트
        protected event Action PrintObject;
        protected Vector2 beforePlayerMove;
        protected Vector2 afterPlayerMove;
        protected string beforeMoveScene;
        protected string afterMoveScene;

        public FieldScene() { }
        public override void Render()
        {

            if (PrintObject != null)
            {
                PrintObject.Invoke();
                PrintObject = null;


            }
            else
            {
                PrintMap();
                ObjectPrints();
                GameManager.Player.PrintPlayer();
            }
        }
        public override void Input()
        {
            input = InputHelp.InputKey();
        }


        public override void Update()
        {
            //TODO : 맵프린트 테스트
            switch (input)
            {
                // 메뉴창 들어갔다 나오니 전체출력
                case ConsoleKey.Enter:
                    PrintObject += PrintMap;
                    PrintObject += ObjectPrints;
                    PrintObject += GameManager.Player.PrintPlayer;
                    break;
                // 이동 키면 이동 했냐 안했냐에 따라서 달라짐
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    //TODO 프린트맵 테스트
                    beforePlayerMove = GameManager.Player.position;
                    break;
            }
            // 입력에 따른 플레이어의 행동
            GameManager.Player.PlayerAction(input);

            //TODO 프린트맵 테스트
            afterPlayerMove = GameManager.Player.position;
            if (beforePlayerMove != afterPlayerMove)
            {
                PrintObject += GameManager.Player.PrintPlayer;
                PrintObject += () => PrintMap(beforePlayerMove.x, beforePlayerMove.y);
            }
            else if (beforePlayerMove == afterPlayerMove)
            {
                //좌표가 같았을 때, null 처리를 위한 가짜함수
                PrintObject += FakeMethod;
            }
        }

        public override void Result()
        {
            foreach (GameObject go in gameObjects)
            {
                if (GameManager.Player.position == go.position)
                {
                    //TODO: 맵프린트 테스트
                    // 옵젝트와 상호작용을 하니 전체 프린트
                    PrintObject += PrintMap;
                    PrintObject += GameManager.Player.PrintPlayer;
                    PrintObject += ObjectPrints;
                    go.Interact(GameManager.Player);

                    if (go.isOnce == true && go.isDead == true)
                    {
                        gameObjects.Remove(go);
                    }
                    break;
                }
                else if (GameManager.Player.nextObj == go.position && input == ConsoleKey.A)
                {
                    //TODO : 맵프린트 테스트
                    //옵젝트와 상호작용 하니 대화창이든 뭐든 일단 전체 프린트가 필요한 상황
                    PrintObject += PrintMap;
                    PrintObject += GameManager.Player.PrintPlayer;
                    PrintObject += ObjectPrints;
                    go.Interact(GameManager.Player);
                    if (go.isOnce == true && go.isDead == true)
                    {
                        gameObjects.Remove(go);
                    }
                    break;
                }
            }
        }
        // 프린트 맵
        protected virtual void PrintMap() { }

        //프린트 맵(픽셀만)
        protected virtual void PrintMap(int x, int y)
        {

        }

        // 게임 오브젝트 프린트
        protected void ObjectPrints()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Print();
            }
        }

        //씬 입장시
        public override void Enter()
        {
            GameManager.Player.map = map;
            //TODO 맵프린트 테스트
            beforePlayerMove = afterPlayerMove;
            SetByPrevScene();
        }

        // TODO 트릭 : 플레이어가 벽에 계속 박을 경우 = 아무 변화도 없을 경우
        // 아무래도 변화는 없는데, 액션을 null로 하자니 모든 걸 출력해버린다. 그러므로 가짜 함수를 넣는다
        public void FakeMethod()
        {

        }

    }
}
