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
    public class BattleScene : BaseScene
    {
        ConsoleKey input;
        private Player player;
        private Monster monster;

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("배틀 씬 출력");
            Console.WriteLine($" 체력 : {player.CurHP}");
            Console.WriteLine($" 몬스터 체력 : {monster.hp}");
            Console.WriteLine($" 몬스터 공격받음 : ");
            monster.MonsterHit(10);
            Console.WriteLine($" 몬스터 체력 : {monster.hp}");
        }

        public BattleScene()
        {

        }

        public override void Input()
        {
            Console.WriteLine("배틀씬 입력");
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            Console.WriteLine("배틀씬 업데이트");
            input = Console.ReadKey(true).Key;
        }

        public override void Result()
        {
            Console.WriteLine("베틀씬 결과");
            input = Console.ReadKey(true).Key;
        }

        public void Battle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;

            bool isBattle = !monster.isDead && !monster.isRun && !player.IsRun;

            while (isBattle)
            {
                Render();
                Input();
                Update();
                Result();
                if(monster.isDead)
                {
                    Console.WriteLine("반복종료");
                    Console.ReadKey(true);
                }
                isBattle = !monster.isDead && !monster.isRun && !player.IsRun;
            }
        }
    }
}
