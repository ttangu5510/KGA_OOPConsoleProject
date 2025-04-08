using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어 세팅
        public Vector2 position;
        public bool[,] map;
        private Inventory inventory;
        private Menu menu;
        public Menu Menu { get {  return menu; } }
        public Inventory Inventory { get {  return inventory; } }
        
        // 플레이어 스탯
        private int curHP;
        private int maxHP;
        public int CurHP { get { return curHP; } }
        public int MaxHP { get { return maxHP; } }
        private bool isRun;
        public bool IsRun { get { return isRun; } }
        private bool isDead;
        public bool IsDead {  get { return isDead; } }
        public Player()
        {
            inventory = new Inventory();
            maxHP = 100;
            curHP = maxHP;
            menu = new Menu();
            isRun = false;
            isDead = false;
        }
        public void Heal(int amount)
        {
            curHP += amount;
            if(curHP >maxHP)
            {
                curHP = maxHP;
            }
        }
        public void PrintPlayer()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }
        public void PlayerAction(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    Move(input);
                    break;
                case ConsoleKey.Enter:
                    menu.OpenMenu();
                    break;
            }
        }
        public void Move(ConsoleKey input)
        {
            Vector2 tarPos = position;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    tarPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                    tarPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    tarPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                    tarPos.x++;
                    break;
            }
            if (map[tarPos.y, tarPos.x] == true)
            {
                position = tarPos;
            }
        }
    }
}
