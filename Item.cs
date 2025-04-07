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
        public Item(ConsoleColor color, char symbol, Vector2 position) : base(ConsoleColor.Yellow, symbol, position, true)
        {
        }
        public override void Interact(Player player)
        {
            player.inventory.Add(this);
        }
        public abstract void Use();
    }
}
