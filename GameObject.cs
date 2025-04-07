namespace KGA_OOPConsoleProject
{
    public abstract class GameObject : IInteractable
    {
        public ConsoleColor color;
        public char symbol;
        public Vector2 position;
        public GameObject(ConsoleColor color, char symbol, Vector2 position)
        {
            this.color = color;
            this.symbol = symbol;
            this.position = position;
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
