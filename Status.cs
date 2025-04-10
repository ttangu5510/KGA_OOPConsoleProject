namespace KGA_OOPConsoleProject
{
    public static class Status
    {
        public static void PrintStatus()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌------ 스테이터스 ---------------------┐");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("└---------------------------------------┘");
            Console.SetCursorPosition(2, 1);
            Console.Write($"레벨: {GameManager.Player.Level}");
            Console.SetCursorPosition(2, 2);
            Console.Write($"현재 / 필요 경험치: {GameManager.Player.Exp} / {GameManager.Player.MaxExp}");
            Console.SetCursorPosition(2, 3);
            if (GameManager.Player.Weapon != null)
            {
                Console.Write($"공격력: {GameManager.Player.Power + GameManager.Player.Weapon.Power}");
            }
            else
            {
                Console.Write($"공격력: {GameManager.Player.Power}");
            }
            if (GameManager.Player.Armor != null)
            {
                Console.Write($"  방어력: {GameManager.Player.Defence + GameManager.Player.Armor.Defence}");
            }
            else
            {
                Console.Write($"  방어력: {GameManager.Player.Defence}");
            }
            Console.SetCursorPosition(2, 4);
            Console.Write($"스피드: {GameManager.Player.Speed}");
            Console.SetCursorPosition(2, 5);
            Console.Write($"현재 / 최대 HP: {GameManager.Player.CurHP} / {GameManager.Player.MaxHP}");
            Console.SetCursorPosition(2, 6);
            Console.Write($"현재 / 최대 MP: {GameManager.Player.MP}/{GameManager.Player.MaxMP}");
            Console.ReadKey(true);
        }
        public static void PrintSkills()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("┌------ 스테이터스 ---------------------┐");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("└---------------------------------------┘");
        }
    }
}
