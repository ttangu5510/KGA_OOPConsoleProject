using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class LongSword:Weapon
    {
        public LongSword()
        {
            name = "롱소드";
            description = "칼날이 무뎠지만 무게감이 좋은 검";
            power = 10;
            buyGold = 300;
            sellGold = 150;
        }
        public LongSword(Vector2 position) : base(position)
        {
            name = "단검";
            description = "짧고 뭉툭한 단검";
            power = 5;
            buyGold = 150;
            sellGold = 75;
        }
    }
}
