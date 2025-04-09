namespace KGA_OOPConsoleProject
{
    public class EquipStatus
    {
        Stack<string> stack;
        private int choiceIndex;
        private int choiceAction;
        private ConsoleKey input;
        public EquipStatus()
        {
            stack = new Stack<string>();
            choiceIndex = 0;
            choiceAction = 0;
        }
        public void OpenEquip()
        {
            stack.Push("장비 선택");
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "장비 선택":
                        EquipChoice();
                        break;
                    case "장비 행동":
                        EquipAction();
                        break;
                }
            }
        }
        public void PrintEquip()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌--- 장비 --------------------------------------┐");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("└-----------------------------------------------┘");
            Console.SetCursorPosition(3, 1);
            if (GameManager.Player.Weapon == null)
            {
                Console.Write("무기: 없음");
            }
            else
            {
                Console.Write($"무기  : {GameManager.Player.Weapon.name}");
                Console.SetCursorPosition(21, 1);
                Console.Write($"| 공격력: {GameManager.Player.Weapon.Power}");
                Console.SetCursorPosition(35, 1);
                Console.Write($"| 내구도: {GameManager.Player.Weapon.Durability}");
            }
            Console.SetCursorPosition(3, 2);
            if (GameManager.Player.Armor == null)
            {
                Console.Write("방어구: 없음");
            }
            else
            {
                Console.Write($"방어구: {GameManager.Player.Armor.name}");
                Console.SetCursorPosition(21, 2);
                Console.Write($"| 방어력: {GameManager.Player.Armor.Defence}");
                Console.SetCursorPosition(35, 2);
                Console.Write($"| 내구도: {GameManager.Player.Armor.Durability}");
            }
            Util.PrintChoice(choiceIndex);

        }
        public void EquipChoice()
        {
            PrintEquip();
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceIndex > 0)
                    {
                        choiceIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceIndex < 1)
                    {
                        choiceIndex++;
                    }
                    break;
                case ConsoleKey.A:
                    if(choiceIndex==0&&GameManager.Player.Weapon!=null)
                    {
                        stack.Push("장비 행동");
                    }
                    else if(choiceIndex==1&&GameManager.Player.Armor!=null)
                    {
                        stack.Push("장비 행동");
                    }
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    choiceIndex = 0;
                    break;

            }
        }
        public void EquipAction()
        {
            PrintEquipAction();
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceAction > 0)
                    {
                        choiceAction--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceAction < 1)
                    {
                        choiceAction++;
                    }
                    break;
                case ConsoleKey.A:
                    switch (choiceAction)
                    {
                        case 0:
                            if (choiceIndex == 0)
                            {
                                Util.PrintText("무기를 해제합니다");
                                GameManager.Player.Weapon.UnEquip();
                            }
                            else
                            {
                                Util.PrintText("방어구를 해제합니다");
                                GameManager.Player.Armor.UnEquip();
                            }
                            stack.Pop();
                            break;
                        case 1:
                            if (choiceIndex == 0)
                            {
                                Util.PrintText(GameManager.Player.Weapon.description);
                            }
                            else
                            {
                                Util.PrintText(GameManager.Player.Armor.description);
                            }
                            stack.Pop();
                            break;
                    }
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    choiceAction = 0;
                    break;
            }
        }
        public void PrintEquipAction()
        {
            Console.SetCursorPosition(15, choiceIndex);
            Console.Write("┌-------┐");
            Console.SetCursorPosition(15, choiceIndex + 1);
            Console.Write("|  해제 |");
            Console.SetCursorPosition(15, choiceIndex + 2);
            Console.Write("|  설명 |");
            Console.SetCursorPosition(15, choiceIndex + 3);
            Console.Write("└-------┘");
            Util.PrintChoice(choiceAction + choiceIndex, 16);
        }
    }
}
