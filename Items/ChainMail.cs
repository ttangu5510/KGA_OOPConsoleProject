using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class ChainMail : Armor
    {
        public ChainMail() 
        {
            name = "체인메일";
            description = "튼튼하지만 많이 무겁다. 군데군데 녹슬었다";
            defence = 15;
            buyGold = 250;
            sellGold = 150;
        }
        public ChainMail(Vector2 position): base(position)
        {
            name = "체인메일";
            description = "튼튼하지만 많이 무겁다. 군데군데 녹슬었다";
            defence = 15;
            buyGold = 250;
            sellGold = 150;
        }
    }
}
