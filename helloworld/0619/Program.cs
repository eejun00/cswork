using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0619
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parent myParent = new Parent();
            Child myChild = new Child();

            //myParent.PrintInfos();
            //myChild.PrintInfos();

            Parent tempParent = myChild;
            Child tempChild = (Child)tempParent;

            tempParent.PrintInfos();
            tempChild.PrintInfos();
        }
    }
}
