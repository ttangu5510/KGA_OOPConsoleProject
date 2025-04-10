﻿using System;
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
        public int itemNum;
        public bool isUsable;
        public Item(ConsoleColor color, char symbol, Vector2 position, bool isOnce) : base(color, symbol, position, true,true)
        {
            itemNum = 1;
            isUsable = true;

        }
        public Item()
        {
            itemNum = 1;
            isUsable = true;

        }
        public override void Interact(Player player)
        {
            Util.PrintText($"{name}을 획득했다!");
            player.Inventory.Add(this);
        }
        public abstract void Use();
    }
}
