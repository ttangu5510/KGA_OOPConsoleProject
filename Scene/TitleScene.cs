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
            " █████                                              ██                                 ",
            "██   ██      █     ██             ██       █████    ██████  ██    ██                █  ",
            " █████      ███    ██   █████████ ██      ██   ██   ██     █████  ██      ███████  ██  ",
            "  █  █     ██  █   ██         ██  ██       █████    ████     ██   ██     ██        ██  ",
            "███████   ██   ██  ████      ██   ████              ██     █   █  ████   ██        ████",
            " █████  ██     ██  ██       ██    ██       ████████         ███   ██    ██         ██  ",
            "██   ██         ██ ██      ██     ██               ██             ██   █████████   ██  ",
            " █████             ██             ██              ██              ██              ██   ",
            "",
            };

            foreach (string line in asciiTitle)
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Thread.Sleep(300);
            Console.SetCursorPosition(10, 9);
            Console.Write("┌---------------------------┐");
            Console.SetCursorPosition(10, 10);
            Console.Write("|  아무키나 눌러주세요...   |");
            Console.SetCursorPosition(10, 11);
            Console.Write("└---------------------------┘");

            Console.ReadKey();
        }
        public override void Input()
        {
        }
        public override void Update()
        {

        }

        public override void Result()
        {
            Console.Clear();
            Console.WriteLine("┌------- 키 조작법 -------------------┐");
            Console.WriteLine("├--------      방향키 ----------------┤");
            Console.WriteLine("|         ┌-----┐        ┌- 확 인 -┐  |");
            Console.WriteLine("|         |  ↑  |        |    A    |  |");
            Console.WriteLine("|         └-----┘        └---------┘  |");
            Console.WriteLine("|  ┌-----┐┌-----┐┌-----┐ ┌- 취 소 -┐  |");
            Console.WriteLine("|  |  ←  ||  ↓  ||  →  | |    S    |  |");
            Console.WriteLine("|  └-----┘└-----┘└-----┘ └---------┘  |");
            Console.WriteLine("|  ┌-- 메뉴창 열기 --┐                |");
            Console.WriteLine("|  |      Enter      |                |");
            Console.WriteLine("|  └-----------------┘                |");
            Console.WriteLine("└-------------------------------------┘");
            Console.ReadKey();
            Console.Clear();
            GameManager.ChangeScene("Secret");

        }

    }
}
