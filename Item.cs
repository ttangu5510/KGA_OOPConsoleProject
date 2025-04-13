using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public abstract class Item : GameObject
    {
        public string name;
        public string description;
        public string useDescription;
        public int buyGold;
        public int sellGold;
        //아이템 갯수
        public int itemNum;
        //배틀에서 사용가능한지 여부
        public bool isUsable;
        //아이템 자체가 사용 가능한지 여부
        public bool isConsumable;
        public Item(ConsoleColor color, char symbol, Vector2 position, bool isOnce) : base(color, symbol, position, true,true)
        {
            itemNum = 1;
            isUsable = true;
            isConsumable = true;
        }
        public Item()
        {
            itemNum = 1;
            isUsable = true;
            isConsumable = true;
        }
        public override void Interact(Player player)
        {
            Util.PrintText($"{name}을 획득했다!");
            player.Inventory.Add(this);
        }
        public abstract void Use();
    }
}
