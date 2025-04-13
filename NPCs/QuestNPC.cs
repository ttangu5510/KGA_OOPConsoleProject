namespace KGA_OOPConsoleProject.NPCs
{
    public class QuestNPC : NPC
    {
        private bool isComplete;
        private enum ChatLog { 처음, 수락전, 수락후, 완료후 }
        private ChatLog chatLog;
        public QuestNPC(Vector2 position) : base(position)
        {
            isComplete = false;
            chatLog = ChatLog.처음;
        }

        public void CheckQuest()
        {

        }
        public override void Interact(Player player)
        {

            switch (chatLog)
            {
                case ChatLog.처음:
                    Util.PrintText("밖에 나갈 생각이야? 마을 밖은 위험하잖아!");
                    Util.PrintText("...그래... 대신에 다치지 않게 조심해야 돼?");
                    chatLog = ChatLog.수락전;
                    break;
                case ChatLog.수락전:
                    if (player.Level >= 9)
                    {
                        Util.PrintText("며칠만에 돌아오는거야! 걱정했잖아!");
                        Util.PrintText("그런데 너 많이 강해진거 같다?");
                        Util.PrintText("너가 이제 충분히 강해진거 같아서 그런데... 부탁 좀 해도 돼?");
                        Util.PrintText("던전에서 미노타우르스의 고기 좀 가져다 줘! 3개면 될 거 같아");
                        int choiceIndex = 7;
                        bool isChoice = false;
                        while (isChoice==false)
                        {
                            Console.Write("┌---------------┐");
                            Console.Write("|               |");
                            Console.Write("└---------------┘");
                            Console.Write("   예   아니오");
                            Util.PrintChoice(choiceIndex);
                            ConsoleKey input = InputHelp.InputKey();
                            switch(input)
                            {
                                case ConsoleKey.LeftArrow:
                                    if(choiceIndex>7)
                                    {
                                        choiceIndex-=5;
                                    }

                                    break;
                                    case ConsoleKey.RightArrow:
                                    if (choiceIndex <= 7)
                                    {
                                        choiceIndex+=5;
                                    }
                                    break;
                                case ConsoleKey.A:
                                    switch(choiceIndex)
                                    {
                                        case 7:
                                            isChoice = true;

                                            Util.PrintText("그럼 부탁할게! 보상이 무엇인지는 기대해~");
                                            chatLog = ChatLog.수락후;
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
                    else
                    {
                        Util.PrintText("마을 밖은 어때!? 위험하지는 않아?");
                        Util.PrintText("우리 엄마는 나를 절대 밖에 못나가게 하거든");
                        Util.PrintText("혹시 던전에서...");
                        Util.PrintText("... 아니야. 미안! 못들은 걸로 해줘!");
                        Util.PrintText("던전은 너무 위험하잖아!");
                    }
                    break;
                case ChatLog.수락후:
                    break;
                case ChatLog.완료후:
                    break;
            }
        }
    }
}
