using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0614
{
    public class Print001   //클래스의 접근 수준이 Public
        
    {
        static public string staticMessage = default; //이게되네
        private string message = default; //캡슐화

        public void PrintMassage(string localMessage)   //메서드의 접근 수준도 public
        {
            message =localMessage;
            Console.WriteLine("이런걸 출력할 것 -> {0}", message);
        }   //PrintMessage()

        public static void PrintMassage()
        {
            Print002.PrintMassage("static 메서드에서 인스턴스 필드를 찍어볼 수 있을까? -> ");
        }
    }

}
