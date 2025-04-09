using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject.NPCs
{
    public class ShopNPC : NPC
    {
        private List<Item> items;
        private List<Item> sellItem;
        private int ShopNPCNum;
        private int choiceIndex;
        public ShopNPC(Vector2 position,int NPCNum) : base(position)
        {
            items = new List<Item>();
            sellItem = new List<Item>();
            choiceIndex = 0;
            BluePotion bluePotion = new BluePotion();
            RedPotion redPotion = new RedPotion();
            switch (NPCNum)
            {
                case 1:
                    items = [redPotion,bluePotion];
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

        }
        public void Sell(Player player)
        {
            player.ShopIn();
            player.ShopOut();
        }
        public void PrintItems()
        {

        }
        public override void Interact(Player player)
        {
            Util.PrintText("어서오시게! 뭔가 살텐가?");

        }
    }
}
