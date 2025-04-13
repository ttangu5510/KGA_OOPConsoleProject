using KGA_OOPConsoleProject.Items;
using KGA_OOPConsoleProject.Items.MonsterDrop;

namespace KGA_OOPConsoleProject.NPCs
{
    public class QuestNPC : NPC
    {
        private bool isComplete;
        private enum ChatOrder { 처음, 수락전, 수락후, 모은후, 완료후 }
        private ChatOrder chatOrder;
        public QuestNPC(Vector2 position) : base(position)
        {
            isComplete = false;
            chatOrder = ChatOrder.처음;
        }

        public override void Interact(Player player)
        {

            switch (chatOrder)
            {
                case ChatOrder.처음:
                    Util.PrintText("밖에 나갈 생각이야? 마을 밖은 위험하잖아!");
                    Util.PrintText("...그래... 대신에 다치지 않게 조심해야 돼?");
                    chatOrder = ChatOrder.수락전;
                    break;
                case ChatOrder.수락전:
                    // 퀘스트 수락 가능 여부, 퀘스트 수락 여부
                    AcceptQuest(player);
                    break;
                case ChatOrder.수락후:
                    bool checkQuestItem = CheckQuest(player);
                    // 퀘스트 아이템을 다 모았다면
                    if (checkQuestItem == true)
                    {
                        chatOrder = ChatOrder.모은후;
                    }
                    break;
                case ChatOrder.모은후:

                    break;
            }
        }

        // 퀘스트 수락 선택
        public void AcceptQuest(Player player)
        {
            // 1. 캐릭 레벨이 9이상이면
            if (player.Level >= 9)
            {
                Util.PrintText("며칠만에 돌아오는거야! 걱정했잖아!");
                Util.PrintText("그런데 너 많이 강해진거 같다?");
                Util.PrintText("너가 이제 충분히 강해진거 같아서 그런데... 부탁 좀 해도 돼?");
                Util.PrintText("던전에서 미노타우르스의 고기 좀 가져다 줘! 3개면 될 거 같아");
                int choiceIndex = 7;
                bool isChoice = false;
                while (isChoice == false)
                {
                    Console.Write("┌---------------┐");
                    Console.Write("|               |");
                    Console.Write("└---------------┘");
                    Console.Write("   예   아니오");
                    Util.PrintChoice(choiceIndex);
                    ConsoleKey input = InputHelp.InputKey();
                    switch (input)
                    {
                        case ConsoleKey.LeftArrow:
                            if (choiceIndex > 7)
                            {
                                choiceIndex -= 5;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (choiceIndex <= 7)
                            {
                                choiceIndex += 5;
                            }
                            break;
                        case ConsoleKey.A:
                            switch (choiceIndex)
                            {
                                case 7:
                                    isChoice = true;

                                    Util.PrintText("그럼 부탁할게! 보상이 무엇인지는 기대해~");
                                    chatOrder = ChatOrder.수락후;
                                    break;
                                case 8:
                                    isChoice = true;
                                    Util.PrintText("그래... 마음이 바뀌면 알려줘!");
                                    break;
                            }
                            break;
                        case ConsoleKey.S:
                            Util.PrintText("그래... 마음이 바뀌면 알려줘!");
                            isChoice = true;
                            break;
                    }
                }

            }
            // 캐릭 레벨이 9 이하면
            else
            {
                Util.PrintText("마을 밖은 어때!? 위험하지는 않아?");
                Util.PrintText("우리 엄마는 나를 절대 밖에 못나가게 하거든");
                Util.PrintText("혹시 던전에서...");
                Util.PrintText("... 아니야. 미안! 못들은 걸로 해줘!");
                Util.PrintText("던전은 너무 위험하잖아!");
            }
        }

        // 퀘스트 체크
        public bool CheckQuest(Player player)
        {
            // 인벤토리 클래스 안에서 "퀘스트 아이템"이 "갯수"만큼 있나 체크한다
            isComplete = player.Inventory.CheckQuestItem(new MinoMeat(), 3);
            if (isComplete == true)
            {
                Util.PrintText("정말 가져왔구나! 고마워!");
                Util.PrintText("이건 보답이야");
                player.Inventory.Add(new ChateauRomani());
                player.Inventory.Remove(new MinoMeat());
                Util.PrintText("우리 목장의 우유는 최고로 맛있다구");
                Util.PrintText("혹시 또 우유가 필요하면 말해줘! 공짜는 안되지만...");
                return true;
            }
            else
            {
                Util.PrintText("너무 무리하지는 마. 꼭 필요한 건 아니니까...");
                return false;
            }
        }

    }
}
