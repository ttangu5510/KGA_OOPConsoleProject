using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    // 인풋 중첩 선입력을 막기 위한 클래스
    public static class InputHelp
    {
        //// 현재 시간을 나타내는 DateTime 구조체를 사용한다
        //private static DateTime inputTime = DateTime.MinValue;
        //private static readonly TimeSpan coolTime = TimeSpan.FromMilliseconds(300); // 쿨타임 설정
       
        ////콘솔 키 입력을 true로 받아야 콘솔창에 출력 되지 않으므로, 아예 미리 true로 값을 설정
        //public static ConsoleKey InputKey(bool intercept = true)
        //{
        //    // 함수 실행 시 키 입력이 있을 때 까지 대기하는 것은 기존과 같음
        //    while (true)
        //    {
        //        // 키가 입력되고, 현재시간에서 내가 입력한 시간을 뺐을 때(당연히 양수가 나옴)
        //        // 이 값이 미리 정해둔 쿨타임보다 커야지 입력으로 받음
        //        // 즉, 쿨타임보다 더 빠른 시간안에 들어온 입력들은 다 무시됨
        //        if (Console.KeyAvailable && DateTime.Now - inputTime > coolTime)
        //        {
        //            inputTime = DateTime.Now;
        //            return Console.ReadKey(intercept).Key;
        //        }

        //        Thread.Sleep(100); // CPU 낭비 방지
        //    }
        //}

        public static ConsoleKey InputKey(bool intercept = true)
        {
            // 먼저, 반환할 값을 저장한다
            ConsoleKey input = Console.ReadKey(intercept).Key;
            // 손을 뗄 때까지, 컴퓨터 버퍼에 쌓이는 키 입력을 함수로 처리한다
            while (Console.KeyAvailable)
            {
                // 입력받은 키들을 싹 다 함수로 처리함
                Console.ReadKey(intercept);
            }

            // 이제 키 입력된 값들의 버퍼는 비워졌다. 값을 반환하자
            return input;
        }
    }
}
