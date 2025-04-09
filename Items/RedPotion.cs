using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items
{
    public class RedPotion : Item
    {
        public RedPotion(Vector2 position): base(ConsoleColor.Yellow,'I',position,true)
        {
            name = "빨간 포션";
            description = "소량의 체력을 회복 시키는 아이템";
            useDescription = "체력을 30 회복했다";
        }
        public RedPotion()
        {
            name = "빨간 포션";
            description = "소량의 체력을 회복 시키는 아이템";
            useDescription = "체력을 30 회복했다";
        }
        public override void Use()
        {
            GameManager.Player.HPHeal(30);            
        }
    }
}
