namespace KGA_OOPConsoleProject
{
    public static class Util
    {
        // 일반 창
        // 매개변수 초기화를 진행해, 간편하게 사용
        public static void PrintText(string text, ConsoleColor color = ConsoleColor.White, int delay = 25, int delay2 = 150)
        {
            Console.ForegroundColor = color;
            // TODO : 추후에 화면 포지션 고정작업이 되면, 위치 고정 작업
            (int x, int y) = Console.GetCursorPosition();
            int LineNum = text.Length / 10;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("┌--------------------------------┐");
            for (int i = 0; i < LineNum; i++)
            {
                Console.SetCursorPosition(x, y + i + 1);
                Console.WriteLine("|                                |");
            }
            Console.SetCursorPosition(x, y+1+LineNum);
            Console.WriteLine("|                              ▼ |");
            Console.SetCursorPosition(x, y+2+LineNum);
            Console.WriteLine("└--------------------------------┘");
            Console.SetCursorPosition(x + 2, y + 1);
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 10 == 0 && i != 0)
                {
                    Console.SetCursorPosition(x + 2, y + 1 + (i / 10));
                }
                Console.Write(text[i]);
                // TODO : 완성 시 활성화 Thread.Sleep(delay);
            }
            // TODO : 완성시 활성화 Thread.Sleep(delay2);
            Console.ResetColor();
            Console.SetCursorPosition(x, y);
            Console.ReadKey(true);
            Console.Clear();
        }

        // 대화창
        public static void PrintText(string[] text, ConsoleColor color = ConsoleColor.White, int delay = 25, int delay2 = 150)
        {
            Console.ForegroundColor = color;
            // TODO : 추후에 화면 포지션 고정작업이 되면, 위치 고정 작업
            (int x, int y) = Console.GetCursorPosition();
            foreach (string s in text)
            {
                int LineNum = s.Length/10;
                
                Console.SetCursorPosition(x, y);
                Console.WriteLine("┌--------------------------------┐");
                for (int i = 0; i < LineNum; i++)
                {
                    Console.SetCursorPosition(x, y + i + 1);
                    Console.WriteLine("|                                |");
                }
                Console.SetCursorPosition(x, y + 1 + LineNum);
                Console.WriteLine("|                              ▼ |");
                Console.SetCursorPosition(x, y + 2 + LineNum);
                Console.WriteLine("└--------------------------------┘");
                Console.SetCursorPosition(x + 2, y + 1);
                for (int i = 0; i < s.Length; i++)
                {
                    if (i % 10 == 0 && i != 0)
                    {
                        Console.SetCursorPosition(x + 2, y + 1+(i/10));
                    }
                    Console.Write(s[i]);
                   //TODO  : 완성시 해제 Thread.Sleep(delay);
                }
                Console.ReadKey(true);
                //TODO  : 완성시 해제  Thread.Sleep(delay2);
                Console.Clear();
            }
            Console.ResetColor();
            Console.SetCursorPosition(x, y);
        }
        // 입력 시 다음 진행
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Util.PrintText("계속하려면 아무키나 누르세요...");
        }

        // 선택 커서 출력
        public static void PrintChoice(int index, int x = 1)
        {
            Console.SetCursorPosition(x, index + 1);
            Console.Write("▶");
        }
    }
}
