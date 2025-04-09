using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject.NPCs
{
    public class ShopNPC : NPC
    {
        private List<Item> items;
        private Stack<string> stack;
        private int ShopNPCNum;
        private int choiceIndex;
        public ShopNPC(Vector2 position, int NPCNum) : base(position)
        {
            items = new List<Item>();
            stack = new Stack<string>();
            choiceIndex = 0;
            BluePotion bluePotion = new BluePotion();
            RedPotion redPotion = new RedPotion();
            ShortKnife shortKnife = new ShortKnife();
            LetherJacket letherJacket = new LetherJacket();
            switch (NPCNum)
            {
                case 1:
                    items = [redPotion, bluePotion,shortKnife,letherJacket];
                    break;
                case 2:
                    //items = [];
                    break;
                case 3:
                    //items = [];
                    break;
            }
        }
        public void Buy()
        {
            PrintItems();
        }
        public void Sell(Player player)
        {
            player.ShopIn();
            player.ShopOut();
        }
        public void PrintItems()
        {
            //상인 아이템 출력
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌------ 인벤토리 ------┐");
            Console.WriteLine("|                      |");
            Console.WriteLine("|                      |");
            Console.WriteLine("|                      |");
            Console.WriteLine("└----------------------┘");

        }
        public override void Interact(Player player)
        {
            Util.PrintText("어서오시게! 뭔가 살텐가?");
            // TODO 상인 UI 출력
            
        }
    }
}
