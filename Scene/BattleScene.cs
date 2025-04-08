namespace KGA_OOPConsoleProject.Scene
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

        ConsoleKey input;
        private Player player;
        private Monster monster;
        private int choiceIndexX;
        private int choiceIndexY;
        public Stack<string> stack;
        public Queue<string> que;
        public BattleScene(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
            choiceIndexX = 0;
            choiceIndexY = 10;
            stack = new Stack<string>();
            que = new Queue<string>();
        }
        public override void Render()
        {
            // TODO : 게임 스크린 크기 결정 후, 픽스 작업
            // TODO : 도전과제) JRPG처럼 전투화면 구성
            Console.Clear();
            // Console.WriteLine("배틀 씬 출력");
            // Console.WriteLine($" 체력 : {player.CurHP}");
            // Console.WriteLine($" 몬스터 체력 : {monster.hp}");
            // Console.WriteLine($" 몬스터 공격받음 : ");
            // monster.MonsterHit(10);
            // Console.WriteLine($" 몬스터 체력 : {monster.hp}");
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


            //Console.WriteLine("배틀씬 UI 입력");
            Console.WriteLine("┌-------------------------------------------------┐");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("└-------------------------------------------------┘");
            int x = 1, y = 11;
            Console.SetCursorPosition(x, y);
            Console.Write("  공격     방어     아이템     도망간다 ");
            // 선택 커서 출력
            Util.PrintChoice(choiceIndexY);
            // 캐릭터 출력
            int pX = 3, pY = 2;
            int mX = 35, mY = 5;
            player.PlayerSprite(pX,pY);
            monster.MonsterSprite(mX, mY);
        }



        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            que.Enqueue("StartBattle");
            Console.WriteLine("배틀씬 업데이트");
            while(que.Count > 0)
            {
                switch (que.Peek())
                {
                    case "StartBattle":
                        StartBattle();
                        break;
                }
            }
    

        }

        public override void Result()
        {
            Console.WriteLine("베틀씬 결과");
            input = Console.ReadKey(true).Key;
        }

        public void Battle()
        {


            bool isBattle = !monster.isDead && !monster.isRun && !player.IsRun;

            while (isBattle)
            {
                Render();
                Input();
                Update();
                Result();
                if (monster.isDead)
                {
                    Console.WriteLine("전투 종료");
                    Console.ReadKey(true);
                }
                isBattle = !monster.isDead && !monster.isRun && !player.IsRun;
            }
        }
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
    }
}
