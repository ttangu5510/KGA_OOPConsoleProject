using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Player
    {
        public Vector2 position;
        public bool[,] map;
        public Inventory inventory;

        private int curHP;
        private int maxHP;
        public int CurHP { get { return curHP; } }
        public int MaxHP { get { return maxHP; } }
        public Player()
        {
            inventory = new Inventory();
            maxHP = 100;
            curHP = maxHP;
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
        public void Move(ConsoleKey input)
        {
            Vector2 tarPos = position;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    tarPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    tarPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    tarPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
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
