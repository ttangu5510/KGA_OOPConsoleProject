﻿namespace KGA_OOPConsoleProject.Scene
{
    // TODO : 전투씬 구현
    // 1. 전투화면 렌더
    //    1.1 플레이어
    //    1.2. 몬스터
    // 2. 인터페이스 렌더
    //    2.1 공격한다 - 일반공격, 스킬
    //    2.2 방어한다
    //    2.3 아이템 - 인벤토리 연결
    //    2.4 도망친다 - isRun = true
    // 3. 선택 커서 렌더
    // 4. 전투 승리 시 골드 아이템 경험치 획득
    // 5. 도망친다의 경우 몬스터를 삭제하지 않고 배틀종료, 플레이어의 isRun도 다시 되돌림
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
        }

        public override void Render()
        {
            // TODO : 게임 스크린 크기 결정 후, 픽스 작업
            // TODO : 도전과제) JRPG처럼 전투화면 구성
            Console.Clear();
            // TODO : 게임 스크린 크기 결정 후, 픽스 작업
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

            // HP바 출력
            if(ChangeHP != null)
            {
                ChangeHP.Invoke();
                ChangeHP = null;
            }
            Console.SetCursorPosition(1, 1);
            Console.Write($"HP: {player.CurHP} {playerHPBar}    {monster.name}| HP: {monster.curHP} {monsterHPBar}");
            Console.SetCursorPosition(1, 2);
            Console.Write($"               ");
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
                    }
                    MonsterMove();
                    que.Dequeue();
                    que.Enqueue("MonsterMove");
                    break;
                case "PlayerMove":
                    if (PlayerDisGuard != null)
                    {
                        PlayerDisGuard.Invoke();
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
            }
            else if (player.IsRun)
            {
                Util.PrintText("성공적으로 도망쳤다");
            }
            else if (player.IsDead)
            {
                Util.PrintText("눈앞이 캄캄해졌다...");
                GameManager.IsGameOver();
            }
            Console.WriteLine("베틀씬 결과");
            Console.ReadKey(true);
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
            Console.SetCursorPosition(0, 7);
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
                }

            }
        }
        // 플레이어 전투 선택
        public void ChoiceMove()
        {
            Render();
            ConsoleKey input = Console.ReadKey(true).Key;
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

            Console.SetCursorPosition(0, 7);
            Console.WriteLine("┌--------┐");
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("|  공격  |");
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("|  스킬  |");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("└--------┘");
            Util.PrintChoice(choiceAttackY);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    choiceAttackY--;
                    break;
                case ConsoleKey.DownArrow:
                    choiceAttackY++;
                    break;
                case ConsoleKey.A:
                    if (choiceAttackY == 7)
                    {
                        player.PlayerAttack();
                        stack.Pop();
                        stack.Pop();
                    }
                    else if (choiceAttackY == 8)
                    {
                        player.PlayerSkill();
                        stack.Pop();
                        stack.Pop();
                    }
                    break;
                case ConsoleKey.S:
                    choiceAttackY = 7;
                    stack.Pop();
                    break;
            }

        }
        // 플레이어 방어 선택
        public void ChoiceGuard()
        {
            if (PlayerDisGuard == null)
            {
                player.PlayerGuard();
            }
            Console.SetCursorPosition(0, 7);
            Util.PrintText("방어 자세를 했다!", ConsoleColor.Blue, 25, 150, false);
            PlayerDisGuard += () => player.PlayerUnGuard();
        }
        // 플레이어 아이템 선택
        public void ChoiceItem()
        {
            Console.WriteLine("아이템");
            Console.ReadKey(true);
        }
        // 플레이어 도망 선택
        public void ChoiceRun()
        {
            Console.WriteLine("도망");
            Console.ReadKey(true);
        }
        // HP바 조절
        public void ChangeHPBar(int curHP,int maxHP)
        {
            int hpPercent = curHP * 100 / maxHP;
            if(hpPercent>90&&hpPercent<100)
            {
                playerHPBar = "■■■■■■■■■□";
            }
            else if(hpPercent>80)
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
                    MonsterDisGuard += () => monster.MonsterUnguard();
                }
            }
            else
            {
                int dex = rand.Next(0, 110);
                int monsterDamage = monster.MonsterAttack();
                int monsterPower = monster.level * 100;
                int totalDamage = monsterDamage * (monsterPower - player.Defence) / monsterPower;
                Console.SetCursorPosition(0, 7);
                if (dex > 100)
                {
                    totalDamage = totalDamage * 120 / 100;
                    Util.PrintText("크리티컬 !!!", ConsoleColor.Red);
                    Util.PrintText($"{totalDamage}의 데미지를 입었다!", ConsoleColor.Red);
                    ChangeHP += () => player.PlayerHit(totalDamage);
                    ChangeHP += () => player.PlayerDead();
                    ChangeHP += () => ChangeHPBar(player.CurHP, player.MaxHP);
                }
                else if (dex < 10)
                {
                    Util.PrintText($"{monster.name}의 공격은 빗나갔다!", ConsoleColor.Yellow);
                }
                else
                {
                    Util.PrintText($"{totalDamage}의 데미지를 입었다!");
                    ChangeHP += () => player.PlayerHit(totalDamage);
                    ChangeHP += () => player.PlayerDead();
                    ChangeHP += () => ChangeHPBar(player.CurHP, player.MaxHP);
                }
            }
        }
    }
}
