using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0619
{
    public class Child : Parent
    {
        string strChild = default;

        public override void PrintInfos()
        {
            base.PrintInfos();

            number = 10;
            strValue = "This is Child";
            strChild = "Sentences of child added";
            Console.WriteLine("Parent class -> number: {0}, strValue: {1}, strChid: {2}",
                number, strValue,strChild);
        }
    }
}
