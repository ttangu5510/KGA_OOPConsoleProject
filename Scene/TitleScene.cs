namespace KGA_OOPConsoleProject.Scene
{
    public class TitleScene : BaseScene
    {
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
            "                      ＰＯＫＥＭＯＮＳＴＥＲ 콘솔게임에 오신 걸 환영합니다!",
            ""
            };

            foreach (string line in asciiTitle)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("아무 키나 눌러 시작하세요...");
            Console.ReadKey();
        


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

        }

    }
}
