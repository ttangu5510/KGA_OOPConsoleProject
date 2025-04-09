namespace KGA_OOPConsoleProject.NPCs
{
    public class DocNPC : NPC
    {
        private Stack<string> stack;
        private int choiceIndex;
        public DocNPC(Vector2 position) : base(position)
        {
            choiceIndex = 6;
            stack = new Stack<string>();
        }
        public override void Interact(Player player)
        {
            Util.PrintText("힐러: 상처를 치유해드릴까요?");
            Util.PrintText("회복 비용 : 100G ");
            stack.Push("선택");
            while (stack.Count > 0)
            {
                Console.SetCursorPosition(35, 6);
                Console.Write("┌---------┐");
                Console.SetCursorPosition(35, 7);
                Console.Write("|  예     |");
                Console.SetCursorPosition(35, 8);
                Console.Write("|  아니요 |");
                Console.SetCursorPosition(35, 9);
                Console.Write("└---------┘");
                Util.PrintChoice(choiceIndex, 36);
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        if (choiceIndex > 6)
                        {
                            choiceIndex--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (choiceIndex < 7)
                        {
                            choiceIndex++;
                        }
                        break;
                    case ConsoleKey.A:
                        switch (choiceIndex)
                        {
                            case 6:
                                player.HPHeal(9999);
                                if (player.Gold > 100)
                                {
                                    player.LoseGold(100);
                                    Util.PrintText("체력을 회복했다!");
                                }
                                else
                                {
                                    Util.PrintText("돈이 부족하다...");
                                }

                                break;
                        }
                        stack.Pop();
                        break;
                    case ConsoleKey.S:
                        choiceIndex = 6;
                        stack.Pop();
                        break;
                }

            }

        }
    }
}
