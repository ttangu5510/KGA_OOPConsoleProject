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
            Console.WriteLine("아무 키나 눌러 시작하세요...");
        }
        public override void Input()
        {
            Console.ReadKey(true);
        }
        public override void Update()
        {

        }

        public override void Result()
        {
            GameManager.ChangeScene("Town");
        }

    }
}
