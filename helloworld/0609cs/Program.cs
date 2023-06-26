using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _0609cs
{
    public class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int[] lottos = new int[6];

            for(int i = 0; i < lottos.Length;i++)
            {
                lottos[i] = random.Next(1, 45);
            }
            foreach(int lotto_ in lottos)
            {
                //Task.Delay(1000).Wait();
                Thread.Sleep(1000);
                Console.Write("{0} ", lotto_);
                
            }
            
            Console.WriteLine();

            
            //Description001();
            //int[] numbers = new int[5];
            //int[,] numbers2 = new int[5, 5];

            //int valueCount = 0;
            //for(int y=0;y<5; y++)
            //{
            //    for (int x = 0; x < 5; x++)
            //    {
            //        valueCount += 1;
            //        numbers2[y, x] = valueCount;
                    
            //    }
            //}

            ////for (int y = 0; y < 5; y++)
            ////{
            ////    for (int x = 0; x < 5; x++)
            ////    {                   
            ////        Console.Write("{0} ",numbers2[y, x]);
            ////    }
            ////    Console.WriteLine();
            ////}
            //PrintMyArray(numbers2);
        }

        static void PrintMyArray(int[,] array_)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write("{0} ", array_[y, x]);
                }
                Console.WriteLine();
            }
        }
        
        static void Description001()
        {
            String userInput1 = default;
            String userInput2 = default;

            int userNumber1 = default;
            int userNumber2 = default;


            userInput1 = Console.ReadLine();
            userInput2 = Console.ReadLine();

            //userNumber1 = System.Convert.ToInt32(userInput1);
            //userNumber2 = System.Convert.ToInt32(userInput2);

            //userNumber1 = int.Parse(userInput1);
            //userNumber2 = int.Parse(userInput2);

            int.TryParse(userInput1, out userNumber1);
            int.TryParse(userInput2, out userNumber2);


            Console.WriteLine("{0} + {1} = {2} \n", userNumber1, userNumber2, userNumber1 + userNumber2);
            //Console.WriteLine("입력 받은 내용을 출력하고 싶어 -> {1}, {0}", userInput1,userInput2); // {0} >> 자리 표시자 0,1 순서로 출력
        }

    }
}
