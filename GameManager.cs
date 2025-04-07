using KGA_OOPConsoleProject.Scene;

namespace KGA_OOPConsoleProject
{
    public static class GameManager
    {
        private static Dictionary<string, BaseScene> sceneDic;
        private static BaseScene curScene;
        private static bool gameOver;
        public static void Run()
        {
            // 게임 초기설정
            Start();
            while (gameOver==false)
            {
                Console.Clear();
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
            Console.Title = "용사가 약하다";
            // 게임 시작 초기세팅
            Console.CursorVisible = false;
            gameOver = false;
            sceneDic = new Dictionary<string, BaseScene>();
            // 씬설정
            // 타이틀 씬 추가 : 업캐스팅
            sceneDic.Add("Title", new TitleScene());
            curScene = sceneDic["Title"];
            // 테스트 씬 추가
            sceneDic.Add("TestScene1", new TestScene1());
            sceneDic.Add("TestScene2", new TestScene2());
            sceneDic.Add("TestScene3", new TestScene3());
            sceneDic.Add("TownScene", new TownScene());
            sceneDic.Add("FieldScene", new FieldScene());
        }
        private static void End()
        {
            gameOver = false;
        }
        public static void ChangeScene(string scene)
        {
            curScene = sceneDic[scene];
        }
    }
}
