using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public static class Util
    {
        public static void PrintText(string[] text,ConsoleColor color = ConsoleColor.White, int delay = 25)
        {
            Console.ForegroundColor = color;
            foreach (string s in text)
            {
                for(int i = 0; i < s.Length; i++)
                {
                    Console.Write(s[i]);
                    Thread.Sleep(delay);
                }
                Thread.Sleep(300);
            }
            Console.ResetColor();
        }
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("계속하려면 아무키나 누르세요...");
            Console.ReadKey(true);
        }
    }
}
