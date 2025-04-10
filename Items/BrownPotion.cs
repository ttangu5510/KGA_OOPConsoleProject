using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class BrownPotion : Item
    {
        public BrownPotion()
        {
            name = "주황 포션";
            description = "적당히 체력을 회복시키는 아이템";
            useDescription = "체력을 100 회복했다";
            buyGold = 150;
            sellGold = 75;
        }
        public BrownPotion(Vector2 position) : base(ConsoleColor.DarkYellow, '♥', position,true)
        {
            name = "주황 포션";
            description = "적당히 체력을 회복시키는 아이템";
            useDescription = "체력을 100 회복했다";
            buyGold = 150;
            sellGold = 75;
        }

        public override void Use()
        {
            GameManager.Player.HPHeal(100);
        }
    }
}
