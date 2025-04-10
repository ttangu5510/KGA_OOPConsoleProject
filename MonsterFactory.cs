using KGA_OOPConsoleProject.Items;
using KGA_OOPConsoleProject.Scene;

namespace KGA_OOPConsoleProject
{
    public class Monster : GameObject
    {
        public string name;
        public int level;
        public int exp;
        public int damage;
        public int maxHP;
        public List<Item> mItems;
        public int gold;
        public string attack;
        public string[] sprite;
        public int speed;
        public int defence;
        public int curHP;
        protected BattleScene battleScene;

        // 특정 위치로 설치 할 몬스터
        public Monster(string name, int level, int exp, int damage, int maxHP, List<Item> mItems, int gold, char symbol, Vector2 position, string attack, string[] sprite,int speed,int defence) : base(ConsoleColor.Red, symbol, position, true, false)
        {
            this.name = name;
            this.level = level;
            this.exp = exp;
            this.damage = damage;
            this.maxHP = maxHP;
            curHP = maxHP;
            this.mItems = mItems;
            this.gold = gold;
            this.attack = attack;
            this.sprite = sprite;
            this.speed = speed;
            this.defence = defence;
        }

        // 몬스터 공격
        public int MonsterAttack()
        {
            Console.SetCursorPosition(0,7);
            Util.PrintText($"{name}의 공격!", ConsoleColor.White, 25, 150,true,false);
            Util.PrintText($"{attack} 공격!!!");
            return damage;
        }

        // 몬스터 가드
        public void MonsterGuard()
        {
           defence += defence;
        }

        // 몬스터 피격
        public void MonsterHit(int damage)
        {
            Util.PrintText($"{name}은/는 {damage}의 피해를 입었다!", ConsoleColor.White, 25, 150, true,false);
            curHP -= damage;
            if (curHP < 0)
            {
                curHP = 0;
                Util.PrintText($"{name}은/는 쓰러졌다!");
                isDead = true;
            }

        }

        // 몬스터 가드풀기(몬스터 행동패턴시)
        public void MonsterUnGuard()
        {
            defence -= defence;
        }

        // 몬스터 상호작용 = 배틀씬 진입
        public override void Interact(Player player)
        {
            battleScene = new BattleScene(player, this);
            battleScene.Battle();
        }

        // 몬스터 스프라이트 그리기
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
        // 강한 정도, 아이템 선언
        public float powerRate = 1;
        public RedPotion redPotion = new RedPotion();
        public BluePotion bluePotion = new BluePotion();
        // 몬스터 팩토리 생산라인
        public Monster MonsterCreate(string name, Vector2 position)
        {
            Monster monster;
            switch (name)
            {
                case "슬라임":
                    List<Item> sItems = [redPotion];
                    monster = new Monster("슬라임", 3, 3, 3, 15, sItems, 10, '●', position, "튀어오르기", slimeSprite,2,1);
                    break;
                case "고블린":
                    List<Item> gItems = [bluePotion];
                    monster = new Monster("고블린", 5, 10, 10, 30, gItems, 30, '￥', position, "몽둥이 휘두르기", goblinSprite, 10, 10);
                    break;
                default:
                    Console.WriteLine("몬스터 이름이 없습니다");
                    return null;
            }
            return monster;
        }

        //슬라임 스프라이트
        public string[] slimeSprite =
            { "    ___    ",
              "  /Ο Ο  \\ ",
              " (w ∇ w  ) ",
              "           "};
        public string[] goblinSprite =
            { "   ↖ ㅁ    ",
              "    \\|/   ",
              "      |    ",
              "     / \\  "};
    }
}
