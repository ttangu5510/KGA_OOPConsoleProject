using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject
{
    public class Monster : GameObject
    {
        public string name;
        public int level;
        public int exp;
        public int damage;
        public int hp;
        public List<Item> mItems;
        public int gold;
        public string attack;
        public bool isRun;
        public string[] sprite;
        public int speed;
        //플레이스로 설치 할 몬스터
        public Monster(string name, int level, int exp, int damage, int hp, List<Item> mItems, int gold, char symbol, Vector2 position, string attack, string[] sprite,int speed) : base(ConsoleColor.Red, symbol, position, true, false)
        {
            this.name = name;
            this.level = level;
            this.exp = exp;
            this.damage = damage;
            this.hp = hp;
            this.mItems = mItems;
            this.gold = gold;
            this.attack = attack;
            isRun = false;
            this.sprite = sprite;
            this.speed = speed;
        }


        public int MonsterAttack()
        {
            Util.PrintText($"{attack}의 공격!");
            return damage;
        }
        public void MonsterDefence()
        {
            Util.PrintText($"{name}은/는 방어했다!");
        }
        public void MonsterRun()
        {
            Util.PrintText($"{name}은/는 도망쳤다!");
        }
        public void MonsterHit(int damage)
        {
            Util.PrintText($"{name}은/는 {damage}의 피해를 입었다!");
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
                isDead = true;
            }

        }
        public override void Interact(Player player)
        {
            Console.WriteLine("전투 시작");
        }
        public void MonsterSprite(int mX,int mY)
        {
            for(int i = 0;i<sprite.Length;i++)
            {
                Console.SetCursorPosition(mX, mY + i);
                Console.Write(sprite[i]);
            }
        }
    }
    public class MonsterFactory
    {
        public float powerRate = 1;
        public Potion potion = new Potion();

        public Monster MonsterCreate(string name, Vector2 position)
        {
            Monster monster;
            switch (name)
            {
                case "슬라임":
                    List<Item> sItems = [potion];
                    monster = new Monster("슬라임", 3, 3, 2, 15, sItems, 10, 'S', position, "튀어오르기", slimeSprite,2);
                    break;
                default:
                    Console.WriteLine("몬스터 이름이 없습니다");
                    return null;
            }
            return monster;
        }
        public string[] slimeSprite =
            { "    ___    ",
              "  /Ο Ο  \\ ",
              " (w ∇ w  ) ",
              "           "};
    }
}
