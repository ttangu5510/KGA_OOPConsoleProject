namespace KGA_OOPConsoleProject
{
    public class Menu
    {
        Stack<string> stack;
        public int choiceIndex;
        public Menu()
        {
            stack = new Stack<string>();
            choiceIndex = 1;
        }

        public void OpenMenu()
        {
            Console.Clear();
            stack.Push("MenuList");
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "MenuList":
                        MenuList();
                        break;
                    case "Inventory":
                        GameManager.Player.Inventory.OpenInven();
                        stack.Pop();
                        break;
                    case "StatusWindow":
                        Status.PrintStatus();
                        stack.Pop();
                        break;
                    case "OpenEquip":
                        GameManager.Player.EquipStatus.OpenEquip();
                        stack.Pop();
                        break;

                        //break;
                }
            }

        }
        public void MenuList()
        {
            Console.Clear();
            Console.WriteLine("┌----- 메 뉴 -------┬------- 키 조작법 -------------------┐");
            Console.WriteLine("├-------------------┼--------      방향키 ----------------┤");
            Console.WriteLine("|    스테이터스     |         ┌-----┐        ┌- 확 인 -┐  |");
            Console.WriteLine("|    인벤토리       |         |  ↑  |        |    A    |  |");
            Console.WriteLine("|    장비           |         └-----┘        └---------┘  |");
            Console.WriteLine("|                   |  ┌-----┐┌-----┐┌-----┐ ┌- 취 소 -┐  |");
            Console.WriteLine("|                   |  |  ←  ||  ↓  ||  →  | |    S    |  |");
            Console.WriteLine("|                   |  └-----┘└-----┘└-----┘ └---------┘  |");
            Console.WriteLine("|                   |  ┌-- 메뉴창 열기 --┐                |");
            Console.WriteLine("|                   |  |      Enter      |                |");
            Console.WriteLine("|                   |  └-----------------┘                |");
            Console.WriteLine("└-------------------┴-------------------------------------┘");
            Util.PrintChoice(choiceIndex);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.A:
                    if (choiceIndex == 1)
                    {
                        stack.Push("StatusWindow");
                    }
                    else if (choiceIndex == 2)
                    {
                        stack.Push("Inventory");
                    }
                    else if (choiceIndex == 3)
                    {
                        stack.Push("OpenEquip");
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.Enter:
                    stack.Pop();
                    break;
                case ConsoleKey.UpArrow:
                    if (choiceIndex > 1)
                    {
                        choiceIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceIndex < 3)
                    {
                        choiceIndex++;
                    }
                    break;

            }
            Console.Clear();
        }
    }
}
