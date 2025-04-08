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
            items.Add(item);
        }
        public void Remove(Item item)
        {
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
                Console.Clear();
                switch (stack.Peek())
                {
                    case "InvenList":
                        InvenList();
                        break;
                    case "UseConfirm":
                        UseConfirm();
                        break;
                    case "DropConfirm":
                        DropConfirm();
                        break;
                }
            }
            Console.Clear();
        }
        private void InvenList()
        {
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
            switch(input)
            {
                case ConsoleKey.UpArrow:
                    if(choiceIndex > 0)
                    {
                        choiceIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceIndex < items.Count-1)
                    {
                        choiceIndex++;
                    }
                    break;
                case ConsoleKey.A:
                    selectIndex = choiceIndex;
                    choiceIndex = 0;
                    stack.Push("UseConfirm");
                    break;
                case ConsoleKey.S:
                    choiceIndex = 0;
                    stack.Pop();
                    break;
            }

        }
        private void UseConfirm()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine($"{selectItem.name}을/를 사용 하시겠습니까?");
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.A:
                    selectItem.Use();
                    Util.PressAnyKey($"{selectItem.name}을/를 사용 했습니다");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    break;
            }
        }
        private void DropConfirm()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine($"{selectItem.name}을/를 버리시겠습니까?");
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.A:
                    Util.PressAnyKey($"{selectItem.name}을/를 버렸습니다");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    break;
            }
        }
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
                Console.WriteLine("  {0}", items[i].name);
            }            
        }
    }
}
