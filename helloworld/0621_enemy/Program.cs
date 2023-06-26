using _0621_enumy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _0621_enemy
{
    public class Program
    {
        static void Main(string[] args)
        {
            EnemyGame();
        }

        static void EnemyGame()
        {
            //클래스,변수 설정
            Map map1 = new Map();

            const int MAP_SIZE_X = 30;
            const int MAP_SIZE_Y = 15;
            const char PLAYER = '◎';
            const char ENEMY = '★';
            int score = 0;
            int bestScore = 128;

            int y_axis = MAP_SIZE_Y/2;
            int x_axis = MAP_SIZE_X/2;

            int enemyNum = 0;
            //List<int> enemyX = new List<int>();
            int[] enemyX = new int[100];
            //List<int> enemyY = new List<int>();
            int[] enemyY = new int[100];
            int endNum = 0;

            int wallX = 0;
            int wallY = 0;
            int wallRandom = 0;
            Random random = new Random();

            Console.SetWindowSize(100, 40);

            map1.CreateMap();
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i <26; i += 5)
                {
                    
                    do
                    {
                        wallX = random.Next(i+1,i+3);
                        wallY = random.Next(j+1, j+4);
                    }
                    while (((y_axis == wallY) && (x_axis == wallX)));
                    wallRandom = random.Next(1,4);
                    if (wallRandom % 3 == 0)
                    {
                        map1.map[wallY, wallX] = '□';
                        map1.map[wallY, wallX+1] = '□';
                        map1.map[wallY, wallX+2] = '□';
                    }
                    else if (wallRandom % 3 == 1)
                    {
                        map1.map[wallY, wallX] = '□';
                        map1.map[wallY+1, wallX] = '□';
                        map1.map[wallY+2, wallX] = '□';
                    }
                    else
                    {
                        map1.map[wallY, wallX] = '□';
                        map1.map[wallY+1, wallX] = '□';
                        map1.map[wallY, wallX+1] = '□';
                    }
                   
                }
                j += 3;
            }

            PrintScore(bestScore, score);
            map1.PrintMap();
            while (true)
            {

                while (true)
                {
                    endNum= 0;
                    ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용

                    if (score % 10 == 2) // 적생성 부분
                    {
                        do
                        {
                            enemyX[enemyNum] = random.Next(1, (MAP_SIZE_X-2));
                            enemyY[enemyNum] = random.Next(1, (MAP_SIZE_Y-2));
                        }
                        while (((y_axis == enemyY[enemyNum]) && (x_axis == enemyX[enemyNum])) || map1.map[enemyY[enemyNum], enemyX[enemyNum]] == '□');
                        map1.map[enemyY[enemyNum], enemyX[enemyNum]] = '★';
                        enemyNum++;
                    }






                    //적 이동 구문
                    for (int i = 0; i < enemyNum; i++)
                    {
                        if (Math.Abs(enemyX[i]-x_axis) > Math.Abs(enemyY[i]-y_axis))
                        {
                            if (enemyX[i]<x_axis)
                            {
                                if (map1.map[enemyY[i], enemyX[i]+1] == '□' || map1.map[enemyY[i], enemyX[i]+1] == '★')
                                {
                                    /*Pass*/
                                }
                                else
                                {
                                    map1.map[enemyY[i], enemyX[i]] = 'ㅤ';
                                    map1.map[enemyY[i], ++enemyX[i]] = ENEMY;
                                }
                            }
                            else
                            {
                                if (map1.map[enemyY[i], enemyX[i]-1] == '□'|| map1.map[enemyY[i], enemyX[i]-1] == '★')
                                {
                                    /*Pass*/
                                }
                                else
                                {
                                    map1.map[enemyY[i], enemyX[i]] = 'ㅤ';
                                    map1.map[enemyY[i], --enemyX[i]] = ENEMY;
                                }
                            }
                        }
                        else
                        {

                            if (enemyY[i]<y_axis)
                            {
                                if (map1.map[enemyY[i]+1, enemyX[i]] == '□' || map1.map[enemyY[i]+1, enemyX[i]] == '★')
                                {
                                    /*Pass*/
                                }
                                else
                                {
                                    map1.map[enemyY[i], enemyX[i]] = 'ㅤ';
                                    map1.map[++enemyY[i], enemyX[i]] = ENEMY;
                                }
                            }
                            else
                            {
                                if (map1.map[enemyY[i]-1, enemyX[i]] == '□'|| map1.map[enemyY[i]-1, enemyX[i]] == '★')
                                {
                                    /*Pass*/
                                }
                                else
                                {
                                    map1.map[enemyY[i], enemyX[i]] = 'ㅤ';
                                    map1.map[--enemyY[i], enemyX[i]] = ENEMY;
                                }
                            }

                        }
                    }

                    if (map1.map[y_axis, x_axis] == '★')
                    {
                        break;
                    }

                    switch (keyInput.Key)   //플레이어 이동
                    {
                        case ConsoleKey.LeftArrow:
                            if (map1.map[y_axis, (x_axis-1)] == '★')
                            {
                                break;
                            }
                            if (map1.map[y_axis, (x_axis-1)] == '□')
                            {
                                /*Pass*/
                            }
                            else
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[y_axis, --x_axis] = PLAYER;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (map1.map[y_axis, (x_axis+1)] == '★')
                            {
                                break;
                            }
                            if (map1.map[y_axis, (x_axis+1)] == '□')
                            {
                                /*Pass*/
                            }
                            else
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[y_axis, ++x_axis] = PLAYER;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (map1.map[y_axis-1, x_axis] == '★')
                            {
                                break;
                            }
                            if (map1.map[y_axis-1, x_axis] == '□')
                            {
                                /*Pass*/
                            }
                            else
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[--y_axis, x_axis] = PLAYER;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (map1.map[y_axis+1, x_axis] == '★')
                            {
                                break;
                            }
                            if (map1.map[y_axis+1, x_axis] == '□')
                            {
                                /*Pass*/
                            }
                            else
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[++y_axis, x_axis] = PLAYER;
                            }
                            break;
                        default:
                            Console.WriteLine("\n\n입력이 잘못되었습니다.\n");
                            break;
                    }

                    score++;
                    PrintScore(bestScore, score);
                    map1.PrintMap();
                }
                Console.WriteLine("적에게 잡혔습니다...");
                if (score > bestScore)
                {
                    bestScore = score;
                }
                Console.WriteLine("이번 게임의 스코어 : {0} \n현재 베스트 스코어 {1}", score, bestScore);
                Task.Delay(1000);
                Console.WriteLine("\n게임을 계속하려면 y, 종료하시려면 q를 눌러주세요.");
                while (endNum < 1)
                {
                    string answer = Console.ReadLine();

                    switch (answer[0])
                    {
                        case 'y':
                            endNum = 1;
                            enemyNum = 0;
                            map1.CreateMap();
                            for (int j = 0; j < 10; j++)
                            {
                                for (int i = 0; i <26; i += 5)
                                {

                                    do
                                    {
                                        wallX = random.Next(i+1, i+3);
                                        wallY = random.Next(j+1, j+4);
                                    }
                                    while (((y_axis == wallY) && (x_axis == wallX)));
                                    wallRandom = random.Next(1, 4);
                                    if (wallRandom % 3 == 0)
                                    {
                                        map1.map[wallY, wallX] = '□';
                                        map1.map[wallY, wallX+1] = '□';
                                        map1.map[wallY, wallX+2] = '□';
                                    }
                                    else if (wallRandom % 3 == 1)
                                    {
                                        map1.map[wallY, wallX] = '□';
                                        map1.map[wallY+1, wallX] = '□';
                                        map1.map[wallY+2, wallX] = '□';
                                    }
                                    else
                                    {
                                        map1.map[wallY, wallX] = '□';
                                        map1.map[wallY+1, wallX] = '□';
                                        map1.map[wallY, wallX+1] = '□';
                                    }

                                }
                                j += 3;
                            }
                            enemyX = new int[30];
                            enemyY = new int[30];
                            y_axis = MAP_SIZE_Y/2;
                            x_axis = MAP_SIZE_X/2;
                            score = 0;
                            Console.Clear();
                            PrintScore(bestScore, score);
                            map1.PrintMap();
                            break;
                        case 'q':
                            Console.WriteLine("이번 게임의 최고 점수는 <{0}점> 이었습니다.", bestScore);
                            Console.WriteLine("게임이 종료됩니다.");
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            break;

                    }
                }
            }
        }
        static void PrintScore(int bestScore,int score)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("현재 베스트 스코어 : ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("BestScore : {0} ", bestScore);
            Console.ResetColor();
            Console.Write("이번 게임 나의 점수 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Score : {0}", score);
            Console.ResetColor();
        }
    }
}
