using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_230614
{
    public class StoneMoveGame
    {
        Random rand = new Random();
        int userInput = 0;

        public void Map()
        {
           
            while (true)
            {
                Console.WriteLine(" 맵의 크기를 적어주세요 5 - 15 : ");
                userInput = Convert.ToInt32(Console.ReadLine());     // 문자열을 정수로 출력한다. ReadKey는 하나의 키 값만 받지만 ( 1자리수 ) ,
                                                                     // ReadLine은 여러개의 문자열을 정수로 변환해준다.
                Console.Clear();
                if (userInput >= 5 && userInput <= 15)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(" 올바른 값을 적어주세요");

                }
            }

            //Console.SetWindowSize(75, 20); // 콘솔창 크기
            char[,] star = new char[17, 17];
            int pointX = userInput / 2;         //수정한 부분 선언 밑으로 내렸음
            int pointY = userInput / 2;         //수정한 부분 선언 밑으로 내렸음


            for (int i = 0; i < userInput + 2; i++)
            {
                for (int j = 0; j < userInput + 2; j++)
                {
                    star[i, j] = '　';

                    if (i == 0 || j == 0)
                    {
                        star[i, j] = '□';
                    }

                    else if (i == userInput + 1 || userInput + 1 == j)
                    {
                        star[i, j] = '□';
                    }

                    if (i == userInput / 2  && j == userInput / 2 )     //수정한 부분 userInput / 2+1 에서 +1 삭제 +1 추가시 하트 시작점이 달라져서 2개가 돼요
                    {                                                   
                        star[i, j] = '♡';
                    }
                }
            }
            while (true)
            {
                for (int y = 0; y < userInput + 2; y++)
                {
                    for (int x = 0; x < userInput + 2; x++)
                    {
                        if (star[y, x] == '□')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" {0} ", star[y, x]);
                            Console.ResetColor();
                        }
                        else if (star[y, x] == '♡')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" {0} ", star[y, x]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" {0} ", star[y, x]);

                        }
                    }
                    Console.WriteLine("\n");
                }
                //Move(pointX, pointY, userInput, star);
                ConsoleKey userMove = Console.ReadKey(true).Key;    //수정한 부분 함수내용 그냥 합쳤음

                switch (userMove)
                {

                    case ConsoleKey.A:
                        if (pointX > 0)
                        {
                            star[pointY, pointX] = '　';
                            star[pointY, pointX - 1] = '♡';
                            pointX--;
                        }
                        break;
                    case ConsoleKey.D:
                        if (userInput > pointX)
                        {
                            star[pointY, pointX] = '　';
                            star[pointY, pointX + 1] = '♡';
                            pointX++;
                        }
                        break;
                    case ConsoleKey.W:
                        if (pointY > 0)
                        {
                            star[pointY, pointX] = '　';
                            star[pointY - 1, pointX] = '♡';
                            pointY--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (userInput > pointY)
                        {
                            star[pointY, pointX] = '　';
                            star[pointY + 1, pointX] = '♡';
                            pointY++;
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear(); //수정한 부분 키입력시마다 화면 지우고 재출력
            }
            
        }

        public void Move(int pointX, int pointY, int userInput, char[,] star)
        {

            pointX = userInput / 2;
            pointY = userInput / 2;

            ConsoleKey userMove = Console.ReadKey(true).Key;

            switch (userMove)
            {

                case ConsoleKey.A:
                    if (pointX > 0)
                    {
                        star[pointY, pointX] = ' ';
                        star[pointY, pointX - 1] = '♡';
                        pointX--;
                    }
                    break;
                case ConsoleKey.D:
                    if (userInput > pointX)
                    {
                        star[pointY, pointX] = ' ';
                        star[pointY, pointX + 1] = '♡';
                        pointX++;
                    }
                    break;
                case ConsoleKey.W:
                    if (pointY > 0)
                    {
                        star[pointY, pointX] = ' ';
                        star[pointY - 1, pointX] = '♡';
                        pointY--;
                    }
                    break;
                case ConsoleKey.S:
                    if (userInput > pointY)
                    {
                        star[pointY, pointX] = ' ';
                        star[pointY + 1, pointX] = '♡';
                        pointY++;
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
