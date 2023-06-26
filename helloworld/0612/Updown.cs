using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _0612
{
    public class Updown
    {       
       

        public void UpdownGame()
        {
            Random rnd = new Random();
            int secretNum = rnd.Next(65, 90);
            int count = 0;
            int point = 1000;
            char[] code = new char[25];

            while (true)
            {
                Console.Clear();
                Console.WriteLine("현재 내가 도전한 횟수 : {0}회", count);
                Console.WriteLine("현재 나의 점수 : {0}\n", point);
                Console.WriteLine("내가 지금까지 입력한 정답");
                for (int i = 0; i<count; i++)
                {
                    Console.Write("{0}, ", code[i]);
                }
                Console.WriteLine("\n\n컴퓨터가 감추고 있는 대문자는 무엇일까요오옹???");
                char myAnswer = Convert.ToChar(Console.ReadLine());
                //char myAnswer = Console.ReadLine()[0];
                code[count] = myAnswer;
                int answer = Convert.ToInt32(myAnswer);
                Console.WriteLine();

                if (answer < secretNum)
                {
                    Console.WriteLine("입력하신 대문자 [{0}]          UP",myAnswer);
                }
                else if (answer > secretNum)
                {
                    Console.WriteLine("입력하신 대문자 [{0}]           DOWN ",myAnswer);
                }
                else
                {
                    Console.WriteLine("정답은 {0} 였습니다 축하합니다!!",(char)secretNum);
                    return;
                }

                Console.WriteLine("\n아무키나 입력하시면 다음턴으로 넘어갑니다.");
                Console.ReadLine();
                count += 1;
                point -= 100; 
            }
        }
    }
}
