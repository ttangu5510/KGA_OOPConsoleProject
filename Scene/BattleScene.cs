namespace KGA_OOPConsoleProject.Scene
{
    public class BattleScene : BaseScene
    {
        public Action MonsterDisGuard;
        public Action PlayerDisGuard;
        public Action ChangeHP;
        ConsoleKey input;
        private Player player;
        private Monster monster;
        private int choiceIndexX;
        private int choiceIndexY;
        private int choiceAttackY;
        public Stack<string> stack;
        public Queue<string> que;
        private string playerHPBar;
        private string monsterHPBar;
        private int playerDamage;
        Random rand = new Random();

        public bool isBattle;


        public BattleScene(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
            choiceIndexX = 1;
            choiceIndexY = 10;
            choiceAttackY = 7;
            stack = new Stack<string>();
            que = new Queue<string>();
            isBattle = true;
            playerHPBar = "■■■■■■■■■■";
            monsterHPBar = "■■■■■■■■■■";
            playerDamage = 0;
        }

        public override void Render()
        {
            // 배틀 씬 스크린 레이아웃
            Console.Clear();
            Console.WriteLine("┌-------------------------------------------------┐");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("└-------------------------------------------------┘");


            // 배틀씬 UI 입력
            Console.WriteLine("┌-------------------------------------------------┐");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("└-------------------------------------------------┘");

            // HP바, MP 출력
            if (ChangeHP != null)
            {
                ChangeHP.Invoke();
                ChangeHP = null;
            }
            Console.SetCursorPosition(1, 1);
            Console.Write($"HP: {player.CurHP} {playerHPBar} | MP: {player.MP}   ");
            Console.SetCursorPosition(1, 2);
            Console.Write($"                      {monster.name}| HP: {monster.curHP} {monsterHPBar} ");
            Console.SetCursorPosition(1, 11);
            Console.Write("  공격      방어      아이템    도망간다 ");
            // 선택 커서 출력
            Util.PrintChoice(choiceIndexY, choiceIndexX);
            // 캐릭터 출력
            int pX = 3, pY = 2;
            int mX = 35, mY = 5;
            player.PlayerSprite(pX, pY);
            monster.MonsterSprite(mX, mY);


        }

        public override void Input()
        {

        }

        public override void Update()
        {

            switch (que.Peek())
            {
                case "MonsterMove":
                    if (MonsterDisGuard != null)
                    {
                        MonsterDisGuard.Invoke();
                        MonsterDisGuard -= monster.MonsterUnGuard;
                    }
                    MonsterMove();
                    que.Dequeue();
                    que.Enqueue("MonsterMove");
                    break;
                case "PlayerMove":
                    if (PlayerDisGuard != null)
                    {
                        PlayerDisGuard.Invoke();
                        PlayerDisGuard -= player.PlayerUnGuard;
                    }
                    PlayerMove();
                    que.Dequeue();
                    que.Enqueue("PlayerMove");
                    break;
            }
        }
        public override void Result()
        {
            if (monster.isDead)
            {
                Util.PrintText("전투에서 승리했다!");
                Util.PrintText($"{monster.gold}G 획득!");
                player.GetGold(monster.gold);
                Util.PrintText($"경험치 {monster.exp}획득!");
                player.PlayerGetExp(monster.exp);
                for (int i = 0; i < monster.mItems.Count; i++)
                {
                    Util.PrintText($"{monster.mItems[i].name}을 획득했다!");
                    player.Inventory.Add(monster.mItems[i]);
                }
                //TODO 현재까지 가장 강한 몬스터
                if(monster.name == "오크")
                {
                    GameManager.IsGameOver();
                }

            }
            else if (player.IsRun)
            {
                Util.PrintText("성공적으로 도망쳤다");
                player.IsRun = false;
            }
            else if (player.IsDead)
            {
                Util.PrintText("눈앞이 캄캄해졌다...");
                GameManager.IsGameOver();
            }
            Console.Clear();
        }

        public void Battle()
        {
            StartBattle();
            Render();
            Util.PrintText("전투 시작!");
            while (isBattle)
            {
                Update();
                Render();
                isBattle = !(monster.isDead || player.IsRun || player.IsDead);
            }
            Result();
        }
        // 배틀 시작 시, 스피드에 따른 큐 순서 저장
        public void StartBattle()
        {
            if (monster.speed > player.Speed)
            {
                que.Enqueue("MonsterMove");
                que.Enqueue("PlayerMove");
            }
            else
            {
                que.Enqueue("PlayerMove");
                que.Enqueue("MonsterMove");
            }
        }

        // 플레이어 턴
        public void PlayerMove()
        {
            int randNum = rand.Next(0, 100);
            stack.Push("전투 선택");
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "전투 선택":
                        ChoiceMove();
                        break;
                    case "공격 선택":
                        ChoiceAttack();
                        break;
                    case "방어 선택":
                        ChoiceGuard();
                        break;
                    case "아이템 선택":
                        ChoiceItem();
                        break;
                    case "도망 선택":
                        ChoiceRun();
                        break;
                    case "스킬 선택":
                        ChoiceSkill();
                        break;
                }
            }
        }
        // 플레이어 전투 선택
        public void ChoiceMove()
        {
            Render();
            ConsoleKey input = InputHelp.InputKey();
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    if (choiceIndexX > 10)
                    {
                        choiceIndexX -= 10;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (choiceIndexX < 30)
                    {
                        choiceIndexX += 10;
                    }
                    break;
                case ConsoleKey.A:
                    switch (choiceIndexX)
                    {
                        case 1:
                            stack.Push("공격 선택");
                            choiceIndexX = 1;
                            break;
                        case 11:
                            stack.Push("방어 선택");
                            choiceIndexX = 1;
                            break;
                        case 21:
                            stack.Push("아이템 선택");
                            choiceIndexX = 1;
                            break;
                        case 31:
                            stack.Push("도망 선택");
                            choiceIndexX = 1;
                            break;
                    }
                    break;
                case ConsoleKey.S:
                    if (stack.Count > 1)
                    {
                        stack.Pop();
                    }
                    break;
            }
        }
        // 플레이어 공격 선택
        public void ChoiceAttack()
        {
            Render();
            Console.SetCursorPosition(0, 7);
            Console.Write("┌--------┐");
            Console.SetCursorPosition(0, 8);
            Console.Write("|  공격  |");
            Console.SetCursorPosition(0, 9);
            Console.Write("|  스킬  |");
            Console.SetCursorPosition(0, 10);
            Console.Write("└--------┘");
            Util.PrintChoice(choiceAttackY);
            ConsoleKey input = InputHelp.InputKey();
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceAttackY > 7)
                    {
                        choiceAttackY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceAttackY < 8)
                    {
                        choiceAttackY++;
                    }
                    break;
                case ConsoleKey.A:
                    switch (choiceAttackY)
                    {
                        case 7:
                            playerDamage = player.PlayerAttack();
                            PlayerAttackResult();
                            stack.Pop();
                            stack.Pop();
                            break;

                        case 8:
                            stack.Push("스킬 선택");
                            choiceAttackY = 7;
                            break;
                    }
                    break;
                case ConsoleKey.S:
                    choiceAttackY = 7;
                    stack.Pop();
                    break;
            }
        }
        // 플레이어 스킬 선택
        public void ChoiceSkill()
        {
            //레이아웃 출력
            Console.SetCursorPosition(11, 7);
            Console.Write("┌----------------------------------┐");
            Console.SetCursorPosition(11, 8);
            Console.Write("|                                  |");
            Console.SetCursorPosition(11, 9);
            Console.Write("|                                  |");
            Console.SetCursorPosition(11, 10);
            Console.Write("|                                  |");
            Console.SetCursorPosition(11, 11);
            Console.Write("|                                  |");
            Console.SetCursorPosition(11, 12);
            Console.Write("└----------------------------------┘");

            // 스킬목록 출력
            for (int i = 0; i < player.Skills.Count; i++)
            {
                Console.SetCursorPosition(13, 8 + i);
                Console.Write($"{player.Skills[i].Name} 데미지: {player.Skills[i].Damage}    마나: {player.Skills[i].UseMP}");

            }


            Util.PrintChoice(choiceAttackY, 12);

            ConsoleKey input = InputHelp.InputKey();
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    if (choiceAttackY - 7 > 0)
                    {
                        choiceAttackY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceAttackY - 7 < player.Skills.Count() - 1)
                    {
                        choiceAttackY++;
                    }
                    break;
                case ConsoleKey.A:
                    switch (choiceAttackY)
                    {
                        case 7:
                            if (player.Skills[0].UseMP < player.MP)
                            {
                                playerDamage = player.Skills[0].UseSkill();
                                PlayerAttackResult();
                                stack.Pop();
                                stack.Pop();
                                stack.Pop();
                            }
                            else
                            {
                                Util.PrintText("마나가 부족합니다");
                                stack.Pop();
                                stack.Pop();
                            }
                            choiceAttackY = 7;
                            break;
                        case 8:
                            if (player.Skills[1].UseMP < player.MP)
                            {
                                playerDamage = player.Skills[1].UseSkill();
                                PlayerAttackResult();
                                stack.Pop();
                                stack.Pop();
                                stack.Pop();
                            }
                            else
                            {
                                Util.PrintText("마나가 부족합니다");
                                stack.Pop();
                                stack.Pop();
                            }
                            choiceAttackY = 7;
                            break;
                        case 9:
                            if (player.Skills[2].UseMP < player.MP)
                            {
                                playerDamage = player.Skills[2].UseSkill();
                                PlayerAttackResult();
                                stack.Pop();
                                stack.Pop();
                                stack.Pop();
                            }
                            else
                            {
                                Util.PrintText("마나가 부족합니다");
                                stack.Pop();
                                stack.Pop();
                            }
                            choiceAttackY = 7;
                            break;
                        case 10:
                            if (player.Skills[3].UseMP < player.MP)
                            {
                                playerDamage = player.Skills[3].UseSkill();
                                PlayerAttackResult();
                                stack.Pop();
                                stack.Pop();
                                stack.Pop();
                            }
                            else
                            {
                                Util.PrintText("마나가 부족합니다");
                                stack.Pop();
                                stack.Pop();
                            }
                            choiceAttackY = 7;
                            break;
                    }
                    break;
                case ConsoleKey.S:
                    choiceAttackY = 7;
                    stack.Pop();
                    break;
            }
        }

        // 플레이어 공격 정산
        public void PlayerAttackResult()
        {
            int dex = rand.Next(0, 110);
            int totalDamage = playerDamage * (100 * monster.level - monster.defence) / (100 * monster.level);
            if (dex > 100)
            {
                if(player.Weapon!=null)
                {
                    player.Weapon.LoseDurability();
                }
                totalDamage = totalDamage * 120 / 100;
                Util.PrintText("크리티컬!!!", ConsoleColor.Red);
                monster.MonsterHit(totalDamage);
            }
            else if (dex < 10)
            {
                Util.PrintText("플레이어 공격이 빗나갔다...");
            }
            else
            {
                if(player.Weapon !=null)
                {
                    player.Weapon.LoseDurability();
                }
                monster.MonsterHit(totalDamage);
            }
            ChangeHP += () => MonsterChangeHPBar(monster.curHP, monster.maxHP);
        }
        // 플레이어 방어 선택
        public void ChoiceGuard()
        {
            if (PlayerDisGuard == null)
            {
                player.PlayerGuard();
                PlayerDisGuard += player.PlayerUnGuard;
            }
            Util.PrintText("방어 자세를 했다!");
            stack.Pop();
            stack.Pop();
        }
        // 플레이어 아이템 선택
        public void ChoiceItem()
        {
            player.Inventory.isBattle = true;
            player.Inventory.OpenInven();
            player.Inventory.isBattle = false;
            if (player.Inventory.isUse == true)
            {
                player.Inventory.isUse = false;
                stack.Pop();
            }
            stack.Pop();
        }
        // 플레이어 도망 선택
        public void ChoiceRun()
        {
            player.PlayerRun();
            stack.Pop();
            stack.Pop();
        }
        // HP바 조절
        public void ChangeHPBar(int curHP, int maxHP)
        {
            int hpPercent = curHP * 100 / maxHP;
            if (hpPercent > 99)
            {
                playerHPBar = "■■■■■■■■■■";
            }
            else if (hpPercent > 90 && hpPercent < 100)
            {
                playerHPBar = "■■■■■■■■■□";
            }
            else if (hpPercent > 80)
            {
                playerHPBar = "■■■■■■■■□□";
            }
            else if (hpPercent > 70)
            {
                playerHPBar = "■■■■■■■□□□";
            }
            else if (hpPercent > 60)
            {
                playerHPBar = "■■■■■■□□□□";
            }
            else if (hpPercent > 50)
            {
                playerHPBar = "■■■■■□□□□□";
            }
            else if (hpPercent > 40)
            {
                playerHPBar = "■■■■□□□□□□";
            }
            else if (hpPercent > 30)
            {
                playerHPBar = "■■■□□□□□□□";
            }
            else if (hpPercent > 20)
            {
                playerHPBar = "■■□□□□□□□□";
            }
            else if (hpPercent > 10)
            {
                playerHPBar = "■□□□□□□□□□";
            }
        }
        public void MonsterChangeHPBar(int curHP, int maxHP)
        {
            int hpPercent = curHP * 100 / maxHP;
            if (hpPercent > 99)
            {
                monsterHPBar = "■■■■■■■■■■";
            }
            else if (hpPercent > 90 && hpPercent < 100)
            {
                monsterHPBar = "■■■■■■■■■□";
            }
            else if (hpPercent > 80)
            {
                monsterHPBar = "■■■■■■■■□□";
            }
            else if (hpPercent > 70)
            {
                monsterHPBar = "■■■■■■■□□□";
            }
            else if (hpPercent > 60)
            {
                monsterHPBar = "■■■■■■□□□□";
            }
            else if (hpPercent > 50)
            {
                monsterHPBar = "■■■■■□□□□□";
            }
            else if (hpPercent > 40)
            {
                monsterHPBar = "■■■■□□□□□□";
            }
            else if (hpPercent > 30)
            {
                monsterHPBar = "■■■□□□□□□□";
            }
            else if (hpPercent > 20)
            {
                monsterHPBar = "■■□□□□□□□□";
            }
            else if (hpPercent > 10)
            {
                monsterHPBar = "■□□□□□□□□□";
            }
        }

        // 몬스터 행동 - 랜덤으로 행동한다
        public void MonsterMove()
        {
            int randNum = rand.Next(0, 100);

            if (randNum > 90)
            {
                Console.SetCursorPosition(0, 7);
                Util.PrintText($"{monster.name}이/가 방어 자세를 했다!", ConsoleColor.Blue);
                if (MonsterDisGuard == null)
                {
                    monster.MonsterGuard();
                    MonsterDisGuard += monster.MonsterUnGuard;
                }
            }
            else
            {
                int dex = rand.Next(0, 110);
                int monsterDamage = monster.MonsterAttack();
                int monsterPower = monster.level * 100;
                int totalDamage = monsterDamage * (100 * player.Level - player.Defence) / 100 * player.Level;
                Console.SetCursorPosition(0, 7);
                if (dex > 100)
                {
                    totalDamage = totalDamage * 120 / 100;
                    Util.PrintText("크리티컬 !!!", ConsoleColor.Red);
                    Util.PrintText($"{totalDamage}의 데미지를 입었다!", ConsoleColor.Red);
                    if(player.Armor != null)
                    {
                        player.Armor.LoseDurability();
                    }
                    ChangeHP += () => player.PlayerHit(totalDamage);
                    ChangeHP += () => ChangeHPBar(player.CurHP, player.MaxHP);
                }
                else if (dex < 10)
                {
                    Util.PrintText($"{monster.name}의 공격은 빗나갔다!", ConsoleColor.Yellow);
                }
                else
                {
                    Util.PrintText($"{totalDamage}의 데미지를 입었다!");
                    if(player.Armor != null)
                    {
                        player.Armor.LoseDurability();
                    }
                    ChangeHP += () => player.PlayerHit(totalDamage);
                    ChangeHP += () => ChangeHPBar(player.CurHP, player.MaxHP);
                }
            }
        }
    }
}
