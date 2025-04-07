using KGA_OOPConsoleProject.Scene;

namespace KGA_OOPConsoleProject
{
    public class Inventory
    {
        private List<Item> items;
        private int selectIndex;
        public Inventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
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
            stack.Push("Menu");
            while (stack.Count > 0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu();
                        break;
                    case "UseMenu":
                        UseMenu();
                        break;
                    case "DropMenu":
                        DropMenu();
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
        private void Menu()
        {
            PrintAll();

            Console.WriteLine("1. 사용하기");
            Console.WriteLine("2. 버리기");
            Console.WriteLine("0. 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Push("UseMenu");
                    break;
                case ConsoleKey.D2:
                    stack.Push("DropMenu");
                    break;
                case ConsoleKey.D0:
                    stack.Pop();
                    break;
            }
        }
        private void UseMenu()
        {
            PrintAll();

            Console.WriteLine("사용할 아이템을 선택 해주세요");
            Console.WriteLine("0. 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || select >= items.Count)
                {
                    Util.PressAnyKey("범위 내의 키를 다시 입력하세요");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("UseConfirm");
                }
            } 
        }
        private void DropMenu()
        {
            PrintAll();

            Console.WriteLine("버릴 아이템을 선택 해주세요");
            Console.WriteLine("0. 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || select >= items.Count)
                {
                    Util.PressAnyKey("범위 내의 키를 다시 입력하세요");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("DropConfirm");
                }
            }
        }
        private void UseConfirm()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine($"{selectItem.name}을/를 사용 하시겠습니까?");
            ConsoleKey input = Console.ReadKey(true).Key;
            switch(input)
            {
                case ConsoleKey.Y:
                    selectItem.Use();                    
                    Util.PressAnyKey($"{selectItem.name}을/를 사용 했습니다");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
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
                case ConsoleKey.Y:
                    Util.PressAnyKey($"{selectItem.name}을/를 버렸습니다");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
            }
        }
        public void PrintAll()
        {
            Console.WriteLine("=== 소유한 아이템 ===");
            if (items.Count == 0)
            {
                Console.WriteLine(" 없음 ");
            }
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, items[i].name);
            }
            Console.WriteLine("=====================");
        }
    }
}
