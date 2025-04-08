namespace KGA_OOPConsoleProject
{
    public class Inventory
    {
        private List<Item> items;
        private int selectIndex;
        private int choiceIndex;
        public Inventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
            choiceIndex = 0;
        }
        private Stack<string> stack;

        public void Add(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == item.name)
                {
                    items[i].itemNum++;
                    return;
                }
            }
            items.Add(item);
        }
        public void Remove(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == item.name && items[i].itemNum != 1)
                {
                    items[i].itemNum--;
                    return;
                }
            }
            items.Remove(item);
        }
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
        public void UseAt(int index)
        {
            items[index].Use();
        }
        public void OpenInven()
        {
            stack.Push("InvenList");
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "InvenList":
                        InvenList();
                        break;
                    case "ItemMenu":
                        ItemMenu();
                        break;
                    case "DropConfirm":
                        DropConfirm();
                        break;
                    case "ItemInfo":
                        ItemInfo();
                        break;
                }
            }
            Console.Clear();
        }
        private void InvenList()
        {
            Console.Clear();
            PrintAll();
            // 초이스를 위한 화살표 생성
            // 초이스에는 인덱스 정보가 담김
            // 위아래 화살표 입력시, 초이스 인덱스 달라짐
            // 인덱스에 따라 화살표도 달라짐
            // 아이템들 인덱스 == 초이스 인덱스
            // 아이템 선택 = stack push
            // 취소 = stack pop
            Util.PrintChoice(choiceIndex);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceIndex > 0)
                    {
                        choiceIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceIndex < items.Count - 1)
                    {
                        choiceIndex++;
                    }
                    break;
                case ConsoleKey.A:
                    if (items.Count > 0)
                    {
                        selectIndex = choiceIndex;
                        choiceIndex = 0;
                        stack.Push("ItemMenu");
                    }
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    break;
            }

        }
        private void ItemMenu()
        {
            Console.Clear();
            PrintAll();
            Item selectItem = items[selectIndex];
            Util.PrintChoice(selectIndex);

            Console.SetCursorPosition(15, 0);
            Console.WriteLine("┌------------┐");
            Console.SetCursorPosition(15, 1);
            Console.WriteLine("|  사용하기  |");
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("|  설명      |");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("|  버리기    |");
            Console.SetCursorPosition(15, 4);
            Console.WriteLine("└------------┘");
            Util.PrintChoice(choiceIndex, 16);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceIndex > 0)
                    {
                        choiceIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceIndex < 2)
                    {
                        choiceIndex++;
                    }
                    break;
                case ConsoleKey.A:
                    if (choiceIndex == 0)
                    {
                        selectItem.Use();
                        Util.PrintText(selectItem.useDescription);
                        Remove(selectItem);
                        choiceIndex = 0;
                        stack.Pop();
                    }
                    else if (choiceIndex == 1)
                    {
                        stack.Push("ItemInfo");
                    }
                    else if (choiceIndex == 2)
                    {
                        stack.Push("DropConfirm");
                    }
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    break;
            }
        }
        private void DropConfirm()
        {
            Item selectItem = items[selectIndex];
            Util.PrintText($"{selectItem.name}을/를 버리시겠습니까?", ConsoleColor.White, 25, 150, false);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.A:
                    Util.PrintText($"{selectItem.name}을/를 버렸습니다");
                    Remove(selectItem);
                    stack.Pop();
                    stack.Pop();
                    choiceIndex = 0;
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    break;
            }
        }

        //아이템 정보 출력
        private void ItemInfo()
        {
            Item selectItem = items[selectIndex];
            Console.SetCursorPosition(20, selectIndex);
            Util.PrintText(selectItem.description);
            stack.Pop();
        }

        // 인벤토리 출력
        public void PrintAll()
        {
            Console.WriteLine("┌------ 인벤토리 ------┐");
            if (items.Count == 0)
            {
                Console.WriteLine("    없음 ");
            }

            (int x, int y) = Console.GetCursorPosition();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("|                      |");
            }
            Console.WriteLine("└----------------------┘");
            Console.SetCursorPosition(x + 2, y);
            for (int i = 0; i < items.Count; i++)
            {
                Console.SetCursorPosition(x + 2, y + i);
                Console.Write("  {0}  {1}개", items[i].name, items[i].itemNum);
            }
        }
    }
}
