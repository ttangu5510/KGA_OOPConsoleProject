﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public class TestScene1 : BaseScene
    {
        private ConsoleKey input;
        public override void Render()
        {
            Console.WriteLine("테스트 1씬");
            Console.WriteLine();
            Console.WriteLine("테스트 2씬 이동");
            Console.WriteLine("테스트 3씬 이동");
            Console.WriteLine("선택지 입력:");

        }

        public override void Input()
        {
           input = Console.ReadKey().Key;
        }

        public override void Update()
        {
            switch(input)
            {
                case ConsoleKey.D2:
                    GameManager.ChangeScene("TestScene2");
                    break;
                case ConsoleKey.D3:
                    GameManager.ChangeScene("TestScene3");
                    break;
            }
        }

        public override void Result()
        {

        }

    }
}
