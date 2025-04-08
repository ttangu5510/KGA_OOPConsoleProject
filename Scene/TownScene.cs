namespace KGA_OOPConsoleProject.Scene
{
    internal class TownScene : BaseScene
    {
        public TownScene()
        {
            name = "Town";
        }
        private ConsoleKey input;
        public override void Render()
        {
            string[] text = { "활기찬 마을이다", "어디로 갈까?" };
            Console.Clear();
            Util.PrintText("장소 :      초보자의 마을");
            Util.PrintText(text);
            Console.WriteLine("┌---------------------┐");
            Console.WriteLine("| 1. 마을을 나갑니다  |");
            Console.WriteLine("|                     |");
            Console.WriteLine("└---------------------┘");
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
