using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    //TODO: 구현
    // 스테이터스, 장비창, 인벤토리, 조작키 가이드
    public static class Menu
    {
        public enum MenuState { Menu, InvenWindow, IsUse, UsConfirm, DropConfirm }        
        public static void OpenMenu()
        {
            Console.WriteLine("---- 키 조작법 -----");
            Console.WriteLine("                    ┬-------- 방향키 ------");
            Console.WriteLine("                    |         ┌-----┐ ");
            Console.WriteLine("                    |         |  ↑  | ");
            Console.WriteLine("                    |         └-----┘ ");
            Console.WriteLine("                    |  ┌-----┐┌-----┐┌-----┐ ");
            Console.WriteLine("                    |  |  ←  ||  ↓  ||  →  | ");
            Console.WriteLine("                    |  └-----┘└-----┘└-----┘ ");
            Console.WriteLine("                    |  ┌- 확인, 조사 -┬- 취소, 돌아가기 ┐");
            Console.WriteLine("|                      |      A       |        S        |");    
            Console.WriteLine("| - 인벤토리           └--------------┴-----------------┘");
            Console.WriteLine("-------------          ┌-- 메뉴창 열기 --┐");
            Console.WriteLine("                       |      Enter      |");
            Console.WriteLine("                       └-----------------┘");
        }
    }
}
