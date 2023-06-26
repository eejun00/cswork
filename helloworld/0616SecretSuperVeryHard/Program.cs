using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0616SecretSuperVeryHard
{
    public class Program
    {
        static void Main(string[] args)
        {
            SecretSuperVeryHard2048();
        }

        static void SecretSuperVeryHard2048()
        {
            int size = 4; // 맵 사이즈 변수
            Random random = new Random();
            int numX = 0;
            int numY = 0;
            int[] randomNum = new int[5] { 2, 2,2,2,4 };
            int maxX = size-1;
            int maxY = size-1;

            // 맵 사이즈 입력받는 부분
            //Console.WriteLine("게임을 시작하기 전, 맵의 크기를 입력하여 주세요(5~15)");
            //size = int.Parse(Console.ReadLine());

            //while (!((size >= 4) && (size <= 6)))
            //{
            //    Console.WriteLine("잘못된 값입니다. 다시 입력해주세요.");
            //    size = int.Parse(Console.ReadLine());
            //}

            // 기본 맵 생성하는 부분
            int[,] board = new int[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    board[y, x] = 0;
                }
            }

            printmap(board, size);

            while (true)
            {
                //종료 시 까지 무한반복

                ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용


                switch (keyInput.Key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine("\n\n\n게임을 종료합니다.");
                        return;

                    case ConsoleKey.RightArrow:
                        for(int y = 0; y < size; y++)
                        {                            
                            for(int x = 0; x < maxX; x++)
                            {
                                if (board[y, x] != 0)
                                {
                                    for (int z = x+1; z <= maxX; z++)
                                    {
                                        if( (board[y,z] !=0) && (board[y, x] != board[y, z]))
                                        {
                                            break;
                                        }
                                        else if (board[y,x] == board[y,z])
                                        {
                                            board[y, z] = board[y, z]*2;
                                            board[y, x] = 0;
                                            x = z+1;
                                            z++;
                                        }
                                    }
                                }                                                                                                                    
                            }

                            for(int x = maxX; x > 0 ; x--)
                            {
                                if(board[y,x] == 0)
                                {
                                    for (int z = x; z >= 0; z--)
                                    {
                                        if (board[y, z] !=0)
                                        {
                                            board[y, x] = board[y, z];
                                            board[y, z] = 0;
                                            break;
                                        }
                                    }
                                }
                            }                                                     
                        }

                        break;
                    case ConsoleKey.LeftArrow:
                        for (int y = 0; y < size; y++)
                        {
                            //int numCount = 0;
                            for (int x = maxX; x > 0; x--)
                            {
                                if (board[y, x] != 0)
                                {
                                    for (int z = x-1; z >= 0; z--)
                                    {
                                        if ((board[y, z] !=0) && (board[y, x] != board[y, z]))
                                        {
                                            break;
                                        }
                                        else if (board[y, x] == board[y, z])
                                        {
                                            board[y, z] = board[y, z]*2;
                                            board[y, x] = 0;
                                            x = z-1;
                                            z--;
                                        }
                                    }
                                }
                            }

                            for (int x = 0; x < maxX; x++)
                            {
                                if (board[y, x] == 0)
                                {
                                    for (int z = x; z <= maxX; z++)
                                    {
                                        if (board[y, z] !=0)
                                        {
                                            board[y, x] = board[y, z];
                                            board[y, z] = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        for (int x = 0; x < size; x++)
                        {
                            for (int y = maxY; y > 0; y--)
                            {
                                if (board[y, x] != 0)
                                {
                                    for (int z = y-1; z >= 0; z--)
                                    {
                                        if ((board[z, x] !=0) && (board[y, x] != board[z, x]))
                                        {
                                            break;
                                        }
                                        else if (board[y, x] == board[z, x])
                                        {
                                            board[z, x] = board[z, x]*2;
                                            board[y, x] = 0;
                                            y = z-1;
                                            z--;
                                        }
                                    }
                                }
                            }

                            for (int y = 0; y < maxY; y++)
                            {
                                if (board[y, x] == 0)
                                {
                                    for (int z = y; z <= maxY; z++)
                                    {
                                        if (board[z, x] !=0)
                                        {
                                            board[y, x] = board[z, x];
                                            board[z, x] = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        break;

                    case ConsoleKey.DownArrow:
                        for (int x = 0; x < size; x++)
                        {
                            for (int y = 0; y < maxY; y++)
                            {
                                if (board[y, x] != 0)
                                {
                                    for (int z = y+1; z <= maxY; z++)
                                    {
                                        if ((board[z, x] !=0) && (board[y, x] != board[z, x]))
                                        {
                                            break;
                                        }
                                        else if (board[y, x] == board[z, x])
                                        {
                                            board[z, x] = board[z, x]*2;
                                            board[y, x] = 0;
                                            y = z+1;
                                            z++;
                                        }
                                    }
                                }
                            }

                            for (int y = maxY; y > 0; y--)
                            {
                                if (board[y, x] == 0)
                                {
                                    for (int z = y; z >= 0; z--)
                                    {
                                        if (board[z, x] !=0)
                                        {
                                            board[y, x] = board[z, x];
                                            board[z, x] = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                bool fullBoard = false;
                //1을 생성하는 부분
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if (board[y,x] == 0)
                        {
                            fullBoard = true;
                        }
                    }
                }
                if (fullBoard)
                {
                    int randomIndex = random.Next(0, randomNum.Length);
                    do
                    {
                        numX = random.Next(0, size);
                        numY = random.Next(0, size);
                    }
                    while (board[numY, numX] != 0);
                    board[numY, numX] = randomNum[randomIndex];
                }

                //생성 후 출력 부분
                printmap(board, size);




            }
        }

        //맵 재출력시 사용하는 함수
        static void printmap(int[,] map, int size)
        {
            Console.Clear();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map[y, x] == 2 || (map[y, x] == 64))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }

                    if (map[y, x] == 4 || (map[y, x] == 128))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == 8 || (map[y, x] == 256))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == 16)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == 32)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("{0,4} ", map[y, x]);
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
