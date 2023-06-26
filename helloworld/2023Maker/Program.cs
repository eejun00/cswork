using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023Maker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Maker();
        }

        static void Maker()
        {
            State state = new State();
            //Console.CursorVisible = false;
            ConsoleScreen screen = new ConsoleScreen();

            Console.SetWindowSize(150, 50);
            screen.StartScreen();
            screen.Status(state);
            screen.MainScreen();
        }
    }
}
