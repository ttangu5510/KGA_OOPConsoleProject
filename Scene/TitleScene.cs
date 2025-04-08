namespace KGA_OOPConsoleProject.Scene
{
    public class TitleScene : BaseScene
    {
        public TitleScene()
        {
            name = "Title";
        }
        public override void Render()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] asciiTitle = new string[]
            {
            "██████╗  ██████╗  ██████╗ ██╗  ██╗███████╗███╗   ███╗ ██████╗ ███████╗████████╗███████╗██████╗",
            "██╔══██╗██╔═══██╗██╔════╝ ██║ ██╔╝██╔════╝████╗ ████║██╔═══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗",
            "██████╔╝██║   ██║██║  ███╗█████╔╝ █████╗  ██╔████╔██║██║   ██║█████╗     ██║   █████╗  ██████╔╝",
            "██╔═══╝ ██║   ██║██║   ██║██╔═██╗ ██╔══╝  ██║╚██╔╝██║██║   ██║██╔══╝     ██║   ██╔══╝  ██╔═══╝ ",
            "██║     ╚██████╔╝╚██████╔╝██║  ██╗███████╗██║ ╚═╝ ██║╚██████╔╝███████╗   ██║   ███████╗██║     ",
            "╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝   ╚═╝   ╚══════╝╚═╝     ",
            "",
            };

            foreach (string line in asciiTitle)
            {
                Console.WriteLine(line);
                // TODO : 게임 완성 시 해제 Thread.Sleep(100);
            }
            Console.WriteLine();
            // TODO : 게임 완성 시 해제 Thread.Sleep(300);
            //Util.PressAnyKey("게임이 시작됩니다.");
        }
        public override void Input()
        {
        }
        public override void Update()
        {

        }

        public override void Result()
        {   // TODO 테스트를 위해 생략
            //GameManager.ChangeScene("Town");
            
            // TODO 테스트를 위해 추가
            Console.Clear();
            // TODO 테스트 끝나고 삭제
            GameManager.ChangeScene("NormalField");
        }

    }
}
