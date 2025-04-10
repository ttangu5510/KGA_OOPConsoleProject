namespace KGA_OOPConsoleProject
{
    public class Inventory
    {
        private List<Item> items;
        private int selectIndex;
        private int choiceIndex;

        // 전투에서 아이템 사용 시 행동 패턴 소모
        public bool isUse;
        public bool isBattle;
        public int maxPage;
        public int curPage;
        public int choiceCount;
        public Inventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
            choiceIndex = 0;
            isUse = false;
            isBattle = false;
            maxPage = 0;
            curPage = 0;
            choiceCount = 1;
        }
        private Stack<string> stack;

        public void Add(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == item.name && !(items[i] is Equipment))
                {
                    if (items[i].itemNum >= 99)
                    {
                        Util.PrintText("더 이상 가질 수 없다!");
                    }
                    else
                    {
                        items[i].itemNum++;
                    }
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
            Util.PrintChoice(choiceIndex);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceCount > 1)
                    {
                        choiceIndex--;
                        choiceCount--;
                        if (choiceIndex == -1)
                        {
                            choiceIndex = 9;
                            curPage--;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceCount < items.Count % 10 + 10 * maxPage)
                    {
                        choiceCount++;
                        choiceIndex++;
                        if (choiceIndex == 10)
                        {
                            choiceIndex = 0;
                            curPage++;
                        }
                    }
                    break;
                case ConsoleKey.A:
                    if (items.Count > 0)
                    {
                        selectIndex = choiceCount - 1;
                        choiceCount = 1;
                        choiceIndex = 0;
                        curPage = 0;
                        stack.Push("ItemMenu");
                    }
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    choiceCount = 1;
                    choiceIndex = 0;
                    curPage = 0;
                    break;
            }

        }
        private void ItemMenu()
        {
            Console.Clear();
            PrintAll();
            Item selectItem = items[selectIndex];
            Util.PrintChoice(selectIndex % 10);

            // 전투 인벤토리
            if (isBattle == true)
            {
                Console.SetCursorPosition(15, 0);
                Console.WriteLine("┌------------┐");
                Console.SetCursorPosition(15, 1);
                Console.WriteLine("|  사용하기  |");
                Console.SetCursorPosition(15, 2);
                Console.WriteLine("|  설명      |");
                Console.SetCursorPosition(15, 3);
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
                        if (choiceIndex < 1)
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
                            // 전투 시 행동 패턴 소모
                            isUse = true;
                            stack.Pop();
                            stack.Pop();
                        }
                        else if (choiceIndex == 1)
                        {
                            stack.Push("ItemInfo");
                            choiceIndex = 0;
                        }
                        break;
                    case ConsoleKey.S:
                        choiceIndex = 0;
                        stack.Pop();
                        break;
                }
            }

            // 비전투 인벤토리
            else
            {
                // 상점에 팔기
                if (GameManager.Player.IsShop == true)
                {
                    Console.SetCursorPosition(15, 0);
                    Console.WriteLine("┌------------┐");
                    Console.SetCursorPosition(15, 1);
                    Console.WriteLine("|  팔기      |");
                    Console.SetCursorPosition(15, 2);
                    Console.WriteLine("|  설명      |");
                    Console.SetCursorPosition(15, 3);
                    Console.WriteLine("|  취소      |");
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
                                Util.PrintText($"{selectItem.name}을 팔았습니다");
                                GameManager.Player.GetGold(selectItem.sellGold);
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
                                stack.Pop();
                                choiceIndex = 0;
                            }
                            break;
                        case ConsoleKey.S:
                            choiceIndex = 0;
                            stack.Pop();
                            break;
                    }
                }

                // 비상점
                else
                {
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
                            choiceIndex = 0;
                            stack.Pop();
                            break;
                    }
                }

            }

        }
        private void DropConfirm()
        {
            Item selectItem = items[selectIndex];
            Util.PrintText($"{selectItem.name}을/를 버리시겠습니까?");
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
                    choiceIndex = 0;
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
            // 페이지 설정
            maxPage = items.Count / 10;

            //소지금 출력
            Console.SetCursorPosition(26, 0);
            Console.WriteLine("┌----------------------┐");
            Console.SetCursorPosition(26, 1);
            Console.WriteLine("|                      |");
            Console.SetCursorPosition(26, 2);
            Console.WriteLine("└----------------------┘");
            Console.SetCursorPosition(27, 1);
            Console.WriteLine($" 소지금: {GameManager.Player.Gold}");
            Console.SetCursorPosition(0, 0);

            // 전투 출력
            if (isBattle == true)
            {
                // 전투 에서 쓸 아이템만 따로 골라오기
                List<Item> BattleItem = new List<Item>();
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].isUsable == true)
                    {
                        BattleItem.Add(items[i]);
                    }
                }

                //인벤토리 레이아웃 출력
                Console.WriteLine("┌------ 인벤토리 ------┐");
                if (items.Count == 0)
                {
                    Console.WriteLine("|  없음                |");
                }

                (int x, int y) = Console.GetCursorPosition();

                // 현재 페이지의 아이템 갯수만큼 레이아웃 출력
                if (curPage == maxPage)
                {
                    for (int i = 0; i < BattleItem.Count % 10; i++)
                    {
                        Console.WriteLine("|                      |");
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("|                      |");
                    }
                }

                Console.WriteLine("└----------------------┘");

                Console.SetCursorPosition(x + 2, y);

                // 현재 페이지의 아이템 갯수만큼  아이템 출력
                if (curPage == maxPage)
                {
                    for (int i = curPage * 10; i < BattleItem.Count % 10 + 10 * curPage; i++)
                    {

                        Console.SetCursorPosition(x + 2, y + (i - curPage * 10));
                        Console.Write("  {0}  {1}개", BattleItem[i].name, BattleItem[i].itemNum);

                    }
                }
                else
                {
                    for (int i = curPage * 10; i < 10 * (curPage + 1); i++)
                    {

                        Console.SetCursorPosition(x + 2, y + (i - curPage * 10));
                        Console.Write("  {0}  {1}개", BattleItem[i].name, BattleItem[i].itemNum);

                    }
                }
            }

            // 비전투 출력
            else
            {
                Console.WriteLine("┌------ 인벤토리 ------┐");
                if (items.Count == 0)
                {
                    Console.WriteLine("|  없음                |");
                }

                (int x, int y) = Console.GetCursorPosition();
                if (curPage == maxPage)
                {
                    for (int i = 0; i < items.Count % 10; i++)
                    {
                        Console.WriteLine("|                      |");
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("|                      |");
                    }
                }
                Console.WriteLine("└----------------------┘");
                Console.SetCursorPosition(x + 2, y);
                // 스크롤추가

                if (curPage == maxPage)
                {
                    for (int i = curPage * 10; i < items.Count % 10 + 10 * curPage; i++)
                    {

                        Console.SetCursorPosition(x + 2, y + (i - curPage * 10));
                        Console.Write("  {0}  {1}개", items[i].name, items[i].itemNum);

                    }
                }
                else
                {
                    for (int i = curPage * 10; i < 10 * (curPage + 1); i++)
                    {

                        Console.SetCursorPosition(x + 2, y + (i - curPage * 10));
                        Console.Write("  {0}  {1}개", items[i].name, items[i].itemNum);

                    }
                }
            }
        }
    }
}
