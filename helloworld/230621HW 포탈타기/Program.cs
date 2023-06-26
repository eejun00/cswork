using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230621HW
{
    public class Program
    {
        static void Main(string[] args)
        {

            MapGame();
        }



        static void MapGame()
        {
            //클래스,변수 설정
            Map map1 = new Map();
            Shop shop1 = new Shop();
            CardGame card1 = new CardGame();
            Battle battle1 = new Battle();

            const int MAP_SIZE_X = 30;
            const int MAP_SIZE_Y = 15;
            const char PLAYER = '◎';
            const char MOUNTAIN = '▲';
            const char CARDGAME = '♥';
            const char SHOP = 'ⓒ';
            const char POTAL = '♨';
            int playerHp = 100;
            int point = 0;

            int y_axis = MAP_SIZE_Y/2;
            int x_axis = MAP_SIZE_X/2;
            List<Shopitem> inventory = new List<Shopitem>();
            int gold = 500;
            reset:
            //스위치문에서 R을 입력받았을 시 여기로 이동

            Console.SetWindowSize(100, 40);


            

            map1.CreateMap();


            // 기본 맵 생성하는 부분
            int mapNumber = 3;
            //기본이 3번방 
            //  2
            //1 3 5
            //  4

            //출력 부분
            status(gold, playerHp);
            map1.PrintMap();


            while (playerHp < 0 || gold < 3000)
            {

                ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용
               

                switch (keyInput.Key)
                {
                    case ConsoleKey.R:  //R입력시 리셋부분으로 이동
                        goto reset;

                    case ConsoleKey.LeftArrow:
                        if (x_axis <= 1)
                        {
                            if (map1.map[y_axis, (x_axis-1)] == '♨')   //포탈에 도착할 경우
                            {
                                if (mapNumber == 3)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    x_axis = MAP_SIZE_X-2;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '♨';
                                    map1.map[MAP_SIZE_Y/2, 0] = '□';
                                    map1.map[0, MAP_SIZE_X/2] = '□';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '□';
                                    mapNumber = 1;
                                    Console.Clear();
                                }
                                else if(mapNumber == 5)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    x_axis = MAP_SIZE_X-2;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '♨';
                                    map1.map[MAP_SIZE_Y/2, 0] = '♨';
                                    map1.map[0, MAP_SIZE_X/2] = '♨';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '♨';
                                    mapNumber = 3;
                                    Console.Clear();
                                }
                            }
                        }
                        else
                        {
                            if (x_axis > 1) // 이동 가능할 경우
                            {
                                if (map1.map[y_axis, (x_axis-1)] == 'ⓒ') // 상점 아이콘을 만날경우
                                {
                                    shop1.InStore(ref inventory, ref gold);
                                    Console.Clear();
                                }
                                else if(map1.map[y_axis, (x_axis-1)] == '▲') // 산에 도착할 경우
                                {
                                    battle1.battleStart(ref playerHp);
                                    Console.Clear();
                                }
                                else if(map1.map[y_axis, (x_axis-1)] == '♥') //카드 게임에 도착할 경우
                                {
                                    card1.StartGame(ref gold);
                                    Console.Clear();
                                }                              
                                else //그냥 이동시
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[y_axis, --x_axis] = PLAYER;
                                }
                            }


                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (x_axis < (MAP_SIZE_X-2)) // 이동 가능한 경우
                        {                          
                            if (map1.map[y_axis, (x_axis+1)] == 'ⓒ') // 상점 아이콘을 만날경우
                            {
                                shop1.InStore(ref inventory, ref gold);
                                Console.Clear();
                            }
                            else if (map1.map[y_axis, (x_axis+1)] == '▲') // 산에 도착할 경우
                            {
                                battle1.battleStart(ref playerHp);
                                Console.Clear();
                            }
                            else if (map1.map[y_axis, (x_axis+1)] == '♥') //카드 게임에 도착할 경우
                            {
                                card1.StartGame(ref gold);
                                Console.Clear();
                            }
                            else
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[y_axis, ++x_axis] = PLAYER;
                            }

                        }
                        else 
                        {
                            if (map1.map[y_axis, (x_axis+1)] == '♨')   //포탈에 도착할 경우
                            {

                                if(mapNumber == 3)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    x_axis = 1;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '□';
                                    map1.map[MAP_SIZE_Y/2, 0] = '♨';
                                    map1.map[0, MAP_SIZE_X/2] = '□';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '□';
                                    mapNumber = 5;
                                    Console.Clear();
                                }
                                else if (mapNumber == 1)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    x_axis = 1;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '♨';
                                    map1.map[MAP_SIZE_Y/2, 0] = '♨';
                                    map1.map[0, MAP_SIZE_X/2] = '♨';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '♨';
                                    mapNumber = 3;
                                    Console.Clear();
                                }
                            }
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (y_axis <= 1)
                        {
                            if (map1.map[y_axis-1,x_axis] == '♨')
                            {
                                if (mapNumber == 3)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    y_axis = MAP_SIZE_Y-2;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '□';
                                    map1.map[MAP_SIZE_Y/2, 0] = '□';
                                    map1.map[0, MAP_SIZE_X/2] = '□';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '♨';
                                    mapNumber = 2;
                                    Console.Clear();
                                }
                                else if(mapNumber == 4)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    y_axis = MAP_SIZE_Y-2;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '♨';
                                    map1.map[MAP_SIZE_Y/2, 0] = '♨';
                                    map1.map[0, MAP_SIZE_X/2] = '♨';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '♨';
                                    mapNumber = 3;
                                    Console.Clear();
                                }
                            }
                        }
                        else
                        {
                            if (map1.map[(y_axis-1), x_axis] == 'ⓒ') // 상점 아이콘을 만날경우
                            {
                                shop1.InStore(ref inventory, ref gold);
                                Console.Clear();
                            }
                            else if (map1.map[(y_axis-1), x_axis] == '▲')
                            {
                                battle1.battleStart(ref playerHp);
                                Console.Clear();
                            }
                            else if (map1.map[(y_axis-1), x_axis] == '♥')
                            {
                                card1.StartGame(ref gold);
                                Console.Clear();
                            }
                            else 
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[--y_axis, x_axis] = PLAYER;
                            }

                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (y_axis < (MAP_SIZE_Y-2))
                        {
                            if (map1.map[(y_axis+1), x_axis] == 'ⓒ') // 상점 아이콘을 만날경우
                            {
                                shop1.InStore(ref inventory, ref gold);
                                Console.Clear();
                            }
                            else if (map1.map[(y_axis+1), x_axis] == '▲')
                            {
                                battle1.battleStart(ref playerHp);
                                Console.Clear();
                            }
                            else if (map1.map[(y_axis + 1), x_axis] == '♥')
                            {
                                card1.StartGame(ref gold);
                                Console.Clear();
                            }
                            else
                            {
                                map1.map[y_axis, x_axis] = 'ㅤ';
                                map1.map[++y_axis, x_axis] = PLAYER;
                            }

                        }
                        else
                        {
                            if (map1.map[y_axis+1, x_axis] == '♨')
                            {
                                if (mapNumber == 3)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    y_axis = 1;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '□';
                                    map1.map[MAP_SIZE_Y/2, 0] = '□';
                                    map1.map[0, MAP_SIZE_X/2] = '♨';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '□';
                                    mapNumber = 4;
                                    Console.Clear();
                                }
                                else if(mapNumber == 2)
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    y_axis = 1;
                                    map1.map[y_axis, x_axis] = PLAYER;
                                    map1.map[MAP_SIZE_Y/2, MAP_SIZE_X-1] = '♨';
                                    map1.map[MAP_SIZE_Y/2, 0] = '♨';
                                    map1.map[0, MAP_SIZE_X/2] = '♨';
                                    map1.map[MAP_SIZE_Y-1, MAP_SIZE_X/2] = '♨';
                                    mapNumber = 3;
                                    Console.Clear();
                                }
                            }
                        }
                        break;
                    case ConsoleKey.I:
                        shop1.Printinven(inventory);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("\n\n입력이 잘못되었습니다.\n");
                        break;
                }

                status(gold, playerHp);
                map1.PrintMap();
                
              
            }
            Console.Clear();
            status(gold, playerHp);
            Console.WriteLine("\n\n여정을 마치고 게임을 종료합니다...\n\n");
        }

        static void status(int gold, int playerHp)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("나의 골드 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} gold", gold);
            Console.ResetColor();
            Console.Write("나의 체력 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("♥ {0}", playerHp);
            Console.ResetColor();
        }

    }
}

