using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2023Maker
{
    public class ConsoleScreen
    {
        State state = new State();
        public void StartScreen()   // 시작화면 기능만 있음. 시간날때 꾸미기
        {
            Console.SetCursorPosition(15, 30);
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 35; i++)
            {
                Console.WriteLine("                                                                                                                                                                                                                     ");
                Thread.Sleep(20);
            }
        }

        public void Status<T>(T state) where T : State // 날짜, 스탯 출력하는 함수
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("  오늘의 날짜      ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}일차\n",state.date);
            Console.Write("레벨");
            Console.ResetColor();
            Console.Write("  체력 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥ {0}   ", state.strength);
            Console.ResetColor();            
            Console.Write("매력 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("♬ {0}   ", state.charm);
            Console.ResetColor();
            Console.Write("지능 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("◆ {0}   ", state.intelligence);
            Console.ResetColor();
            Console.Write("도덕성 ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("♣ {0}   ", state.intelligence);
            Console.ResetColor();
            Console.Write("스트레스 ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("♨ {0}", state.intelligence);
            Console.ResetColor();


            Console.WriteLine("");
        }

        public void MainScreen()    //메인 스크린 디자인 출력 함수
        {
            Console.SetCursorPosition(82, 5);
            Console.Write("┐");
            Console.SetCursorPosition(1, 5);
            Console.Write("┌");
            Console.SetCursorPosition(1, 36);
            Console.Write("└");
            Console.SetCursorPosition(82, 36);
            Console.Write("┘");
            Console.SetCursorPosition(1, 47);
            Console.Write("└");
            Console.SetCursorPosition(82, 47);
            Console.Write("┘");
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(2+i, 5);
                Console.Write("━");
                Console.SetCursorPosition(2+i, 36);
                Console.Write("━");
                Console.SetCursorPosition(2+i, 47);
                Console.Write("━");
                //Thread.Sleep(1);
                if (i <= 40)
                {
                    Console.SetCursorPosition(0, i+6);
                    Console.Write(" │");
                    Console.SetCursorPosition(82, i+6);
                    Console.Write("│");
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine();
        }

    }
}
