namespace KGA_OOPConsoleProject.Items
{
    public class RedPotion : Item
    {
        public RedPotion(Vector2 position) : base(ConsoleColor.Red, '♥', position, true)
        {
            name = "빨간 포션";
            description = "소량의 체력을 회복 시키는 아이템";
            useDescription = "체력을 30 회복했다";
            buyGold = 50;
            sellGold = 25;
        }
        public RedPotion()
        {
            name = "빨간 포션";
            description = "소량의 체력을 회복 시키는 아이템";
            useDescription = "체력을 30 회복했다";
            buyGold = 50;
            sellGold = 25;
        }
        public override void Use()
        {
            GameManager.Player.HPHeal(30);
        }
    }
}
