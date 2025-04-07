namespace KGA_OOPConsoleProject
{
    public static class Util
    {
        // 매개변수 초기화를 진행해, 간편하게 사용
        public static void PrintText(string text, int x = 1, int y = 1, ConsoleColor color = ConsoleColor.White, int delay = 25, int delay2 = 150)
        {
            Console.ForegroundColor = color;
            (x, y) = Console.GetCursorPosition();
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
                    
                }
                Console.Write(text[i]);
                Thread.Sleep(delay);
            }
            Thread.Sleep(delay2);
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
