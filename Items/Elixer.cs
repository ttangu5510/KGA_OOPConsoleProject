using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class Elixer : Item
    {
        public Elixer()
        {
            name = "엘릭서";
            description = "대량의 마나를 회복 시키는 아이템";
            useDescription = "마나를 50 회복했다";
            buyGold = 150;
            sellGold = 50;
        }
        public Elixer(Vector2 position) : base(ConsoleColor.Cyan,'♣',position,true)
        {
            name = "엘릭서";
            description = "대량의 마나를 회복 시키는 아이템";
            useDescription = "마나를 50 회복했다";
            buyGold = 150;
            sellGold = 50;
        }
        public override void Use()
        {
            GameManager.Player.MPHeal(50);
        }
    }
}
