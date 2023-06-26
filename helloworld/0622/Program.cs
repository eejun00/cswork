using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0622
{
    public class Program
    {
        static void Main(string[] args)
        {
            //튜플 선언하는 법
            //(int xPos, int yPos) playerPosition = (0, 1);
            //playerPosition.xPos = 10;
            //playerPosition.yPos = 20;

            //Console.WriteLine("playerPosition : {0} , {1}",playerPosition.xPos , playerPosition.yPos);
            //(playerPosition.xPos, playerPosition.yPos) = (playerPosition.yPos, playerPosition.xPos);
            //Console.WriteLine("playerPosition : {0} , {1}", playerPosition.xPos, playerPosition.yPos);

            Desc001();

        }

        static void Desc002()
        {
            string strValue = "I am a boy";
            string[] strArray = strValue.Split(' ');

            Console.WriteLine("몇 개로 Split 되었는가? -> {0}", strArray.Count());
            Console.WriteLine();

            foreach (string str in strArray)
            {
                Console.WriteLine(str);
            }
        }

        static void Desc001()
        {
            List<int> intList = new List<int>();
            CustomClass customClass = new CustomClass();
            CustomClass customClass2 = null;

            CustomChild customChild = new CustomChild();
            CustomChild customChild2 = default;
            CustomChild customChild3 = new CustomChild();


            customChild2 = customChild; // 얕은 복사다 (바로가기 같은것)


            customChild.Initialize(0, 1);
            customChild3.Initialize(customChild.xPos,customChild.yPos);

            customChild2.PrintPosition();

            PrintValue(customChild);

            customChild = null;
            if(customChild == null)
            {
                Console.WriteLine("customchild는 null 입니다.");
            }
            else
            {
                customChild.PrintPosition();
            }

            customChild?.PrintPosition();
        }

        static void PrintValue<T>(T anyValue) where T : CustomClass
        {
            anyValue.PrintPosition();
        }

        //static void PrintValue(int intValue)
        //{
        //    Console.WriteLine("정수형 매개변수로 넘겨받은 값을 출력했다. -> {0}", intValue);
        //}
        //static void PrintValue(float intValue)
        //{
        //    Console.WriteLine("실수형 매개변수로 넘겨받은 값을 출력했다. -> {0}", intValue);
        //}
        //static void PrintValue(string intValue)
        //{
        //    Console.WriteLine("문자열 매개변수로 넘겨받은 값을 출력했다. -> {0}", intValue);
        //}
    }
}
