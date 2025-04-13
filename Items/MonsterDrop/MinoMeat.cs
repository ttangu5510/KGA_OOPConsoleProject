using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Items.MonsterDrop
{
    public class MinoMeat : Item
    {
        public MinoMeat()
        {
            name = "미노타우르스의 고기";
            description = "미노타우루스의 고기다. 마블링이 대단하다";
            isUsable = false;
            sellGold = 200;
        }

        public override void Use()
        {
            GameManager.Player.HPHeal(100);
        }
    }
}
