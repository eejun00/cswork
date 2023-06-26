using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0619
{
    public class Parent
    {
        protected int number = default;
        protected string strValue = default;

        public virtual void PrintInfos()
        {
            number = 1;
            strValue = "This is Parent";
            Console.WriteLine("Parent class -> number: {0}, strValue: {1}",
                number, strValue);
        }
    }
}
