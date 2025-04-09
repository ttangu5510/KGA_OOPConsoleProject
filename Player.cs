using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

            maxHP = 100;
            curHP = maxHP;
            maxMP = 15;
            mp = maxMP;
            power = 1;
            defence = 0;
            speed = 1;
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
        // 플레이어 공격
        public int PlayerAttack()
        {
            Util.PrintText("플레이어의 공격!!");
            return power;
        }
        // 플레이어 스킬 사용 TODO
        public int PlayerSkill()
        {
            Util.PrintText("플레이어의 스킬!");
            return power;
        }
        // 플레이어 가드
        public void PlayerGuard()
        {
            defence += defence;
        }
        //플레이어 가드 해제
        public void PlayerUnGuard()
        {
            defence -= defence;
        }
        // 플레이어 피격
        public void PlayerHit(int damage)
        {
            curHP -= damage;
            if (curHP <= 0)
            {
                isDead = true;
            }
        }
        // 플레이어가 도망칠 경우
        public void PlayerRun()
        {
            isRun = true;
        }
        // 체력이 다 닳을 경우
        public void PlayerDead()
        {
            if (curHP<=0)
            {
                isDead = true;
            }
        }
        // 전투 씬에서 플레이어 그리기
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
