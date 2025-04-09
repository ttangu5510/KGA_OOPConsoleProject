using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class HomeNPC : NPC
    {
        enum ChatLog { 처음, 다음, 첫던전후}
        private ChatLog chatLog;
        public HomeNPC(Vector2 position) : base(position)
        {
            chatLog = ChatLog.처음;
        }
        public override void Interact(Player player)
        {
            switch(chatLog)
            {
                case ChatLog.처음:
                    Util.PrintText("잘 잤니? 아침은 먹고 나가거라");
                    chatLog = ChatLog.다음;
                    break;
                case ChatLog.다음:
                    Util.PrintText("요즘 마을 밖이 뒤숭숭하네...");
                    Util.PrintText("나갈 때는 조심해야된다?");
                    break;
                case ChatLog.첫던전후:
                    Util.PrintText("여행하느라 많이 힘들지? 푹 쉬다 가렴");
                    break;


            }
        }
    }

}
