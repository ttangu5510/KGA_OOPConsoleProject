using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class ShortKnife : Weapon
    {

        public ShortKnife(Vector2 position) :base(position)
        {
            name = "단검";
            description = "짧고 뭉툭한 단검";
            power = 5;
            buyGold = 150;
            sellGold = 75;
        }
        public ShortKnife()
        {
            name = "단검";
            description = "짧고 뭉툭한 단검";
            power = 5;
            buyGold = 150;
            sellGold = 75;
        }
        public override void Use()
        {
            Equip();   
        }
    }
}
