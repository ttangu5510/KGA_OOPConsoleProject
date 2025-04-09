﻿using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace KGA_OOPConsoleProject
{
    public class Player
    {
        // 플레이어 세팅
        public Vector2 position;
        public bool[,] map;
        private Inventory inventory;
        private Menu menu;
        public Menu Menu { get { return menu; } }
        public Inventory Inventory { get { return inventory; } }
        private Skill[] skills;

        // 플레이어 스탯
        private int power;
        public int Power { get { return power; } }
        private int defence;
        public int Defence { get { return defence; } }
        private int speed;
        public int Speed { get { return speed; } }
        private int curHP;
        private int maxHP;
        public int CurHP { get { return curHP; } }
        public int MaxHP { get { return maxHP; } }
        private int mp;
        public int MP { get { return mp; } }
        private int maxMP;
        public int MaxMP { get { return maxMP; } }

        // 필드 상호작용
        public Vector2 nextObj;

        // 상태
        public bool isBattle;
        private bool isRun;
        public bool IsRun { get { return isRun; } set { isRun = value; } }
        private bool isDead;
        public bool IsDead { get { return isDead; } }


        //스프라이트
        public string[] playerSprite =
{
                     "   ____    _   ",
                     "  | ◑ ◑|  / /  "  ,
                     "  └  ^ / / /   "  ,
                     "  |\\  _|/ /_   " ,
                     "  | \\=  /      " ,
                     " /  / \\  \\     ",
                     "/__ /  \\___\\   "
            };
        public Player()
        {
            inventory = new Inventory();
            menu = new Menu();
            isRun = false;
            isDead = false;
            isShop = false;

            maxHP = 100;
            curHP = maxHP;
            maxMP = 15;
            mp = maxMP;
            power = 1;
            defence = 0;
            speed = 5;
            nextObj.x= 0;
            nextObj.y= 0;
        }
        public void HPHeal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
            {
                curHP = maxHP;
            }
        }
        public void MPHeal(int amount)
        {
            mp += amount;
            if (mp > maxMP)
            {
                mp = maxMP;
            }
        }
        public void PrintPlayer()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('ℓ');
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
            nextObj = tarPos;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    tarPos.y--;
                    nextObj.y -= 2;
                    if(nextObj.y < 1)
                    {
                        nextObj.y = 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    tarPos.y++;
                    nextObj.y += 2;
                    if(nextObj.y > 8 )
                    { 
                        nextObj.y = 8; 
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    tarPos.x--;
                    nextObj.x -= 2;
                    if(nextObj.x < 1)
                    {
                        nextObj.x = 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    tarPos.x++;
                    nextObj.x += 2;
                    if(nextObj.x > 49 )
                    {
                        nextObj.x = 49;
                    }
                    break;
            }
            if (map[tarPos.y, tarPos.x] == true)
            {
                position = tarPos;
            }
            else
            {
                nextObj = tarPos;
            }
        }
        // 플레이어 공격
        public int PlayerAttack()
        {
            Util.PrintText("플레이어의 공격!!");
            return power;
        }
        // 플레이어 스킬 사용 TODO
        public int PlayerSkill()
        {
            Util.PrintText("플레이어의 스킬!");
            return power;
        }
        // 플레이어 가드
        public void PlayerGuard()
        {
            defence += defence;
        }
        //플레이어 가드 해제
        public void PlayerUnGuard()
        {
            defence -= defence;
        }
        // 플레이어 피격
        public void PlayerHit(int damage)
        {
            curHP -= damage;
            if (curHP <= 0)
            {
                isDead = true;
            }
        }
        // 플레이어가 도망칠 경우
        public void PlayerRun()
        {
            isRun = true;
        }
        // 체력이 다 닳을 경우
        public void PlayerDead()
        {
            if (curHP<=0)
            {
                isDead = true;
            }
        }
        // 전투 씬에서 플레이어 그리기
        public void PlayerSprite(int pX, int pY)
        {
            for (int i = 0; i < playerSprite.Length; i++)
            {
                Console.SetCursorPosition(pX, pY + i);
                Console.Write(playerSprite[i]);
            }
        }
    }
}
