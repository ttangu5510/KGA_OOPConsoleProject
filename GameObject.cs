namespace KGA_OOPConsoleProject
{
    public abstract class GameObject : IInteractable
    {
        public ConsoleColor color;
        public char symbol;
        public Vector2 position;
        public bool isOnce;
        public GameObject(ConsoleColor color, char symbol, Vector2 position, bool isOnce)
        {
            this.color = color;
            this.symbol = symbol;
            this.position = position;
            this.isOnce = isOnce;
        }
        public GameObject()
        {
            
        }
        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = color;
            Console.Write(symbol);
            Console.ResetColor();
        }
        public abstract void Interact(Player player);
    }
}
