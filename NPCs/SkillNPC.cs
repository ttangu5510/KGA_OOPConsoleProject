using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.NPCs
{
    public class SkillNPC : NPC
    {
        private enum ChatLog { 처음, 이후}
        private ChatLog chatLog;
        private Skill skill;
        public SkillNPC()
        {
            chatLog = ChatLog.처음;
            skill = new UpperSlash();
        }

        public SkillNPC(Vector2 position) : base(position)
        {
            chatLog = ChatLog.처음;
            skill = new UpperSlash();
        }
        public override void Interact(Player player)
        {
            switch(chatLog)
            {
                case ChatLog.처음:
                    Util.PrintText("좋은날씨네! 그런데... 슬라임이 너무 많아!");
                    Util.PrintText("내가 스킬을 전수해주지! 그러니 슬라임 좀 잡아줘!");
                    player.Skills.Add(skill);
                    Util.PrintText($"{skill.Name}스킬을 배웠다!");
                    chatLog = ChatLog.이후;
                    break;
                case ChatLog.이후:
                    Util.PrintText("내가 알려준 스킬 잘 쓰고있어?");
                    if(player.Weapon == null)
                    {
                        Util.PrintText("너 그런데 무기도 없이 싸우게?");
                    }
                    break;
            }
        }
    }
}
