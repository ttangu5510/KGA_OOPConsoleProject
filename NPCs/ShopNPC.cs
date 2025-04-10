using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject.NPCs
{
    public class ShopNPC : NPC
    {
        private List<Item> items;
        private Stack<string> stack;
        private int ShopNPCNum;
        private int choiceIndex;
        private int choiceAction;
        private ConsoleKey input;
        public ShopNPC(Vector2 position, int NPCNum) : base(position)
        {
            items = new List<Item>();
            stack = new Stack<string>();
            choiceIndex = 0;
            choiceAction = 5;

            switch (NPCNum)
            {
                case 1:
                    BluePotion bluePotion = new BluePotion();
                    RedPotion redPotion = new RedPotion();
                    ShortKnife shortKnife = new ShortKnife();
                    LetherJacket letherJacket = new LetherJacket();
                    items = [redPotion, bluePotion, shortKnife, letherJacket];
                    break;
                case 2:
                    //items = [];
                    break;
                case 3:
                    //items = [];
                    break;
            }
        }

        //상호작용
        public override void Interact(Player player)
        {
            stack.Push("상점 선택");
            Util.PrintText("어서오시게! 뭔가 살텐가?");
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "상점 선택":
                        choiceShop();
                        break;
                    case "사기":
                        Buy();
                        break;
                    case "팔기":
                        Sell(player);
                        break;
                }
            }

        }
        //상호작용 후 선택
        public void choiceShop()
        {

            Console.SetCursorPosition(35, 5);
            Console.Write("┌--------┐");
            Console.SetCursorPosition(35, 6);
            Console.Write("|  산다  |");
            Console.SetCursorPosition(35, 7);
            Console.Write("|  판다  |");
            Console.SetCursorPosition(35, 8);
            Console.Write("|  대화  |");
            Console.SetCursorPosition(35, 9);
            Console.Write("└--------┘");
            Util.PrintChoice(choiceAction, 36);
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceAction > 5)
                    {
                        choiceAction--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceAction < 7)
                    {
                        choiceAction++;
                    }
                    break;
                case ConsoleKey.A:
                    switch (choiceAction - 5)
                    {
                        case 0:
                            stack.Push("사기");
                            break;
                        case 1:
                            stack.Push("팔기");
                            break;
                        case 2:
                            ShopConversation();
                            stack.Pop();
                            break;
                    }
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    break;
            }
        }
        //아이템 사기
        public void Buy()
        {
            PrintItems();
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
                    if (choiceIndex < items.Count - 1)
                    {
                        choiceIndex++;
                    }
                    break;
                case ConsoleKey.A:
                    if (items[choiceIndex].buyGold < GameManager.Player.Gold)
                    {
                        Util.PrintText($"{items[choiceIndex].name}을 구매했다!");
                        GameManager.Player.LoseGold(items[choiceIndex].buyGold);
                        GameManager.Player.Inventory.Add(items[choiceIndex]);
                    }
                    else
                    {
                        Util.PrintText("형씨... 돈이 부족해!");
                    }
                    stack.Pop();
                    stack.Pop();
                    break;
                case ConsoleKey.S:
                    stack.Pop();
                    stack.Pop();
                    break;
            }

        }
        //아이템 팔기
        public void Sell(Player player)
        {
            stack.Pop();
            stack.Pop();
            player.ShopIn();
            player.ShopOut();
        }
        public void PrintItems()
        {
            //상인 아이템 출력
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌------ 인벤토리 ------┐");
            Console.WriteLine("|                      |");
            Console.WriteLine("|                      |");
            Console.WriteLine("|                      |");
            Console.WriteLine("└----------------------┘");
            for (int i = 0; i < items.Count; i++)
            {
                Console.SetCursorPosition(1, 1 + i);
                Console.Write(items[i]);
            }
            Util.PrintChoice(choiceIndex);
        }
        // 상인 대화
        public void ShopConversation()
        {
            Util.PrintText("슬라임들이 포션을 왜 들고 다닐까?");
        }
    }
}
