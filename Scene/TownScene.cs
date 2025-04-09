namespace KGA_OOPConsoleProject.Scene
{
    internal class TownScene : FieldScene
    {
        public TownScene()
        {
            name = "Town";
        }
        private ConsoleKey input;
        public override void Render()
        {
            mapData = new string[]
               {
            "###################################################",
            "#                                                 #",
            "#                                                 #",
            "#                                                 #",
            "#                                                 #",
            "#                                                 #",
            "#                                                 #",
            "#                                                 #",
            "#                                                 #",
            "###################################################"
               };
            Console.Clear();
            // TODO : 게임 스크린 크기 결정 후, 픽스 작업
            Console.WriteLine("┌-------------------------------------------------┐");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("└-------------------------------------------------┘");
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Util.PrintText("필드로 나갑니다");
                    break;
            }
        }

        public override void Result()
        {
            Console.Clear();
            switch (input)
            {
                case ConsoleKey.D1:
                    GameManager.ChangeScene("NormalField");
                    break;
            }
        }

    }

}
