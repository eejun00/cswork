using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0613
{
    public class Program
    {
        static void Main(string[] args)
        {
            CoinGame();
        }

        static void CoinGame()
        {
            int size = default;
            int point = 0; ;
            DateTime nowDate = DateTime.Today;
            Console.WriteLine("게임을 시작하기 전, 맵의 크기를 입력하여 주세요(5~15)");
            size = int.Parse(Console.ReadLine());

            while(!((size >= 5) && (size <= 15)))
            {
                Console.WriteLine("잘못된 값입니다. 다시 입력해주세요.");
                size = int.Parse(Console.ReadLine());
            }

            
            int x_axis = (size/2);
            int y_axis = (size/2);
            char[,] char2_ = new char[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == (size/2) && y == (size/2))
                    {
                        char2_[size/2,size/2] = '&';
                        continue;
                    }
                    if ((x == 0 || y == 0)|| (x == (size-1) || y == (size-1)))
                    {
                        char2_[y,x] = '#';
                        continue;
                    }

                    char2_[y,x] = '*';
                }
            }

            //출력 부분
            printmap(char2_, size, point);

            int coinCount = 0;
            int coinX = 0;
            int coinY = 0;
            Random random = new Random();
            int savesec = default;


            while (point < 15)
            {
                string second = System.DateTime.Now.ToString("ss");
                int coinsec = int.Parse(second);
                Console.WriteLine("{0} ", coinsec);
                
                if(savesec > (50+coinsec))
                {
                    savesec = default;
                }

                if (coinsec > savesec)
                {
                    do
                    {
                        coinX = random.Next(1, (size-2));
                        coinY = random.Next(1, (size-2));
                    }
                    while ((y_axis == coinY) && (x_axis == coinX));
                    char2_[coinY, coinX] = '@';

                    savesec = 2+coinsec;
                }


                ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용
                Console.Clear();
                switch (keyInput.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (x_axis <= 1)
                        {
                            printmap(char2_,size, point);
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                            break;
                        }
                        else
                        {
                            char2_[y_axis,x_axis] = '*';
                            if (char2_[y_axis, (x_axis-1)] == '@')
                            {
                                point += 1;
                            }
                            char2_[y_axis,--x_axis] = '&';                            
                            printmap(char2_, size, point);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x_axis < (size-2))
                        {
                            char2_[y_axis,x_axis] = '*';
                            if (char2_[y_axis, (x_axis+1)] == '@')
                            {
                                point += 1;
                            }
                            char2_[y_axis, ++x_axis] = '&';

                            printmap(char2_, size, point);
                        }
                        else
                        {
                            printmap(char2_, size, point);
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                        }

                        break;


                    case ConsoleKey.UpArrow:
                        if (y_axis <= 1)
                        {
                            printmap(char2_, size, point);
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");

                            break;
                        }
                        else
                        {
                            char2_[y_axis, x_axis] = '*';
                            if (char2_[(y_axis-1), x_axis] == '@')
                            {
                                point += 1;
                            }
                            char2_[--y_axis, x_axis] = '&';
                            printmap(char2_, size, point);
                        }
                        break;



                    case ConsoleKey.DownArrow:
                        if (y_axis < (size-2))
                        {
                            char2_[y_axis,x_axis] = '*';
                            if (char2_[(y_axis+1), x_axis] == '@')
                            {
                                point += 1;
                            }
                            char2_[++y_axis, x_axis] = '&';

                            printmap(char2_, size, point);
                        }
                        else
                        {

                            printmap(char2_, size, point);

                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                        }
                        break;

                    default:
                        printmap(char2_, size,point);
                        Console.WriteLine("\n\n입력이 잘못되었습니다.\n");
                        break;
                }

                //if (coinCount % 3 == 0)  //coin 생성 부분
                //{
                //    do
                //    {
                //        coinX = random.Next(1, (size-2));
                //        coinY = random.Next(1, (size-2));
                //    }
                //    while ((y_axis == coinY) && (x_axis == coinX));
                //    char2_[coinY, coinX] = '@';
                //}
                //coinCount += 1;
            }
            Console.Clear();
            printmap(char2_, size, point);
            Console.WriteLine("\n\n{0}번의 움직임으로 {1}개의 코인을 모두 모았습니다!\n\n",coinCount,point);
        }

        static void printmap(char[,] map,int size,int point)
        {
            Console.WriteLine("현재 먹은 코인의 갯수 : {0}\n\n", point);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map[y,x] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == '&')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("{0} ", map[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
