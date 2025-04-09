using KGA_OOPConsoleProject.Scene;

namespace KGA_OOPConsoleProject
{
    public static class GameManager
    {
        private static Dictionary<string, BaseScene> sceneDic;
        private static BaseScene curScene;
        public static string prevSceneName;
        private static bool gameOver;
        public static bool GameOver {  get { return gameOver; } }

        private static Player player;
        public static Player Player { get { return player; } }

        public static void Run()
        {
            // 게임 초기설정
            Start();
            while (gameOver == false)
            {
                // 게임 화면 그리기
                curScene.Render();
                // 사용자 입력
                curScene.Input();
                // 입력에 따른 게임 상황 업데이트
                curScene.Update();
                // 업데이트 이후의 결과
                curScene.Result();
            }
            // 게임 오버
            End();
        }
        // 게임 초기 설정
        private static void Start()
        {
            // 게임 타이틀 설정
            Console.Title = "용사가 너무 약하다";
            // 게임 시작 초기세팅
            Console.CursorVisible = false;
            gameOver = false;
            sceneDic = new Dictionary<string, BaseScene>();
            // 플레이어
            player = new Player();

            // 씬설정
            // 타이틀 씬 추가 : 업캐스팅
            sceneDic.Add("Title", new TitleScene());
            curScene = sceneDic["Title"];
            
            // 씬 추가
            sceneDic.Add("Town", new TownScene());
            sceneDic.Add("Field", new FieldScene());
            sceneDic.Add("NormalField", new NormalFieldScene());
            sceneDic.Add("Forest", new ForestScene());
            sceneDic.Add("Home", new HomeScene());
        }
        // 게임 끝
        private static void End()
        {
            Console.Clear();
            Util.PrintText("게임 오버...");
        }
        // 씬 전환
        public static void ChangeScene(string scene)
        {
            curScene.Exit();
            curScene = sceneDic[scene];
            curScene.Enter();
        }
        public static void IsGameOver()
        {
            gameOver = true;            
        }
    }
}
