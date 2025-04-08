namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어 세팅
        public Vector2 position;
        public bool[,] map;
        private Inventory inventory;
        private Menu menu;
        public Menu Menu { get { return menu; } }
        public Inventory Inventory { get { return inventory; } }

        // 플레이어 스탯
        private int power;
        public int Power { get { return power; } }
        private int defence;
        public int Defence { get { return defence; } }
        private int speed;
        public int Speed { get { return speed; } }

        private int curHP;
        private int maxHP;
        public int CurHP { get { return curHP; } }
        public int MaxHP { get { return maxHP; } }
        private int mp;
        public int MP { get { return mp; } }
        private int maxMP;
        public int MaxMP { get { return maxMP; } }

        // 상태
        public bool isBattle;
        private bool isRun;
        public bool IsRun { get { return isRun; } }
        private bool isDead;
        public bool IsDead { get { return isDead; } }
        public string[] playerSprite =
{
                     "   ____    _   ",
                     "  | ◑ ◑|  / /  "  ,
                     "  └  ^ / / /   "  ,
                     "  |\\  _|/ /_   " ,
                     "  | \\=  /      " ,
                     " /  / \\  \\     ",
                     "/__ /  \\___\\   "
            };
        public Player()
        {
            inventory = new Inventory();
            menu = new Menu();
            isRun = false;
            isDead = false;
            isBattle = false;

            maxHP = 100;
            curHP = maxHP;
            mp = 100;
            maxMP = 100;
            power = 1;
            defence = 0;
            speed = 10;
        }
        public void HPHeal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
            {
                curHP = maxHP;
            }
        }
        public void MPHeal(int amount)
        {
            mp += amount;
            if (mp > maxMP)
            {
                mp = maxMP;
            }
        }
        public void PrintPlayer()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }
        public void PlayerAction(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    Move(input);
                    break;
                case ConsoleKey.Enter:
                    menu.OpenMenu();
                    break;
            }
        }
        public void Move(ConsoleKey input)
        {
            Vector2 tarPos = position;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    tarPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                    tarPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    tarPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                    tarPos.x++;
                    break;
            }
            if (map[tarPos.y, tarPos.x] == true)
            {
                position = tarPos;
            }
        }
        public void PlayerAttack()
        {

        }
        public void PlayerSprite(int pX, int pY)
        {
            for (int i = 0; i < playerSprite.Length; i++)
            {
                Console.SetCursorPosition(pX, pY + i);
                Console.Write(playerSprite[i]);
            }
        }
    }
}
