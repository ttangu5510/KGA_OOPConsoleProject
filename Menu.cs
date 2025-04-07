using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    //TODO: 구현
    public static class Menu
    {
        public enum MenuState { Menu, InvenWindow, IsUse, UsConfirm, DropConfirm }        
        public static void OpenMenu()
        {
            Console.WriteLine("---- 메뉴 ---");
            Console.WriteLine("| - 인벤토리 ");
            Console.WriteLine("-------------");
        }
    }
}
