using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0616
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberGame();
            
        }

        static void NumberGame()
        {
            //변수 선언
            int size = default;
            Random random = new Random();
            int numX = 0;
            int numY = 0;

            // 맵 사이즈 입력받는 부분
            Console.WriteLine("게임을 시작하기 전, 맵의 크기를 입력하여 주세요(5~15)");
            size = int.Parse(Console.ReadLine());

            while (!((size >= 5) && (size <= 15)))
            {
                Console.WriteLine("잘못된 값입니다. 다시 입력해주세요.");
                size = int.Parse(Console.ReadLine());
            }

            // 기본 맵 생성하는 부분
            string[,] board = new string[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {                    
                    board[y, x] = "*";
                }
            }

            printmap(board, size);

            while(true)
            {
                //종료 시 까지 무한반복

                ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용


                switch (keyInput.Key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine("\n\n\n게임을 종료합니다.");
                        return;


                    case ConsoleKey.RightArrow:

                        int eastNum = default;
                        for (int i = 0; i < size-1; i++)
                        {
                            for (int j = 0; j < size-1; j++)
                            {
                                if (board[i, j] == "1" && board[i, size-1] != "*")
                                {                                    
                                    eastNum = Int32.Parse(board[i, size-1]);
                                    eastNum += 1;
                                    board[i, size-1] = eastNum.ToString();
                                    board[i, j] = "*";
                                }
                                else if (board[i, j] == "1")
                                {
                                    board[i, j] = "*";
                                    board[i, size-1] = "1";
                                }
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        int southNum = default;
                        for (int j = 0; j < size-1; j++)
                        {
                            for (int i = 0; i < size-1; i++)
                            {
                                if (board[i, j] == "1" && board[size-1, j] != "*")
                                {
                                    southNum = Int32.Parse(board[size-1, j]);
                                    southNum += 1;
                                    board[size-1, j] = southNum.ToString();
                                    board[i, j] = "*";
                                }
                                else if (board[i, j] == "1")
                                {
                                    board[i, j] = "*";
                                    board[size-1, j] = "1";
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }

                //1을 생성하는 부분
                for (int i = 0; i <3; i++)
                {
                    do
                    {
                        numX = random.Next(0, size);
                        numY = random.Next(0, size);
                    }
                    while (board[numY, numX] != "*");
                    board[numY, numX] = "1";
                }

                //생성 후 출력 부분
                printmap(board, size);




            }




        }

        //맵 재출력시 사용하는 함수
        static void printmap(string[,] map, int size)
        {
            Console.Clear();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map[y, x] == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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
