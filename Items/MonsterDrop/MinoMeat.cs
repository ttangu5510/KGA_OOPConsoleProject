﻿using System;
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
            name = "미노 고기";
            description = "미노타우루스의 고기. 마블링이 대단하다";
            useDescription = "사용할 수 없다...";
            sellGold = 200;
            isConsumable = false;
        }

        public override void Use()
        {
            return;
        }
    }
}
