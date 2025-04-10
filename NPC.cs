using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class NPC : GameObject
    {
        public NPC()
        {

        }

        public NPC(Vector2 position) : base(ConsoleColor.Cyan, '§', position, false, false)
        {

        }

        public override void Interact(Player player)
        {
            Util.PrintText("요즘 잘 지내?");
        }
    }
}
