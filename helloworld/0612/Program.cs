using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0612
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Updown myUpdown = new Updown();
            myUpdown.UpdownGame();




            //Dog myDog = new Dog();
            //Console.WriteLine("우리집 강아지 이름은 {0} 이고, 다리 갯수는 {1}개 이다.",
            //    myDog.dogName, myDog.legCount);
            //myDog.Print_DogDescription();

            //Cat myCat = new Cat(4,"야옹이","검정색");
            //myCat.Print_MyCat();
            //myCat.catName = "새로운 야옹이";
            //myCat.Print_MyCat();

            //FirstMob myFirstMob = new FirstMob();
            //SecondMob mySecondMob = new SecondMob();
            //ThirdMob myThirdMob = new ThirdMob();

            //myFirstMob.Initilize("로이", "야수형", 30, 30, 5);
            //myFirstMob.Print_MonsterInfo();

            //myFirstMob.PrintFirstMob();
            //mySecondMob.PrintSecondMob();
            //myThirdMob.PrintThirdMob();



        }   //Main()

        public void Desc001()
        {
            string[] str = new string[2] { "Hello", "World" };
            //CallFunc002("Hello","World","+","Hello","World");
            //CallFunc003(ref str);

            string[] resultStr;
            CallFunc004(str, out resultStr);
            foreach (string result_ in resultStr)
            {
                Console.Write("{0} ", result_);
            }
            Console.WriteLine();
        }


        // 네 번째 방법도 매개변수를 Call by reference 방식으로 넘기는 방법인데
        // 매개변수를 통해서 값을 Return 한다.
        static void CallFunc004(string[] str, out string[] outStr) //out을 활용해서 값을 넘겨받음
        {
            string[] resultString = new string[str.Length + 1];

            for (int i = 0;i<str.Length; i++)
            {
                resultString[i] = str[i];
            }
            resultString[str.Length] = "!";
            outStr = resultString;
        }

        // 세 번째 방법은 매개변수를 Call by reference 방식으로 넘기는 방법
        static void CallFunc003(ref string[] str)
        {
            foreach (string strElement in str) // 몇번 반복하는지는 str이 정하는것
            {
                Console.Write("{0} ", strElement);
            }
            Console.WriteLine();
        }



        //두 번째 방법은 매개변수를 Call by value 방식으로 넘기는건 똑같음. 그런데
        // 넘겨줄 매개변수를 배열의 요소 형태로 여러개 넘길 수 있다.
        static void CallFunc002(params string[] str)
        {
            foreach (string strElement in str) // 몇번 반복하는지는 str이 정하는것
            {
                Console.Write("{0} ", strElement);
            }
            Console.WriteLine();
        }



        // 첫 번째 방법은 매개변수를 Call by value 방식으로 넘기는 방법
        static void CallFunc001(string[] str)
        {
            foreach (string strElement in str) // 몇번 반복하는지는 str이 정하는것
            {
                Console.Write("{0}", strElement);            
            }
            Console.WriteLine();
        }   // CallFunc001()
    }   // class Program
}
