namespace KGA_OOPConsoleProject
{
    public static class Util
    {
        // 매개변수 초기화를 진행해, 간편하게 사용
        public static void PrintText(string text, ConsoleColor color = ConsoleColor.White, int delay = 25, int delay2 = 150)
        {
            Console.ForegroundColor = color;
            // TODO : 추후에 포지션 고정을 찾으면 위치 고정 작업
            (int x, int y) = Console.GetCursorPosition();
            Console.WriteLine("┌--------------------------------┐");
            Console.WriteLine("|                                |");
            Console.WriteLine("|                              ▼ |");
            Console.WriteLine("└--------------------------------┘");
            (int nextX, int nextY) = Console.GetCursorPosition();
            Console.SetCursorPosition(x+1, y+1);
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 10 == 0&&i!=0)
                {
                    Console.SetCursorPosition(x + 1, y + 2);
                }
                Console.Write(text[i]);
                // TODO : 완성 시 활성화 Thread.Sleep(delay);
            }
            // TODO : 완성시 활성화 Thread.Sleep(delay2);
            Console.ResetColor();
            Console.SetCursorPosition(nextX,nextY);
        }
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Util.PrintText("계속하려면 아무키나 누르세요...");
            Console.ReadKey(true);
        }
    }
}
