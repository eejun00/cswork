using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230613HW
{
    public class Program
    {
        static char Player = 'X';
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        

        public static void Main(string[] args)
        {          
            
            bool gameEnd = false;
            int moves = 0;
            Random random = new Random();

            while (!gameEnd && moves < 9)   //게임엔드가 거짓이고, moves가 9미만이면 게임 진행 반복
            {
                PrintTTT(board);
                Console.WriteLine("틱택토 게임입니다~ 한줄 빙고를 먼저 완성하는 쪽이 승리합니다! \n당신의 턴입니다.");

                if (Player == 'X')  //플레이어 턴
                {
                    Console.Write("숫자를 입력해주세요.");
                    int move;

                    while (true)    //잘못된 입력일 경우 반복해서 입력을 다시받음
                    {
                        bool Input = int.TryParse(Console.ReadLine(), out move);

                        if (Input && move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
                        {
                            break;
                        }

                        Console.WriteLine("잘못된 입력입니다. 1-9중의 숫자중 가능한 자리의 번호를 다시 입력해주세요. ");
                    }

                    board[move - 1] = Player;
                }
                else   // 컴퓨터 턴            
                {
                    int move;

                    move = random.Next(1, 10);

                    while (board[move - 1] == 'X' || board[move - 1] == 'O')
                    {
                        move = random.Next(1, 10);
                    }
                        Console.WriteLine("컴퓨터가 랜덤한 자리에 놓습니다.");
                    board[move - 1] = Player;
                }

                moves++;

                if (WinCondition(board))
                {
                    gameEnd = true;
                    PrintTTT(board);
                    if (Player == 'X')
                    {
                        Console.WriteLine("당신이 이겼습니다!!");
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터가 이겼습니다..");
                    }
                }
                else if (moves == 9)    //무승부 조건
                {
                    gameEnd = true;
                    PrintTTT(board);
                    Console.WriteLine("자리를 전부 채웠지만 빙고를 완성하지 못했습니다.. 무승부입니다..");
                }
                else
                {
                    Player = Player == 'X' ? 'O' : 'X'; //플레이어가 X 컴퓨터가 O X였을경우 O로, O였을 경우 X로 바꾼다.
                }
            }

            Console.WriteLine("아무키나 입력하여 게임을 종료하여 주세요.");
            Console.ReadKey();
        }

        static void PrintTTT(char[] board) // 틱택토 보드판 출력함수
        {
            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ",board[3], board[4], board[5]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ",board[6], board[7], board[8]);
            Console.WriteLine("   |   |   ");
        }

        static bool WinCondition(char[] board)  // 승리 조건을 전부 엮은 bool함수
        {
            return (board[0] == Player && board[1] == Player && board[2] == Player) ||
                   (board[3] == Player && board[4] == Player && board[5] == Player) ||
                   (board[6] == Player && board[7] == Player && board[8] == Player) ||
                   (board[0] == Player && board[3] == Player && board[6] == Player) ||
                   (board[1] == Player && board[4] == Player && board[7] == Player) ||
                   (board[2] == Player && board[5] == Player && board[8] == Player) ||
                   (board[0] == Player && board[4] == Player && board[8] == Player) ||
                   (board[2] == Player && board[4] == Player && board[6] == Player);
        }
    }
}
