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
            Console.WriteLine("장소 : 초보자의 마을");
            Console.WriteLine("활기찬 마을이다");
            Console.WriteLine();
            Console.WriteLine("어디로 가시겠습니까?");
            Console.WriteLine("1. 필드로 나간다");
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
                    GameManager.ChangeScene("Field");
                    break;
            }
        }

        public override void Result()
        {
            Console.WriteLine("필드로 나갑니다");
        }

    }
}
