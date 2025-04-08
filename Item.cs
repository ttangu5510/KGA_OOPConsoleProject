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
        public Item(ConsoleColor color, char symbol, Vector2 position, bool isOnce) : base(color, symbol, position, true,true)
        {
        }
        public Item()
        {

        }
        public override void Interact(Player player)
        {
            player.Inventory.Add(this);
        }
        public abstract void Use();
    }
}
