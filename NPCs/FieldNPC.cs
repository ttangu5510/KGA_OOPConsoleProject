using KGA_OOPConsoleProject.Items;

namespace KGA_OOPConsoleProject.NPCs
{
    public class FieldNPC : NPC
    {
        private enum ChatLog { 처음, 이후 }
        private ChatLog chatLog;
        private int NPCNum;
        public FieldNPC(Vector2 position, int NPCNum) : base(position)
        {
            chatLog = ChatLog.처음;
            this.NPCNum = NPCNum;
        }
        public override void Interact(Player player)
        {
            switch (NPCNum)
            {
                case 1:
                    switch (chatLog)
                    {
                        case ChatLog.처음:
                            Util.PrintText("어서오세여 여행자여. 잠시 몸을 쉬었다 가세요");
                            player.HPHeal(9999);
                            player.MPHeal(9999);
                            Util.PrintText("체력과 마나가 풀 회복!");
                            chatLog = ChatLog.이후;
                            break;
                        case ChatLog.이후:
                            Util.PrintText("세상을 구해주세요...");
                            break;
                    }
                    break;
                case 2:
                    switch (chatLog)
                    {
                        case ChatLog.처음:
                            Util.PrintText("오다 주웠어! 너 줄게!");
                            player.Inventory.Add(new LongSword());
                            Util.PrintText("롱소드를 얻었다!");
                            Util.PrintText("사실 뭔가 찝찝해서 줬어 미안!");
                            chatLog = ChatLog.이후;
                            break;
                        case ChatLog.이후:
                            Util.PrintText("이 근처에 체력을 회복시켜주는 요정이 있대");
                            break;
                    }
                    break;
                case 3:
                    Util.PrintText("오크가 길을 막고 있는 안쪽이 던전이야");
                    Util.PrintText("그리고 지금 내 아래에는 상점이있어");
                    Util.PrintText("왜 이런곳에 상점이 있는걸까...");
                    break;
            }
        }
    }
}
