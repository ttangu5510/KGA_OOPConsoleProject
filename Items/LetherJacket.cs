using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class LetherJacket : Armor
    {

        public LetherJacket(Vector2 position ):base(position)
        {
            name = "가죽자켓";
            description = "질긴 재질이지만, 무겁다. 냄새도 좀 난다";
            defence = 5;
            buyGold = 100;
            sellGold = 50;
        }
        public LetherJacket() 
        {
            name = "가죽자켓";
            description = "질긴 재질이지만, 무겁다. 냄새도 좀 난다";
            defence = 5;
            buyGold = 100;
            sellGold = 50;
        }
    }
}
