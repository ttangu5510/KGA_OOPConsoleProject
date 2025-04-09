using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class BluePotion : Item
    {
        public BluePotion(Vector2 position) : base(ConsoleColor.Blue, '♣', position, true)
        {
            name = "파란 포션";
            description = "소량의 마나를 회복 시키는 아이템";
            useDescription = "마나를 15 회복했다";
            buyGold = 50;
            sellGold = 25;
        }
        public BluePotion()
        {
            name = "파란 포션";
            description = "소량의 체력을 회복 시키는 아이템";
            useDescription = "마나를 15 회복했다";
            buyGold = 50;
            sellGold = 25;
        }
        public override void Use()
        {
            GameManager.Player.MPHeal(15);
        }
    }
}
