﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class TownNPC : NPC
    {
        private int NPCNum;
        public TownNPC(Vector2 position,int NPCNum) : base(position)
        {
            this.NPCNum = NPCNum;
        }
        public override void Interact(Player player)
        {
            switch(NPCNum)
            {
                case 1:
                    Util.PrintText("마을 밖에 몬스터가 있어!");
                    break;
                case 2:
                    Util.PrintText("상점에 새로운 물건이 들어왔대!");
                    break;
                case 3:
                    Util.PrintText("다쳤으면 의사를 만나거라");
                    break;
                case 4:
                    Util.PrintText("마물들이 요즘들어 이상해..");
                    break;
            }
        }
    }
}
