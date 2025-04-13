namespace KGA_OOPConsoleProject.Items
{
    public class ChateauRomani : Item
    {
        public ChateauRomani(Vector2 position) : base(ConsoleColor.Magenta, '♥', position, true)
        {
            name = "샤또 로마니";
            description = "풍부하고 진한 맛의 최상급 우유다. 체력과 MP를 풀회복한다";
            useDescription = "체력과 MP 풀 회복!";
            buyGold = 1000;
            sellGold = 500;
        }
        public ChateauRomani()
        {
            name = "샤또 로마니";
            description = "풍부하고 진한 맛의 최상급 우유다. 체력과 MP를 풀회복한다";
            useDescription = "체력과 MP 풀 회복!";
            buyGold = 1000;
            sellGold = 500;
        }
        public override void Use()
        {
            GameManager.Player.HPHeal(99999);
            GameManager.Player.MPHeal(99999);
        }
    }
}
