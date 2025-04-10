using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어 세팅
        public Vector2 position;
        public bool[,] map;
        private Inventory inventory;
        private int gold;
        public int Gold { get { return gold; } }
        private Menu menu;
        public Menu Menu { get { return menu; } }
        public Inventory Inventory { get { return inventory; } }
        private List<Skill> skills;
        public List<Skill> Skills { get { return skills; } }
        private EquipStatus equipStatus;
        public EquipStatus EquipStatus { get { return equipStatus; } }

        // 플레이어 스탯
        private int level;
        public int Level { get { return level; } }
        private int exp;
        public int Exp { get { return exp; } }
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
        private int maxExp;
        public int MaxExp { get { return maxExp; } }

        // 플레이어 장비
        private Armor armor;
        private Weapon weapon;
        public Armor Armor { get { return armor; } }
        public Weapon Weapon { get { return weapon; } }

        // 필드 상호작용
        public Vector2 nextObj;

        // 상태
        public bool isBattle;
        private bool isRun;
        public bool IsRun { get { return isRun; } set { isRun = value; } }
        private bool isDead;
        public bool IsDead { get { return isDead; } }
        private bool isShop;
        public bool IsShop { get { return isShop; } }

        //스프라이트
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
            equipStatus = new EquipStatus();
            skills = new List<Skill>();
            isRun = false;
            isDead = false;

            level = 1;
            exp = 0;
            maxExp = 15;
            maxHP = 60;
            curHP = maxHP;
            maxMP = 50;
            mp = maxMP;
            
            power = 3;
            defence = 0;
            speed = 5;
            gold = 0;

            nextObj.x = 0;
            nextObj.y = 0;

        }

        //체력회복
        public void HPHeal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
            {
                curHP = maxHP;
            }
        }

        //마나회복
        public void MPHeal(int amount)
        {
            mp += amount;
            if (mp > maxMP)
            {
                mp = maxMP;
            }
        }

        //골드획득
        public void GetGold(int amount)
        {
            gold += amount;
        }

        //골드잃기
        public void LoseGold(int amount)
        {
            gold -= amount;
            if (gold < 0)
            {
                gold = 0;
            }
        }

        // 장비 입기
        public void Equip(Equipment equipment)
        {
            switch (equipment.Type)
            {
                case Equipment.EquipType.Weapon:
                    if (weapon != null)
                    {
                        inventory.Add(weapon);
                    }
                    weapon = (Weapon)equipment;
                    break;
                case Equipment.EquipType.Armor:
                    if (armor != null)
                    {
                        inventory.Add(armor);
                    }
                    armor = (Armor)equipment;
                    break;
            }

        }
        // 장비 벗기
        public void UnEquip(Equipment equipment)
        {
            switch (equipment.Type)
            {
                case Equipment.EquipType.Weapon:
                    if(weapon.Durability>0)
                    {
                        inventory.Add(weapon);
                    }
                    weapon = null;
                    break;
                case Equipment.EquipType.Armor:
                    if(armor.Durability>0)
                    {
                        inventory.Add(armor);
                    }
                    armor = null;
                    break;
            }
        }
        //상점에 파는 전용 인벤토리 들어가기
        public void ShopIn()
        {
            isShop = true;
            inventory.OpenInven();
        }

        //상점 팔기 나가기
        public void ShopOut()
        {
            isShop = false;
        }

        //플레이어 아이콘 출력
        public void PrintPlayer()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('ℓ');
            Console.ResetColor();
        }

        //플레이어 입력
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

        //플레이어 이동
        public void Move(ConsoleKey input)
        {
            Vector2 tarPos = position;
            nextObj = tarPos;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    tarPos.y--;
                    nextObj.y -= 2;
                    if (nextObj.y < 1)
                    {
                        nextObj.y = 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    tarPos.y++;
                    nextObj.y += 2;
                    if (nextObj.y > 8)
                    {
                        nextObj.y = 8;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    tarPos.x--;
                    nextObj.x -= 2;
                    if (nextObj.x < 1)
                    {
                        nextObj.x = 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    tarPos.x++;
                    nextObj.x += 2;
                    if (nextObj.x > 49)
                    {
                        nextObj.x = 49;
                    }
                    break;
            }
            if (map[tarPos.y, tarPos.x] == true)
            {
                position = tarPos;
            }
            else
            {
                nextObj = tarPos;
            }
        }

        // 플레이어 공격
        public int PlayerAttack()
        {
            int totalPower;
            Util.PrintText("일반 공격!!");
            if(weapon!=null)
            {
                totalPower = power + weapon.Power;
            }
            else
            {
                totalPower = power;
            }
                return totalPower;
        }

        // 플레이어 마나사용
        public void UseMP(int amount)
        {
            mp -= amount;
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
            if (curHP <= 0)
            {
                isDead = true;
            }
        }
        // 플레이어 경험치 획득
        public void PlayerGetExp(int exp)
        {
            this.exp += exp;
            RecursionExp();
        }
        // 플레이어 경험치 처리 재귀 함수
        public void RecursionExp()
        {
            if (exp >= MaxExp)
            {
                PlayerLevelUp();
                exp -= MaxExp;
                maxExp *= 2;
                RecursionExp();
            }
        }


        // 플레이어 레벨업
        public void PlayerLevelUp()
        {
            level++;
            Util.PrintText("레벨업!!!");
            Util.PrintText("능력치가 상승했다!");

            if (level==5)
            {
                Util.PrintText("새로운 스킬을 배웠다!");
                Skills.Add(new FireBall());
            }
            else if(level == 10)
            {
                Util.PrintText("새로운 스킬을 배웠다!");
                Skills.Add(new LightningCut());
            }
            else if (level == 15)
            {
                Util.PrintText("새로운 스킬을 배웠다!");
                Skills.Add(new AtomicSlash());
            }

            Util.PrintText("풀 회복!");

            power += 10;
            defence += 20;
            speed += 10;
            maxHP += (maxHP * 80 / 100);
            maxMP += (maxMP * 80 / 100);
            MPHeal(9999);
            HPHeal(9999);
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
