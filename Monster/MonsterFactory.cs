using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject.Monster
{
    public class Monster
    {
        public string name;
        public int level;
        public int exp;
        public int damage;
        public int hp;
        public List<Item> mItems;
        public int gold;
        public Monster(string name,int level, int exp, int damage, int hp, List<Item> mItems, int gold)
        {
            this.name = name;
            this.level = level;
            this.exp = exp;
            this.damage = damage;
            this.hp = hp;
            this.mItems = mItems;
            this.gold = gold;
        }
        public void MonsterAttack()
        {

        }
    }
    public class MonsterFactory
    {
        public float powerRate = 1;
        public Potion potion = new Potion();

        public Monster MonsterCreate(string name)
        {
            Monster monster;
            switch(name)
            {
                case "슬라임":
                    List<Item> sItems = [potion];
                    monster = new Monster("슬라임", 3, 3, 2, 15, sItems,10);
                    break;
                default:
                    Console.WriteLine("몬스터 이름이 없습니다");
                    return null;
            }
            return monster;
        }
    }
}
