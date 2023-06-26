using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0622questBush
{
    public class Program
    {
        static void Main(string[] args)
        {
            RpgGame();
        }

        static void RpgGame()
        {
            Map map1 = new Map();
            Quest quest = new Quest();
            Battle battle1 = new Battle();
            Random random = new Random();

            const int MAP_SIZE_X = 30;
            const int MAP_SIZE_Y = 15;
            const char PLAYER = '◎';
            int playerHp = 100;
            int y_axis = MAP_SIZE_Y/2;
            int x_axis = MAP_SIZE_X/2;
            int surprise = default;

            Console.SetWindowSize(100, 40);

            map1.CreateMap();
            map1.PrintMap();
            status(quest, playerHp);

            while(true)
            {
                Console.CursorVisible = false;
                ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용

                switch (keyInput.Key)
                {
                    
                    case ConsoleKey.LeftArrow:
                        if (x_axis <= 1)
                        {
                            /*Pass*/
                        }
                        else
                        {
                            if (x_axis > 1) // 이동 가능할 경우
                            {
                                if (map1.map[y_axis, (x_axis-1)] == 'ⓝ') // NPC 아이콘을 만날경우
                                {
                                    if (quest.questBeing == 0 && quest.TalkNpc())
                                    {
                                        quest.AcceptQuest();
                                    }
                                    else if (quest.questBeing == 3 && quest.TalkNpc())
                                    {
                                        quest.AcceptQuest2();
                                    }
                                    else
                                    {
                                        quest.TalkNpc();
                                    }
                                    Console.Clear();
                                }
                                else if (map1.map[y_axis, (x_axis-1)] == '▲') // 산에 도착할 경우
                                {
                                    if((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                    {
                                        map1.map[y_axis, x_axis] = '▲';
                                        map1.map[y_axis, --x_axis] = PLAYER;
                                    }
                                    else
                                    {
                                        map1.map[y_axis, x_axis] = 'ㅤ';
                                        map1.map[y_axis, --x_axis] = PLAYER;
                                    }
                                    surprise = random.Next(1,101);
                                    if (surprise <= 17)
                                    {
                                        battle1.BattleStart(ref playerHp);
                                        if (quest.questName != default)
                                        {
                                            quest.questCount++;
                                        }
                                    }
                                    Console.Clear();
                                }

                                else //그냥 이동시
                                {
                                    if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                    {
                                        map1.map[y_axis, x_axis] = '▲';
                                        map1.map[y_axis, --x_axis] = PLAYER;
                                    }
                                    else
                                    {
                                        map1.map[y_axis, x_axis] = 'ㅤ';
                                        map1.map[y_axis, --x_axis] = PLAYER;
                                    }
                                }
                            }


                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (x_axis < (MAP_SIZE_X-2)) // 이동 가능한 경우
                        {
                            if (map1.map[y_axis, (x_axis+1)] == 'ⓝ') // NPC 아이콘을 만날경우
                            {
                                if (quest.questBeing == 0 && quest.TalkNpc())
                                {
                                    quest.AcceptQuest();
                                }
                                else if (quest.questBeing == 3 && quest.TalkNpc())
                                {
                                    quest.AcceptQuest2(); 
                                }
                                else
                                {
                                    quest.TalkNpc();
                                }
                                Console.Clear();
                            }
                            else if (map1.map[y_axis, (x_axis+1)] == '▲') // 산에 도착할 경우
                            {
                                if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                {
                                    map1.map[y_axis, x_axis] = '▲';
                                    map1.map[y_axis, ++x_axis] = PLAYER;
                                }
                                else
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[y_axis, ++x_axis] = PLAYER;
                                }
                                surprise = random.Next(1, 101);
                                if (surprise <= 17)
                                {
                                    battle1.BattleStart(ref playerHp);
                                    if (quest.questName != default)
                                    {
                                        quest.questCount++;
                                    }
                                }
                                Console.Clear();
                            }
                            else
                            {
                                if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                {
                                    map1.map[y_axis, x_axis] = '▲';
                                    map1.map[y_axis, ++x_axis] = PLAYER;
                                }
                                else
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[y_axis, ++x_axis] = PLAYER;
                                }
                            }
                        }
                        else
                        {
                            /*Pass*/
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (y_axis <= 1)
                        {
                            /*Pass*/
                        }
                        else
                        {
                            if (map1.map[(y_axis-1), x_axis] == 'ⓝ') // NPC 아이콘을 만날경우
                            {
                                if (quest.questBeing == 0 && quest.TalkNpc())
                                {
                                    quest.AcceptQuest();
                                }
                                else if (quest.questBeing == 3 && quest.TalkNpc())
                                {
                                    quest.AcceptQuest2();
                                }
                                else
                                {
                                    quest.TalkNpc();
                                }
                                Console.Clear();
                            }
                            else if (map1.map[(y_axis-1), x_axis] == '▲')
                            {
                                surprise = random.Next(1, 101);
                                if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                {
                                    map1.map[y_axis, x_axis] = '▲';
                                    map1.map[--y_axis, x_axis] = PLAYER;
                                }
                                else
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[--y_axis, x_axis] = PLAYER;
                                }
                                if (surprise <= 17)
                                {
                                    battle1.BattleStart(ref playerHp);
                                    if (quest.questName != default)
                                    {
                                        quest.questCount++;
                                    }
                                }
                                Console.Clear();
                            }
                            else
                            {
                                if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                {
                                    map1.map[y_axis, x_axis] = '▲';
                                    map1.map[--y_axis, x_axis] = PLAYER;
                                }
                                else
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[--y_axis, x_axis] = PLAYER;
                                }
                            }

                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (y_axis < (MAP_SIZE_Y-2))
                        {
                            if (map1.map[(y_axis+1), x_axis] == 'ⓝ') // NPC 아이콘을 만날경우
                            {
                                if (quest.questBeing == 0 && quest.TalkNpc())
                                {
                                    quest.AcceptQuest();
                                }
                                else if (quest.questBeing == 3 && quest.TalkNpc())
                                {
                                    quest.AcceptQuest2();
                                }
                                else
                                {
                                    quest.TalkNpc();
                                }
                                Console.Clear();
                            }
                            else if (map1.map[(y_axis+1), x_axis] == '▲')
                            {
                                surprise = random.Next(1, 101);
                                if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                {
                                    map1.map[y_axis, x_axis] = '▲';
                                    map1.map[++y_axis, x_axis] = PLAYER;
                                }
                                else
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[++y_axis, x_axis] = PLAYER;
                                }
                                if (surprise <= 17)
                                {
                                    battle1.BattleStart(ref playerHp);
                                    if(quest.questName != default)
                                    {
                                        quest.questCount++;
                                    }                                    
                                }
                                Console.Clear();
                            }                           
                            else
                            {
                                if ((x_axis > 17 && x_axis< 28) && (y_axis >1 && y_axis < 6))
                                {
                                    map1.map[y_axis, x_axis] = '▲';
                                    map1.map[++y_axis, x_axis] = PLAYER;
                                }
                                else
                                {
                                    map1.map[y_axis, x_axis] = 'ㅤ';
                                    map1.map[++y_axis, x_axis] = PLAYER;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                        }
                        break;
                    //case ConsoleKey.I:
                    //    shop1.Printinven(inventory);
                    //    Thread.Sleep(2000);
                    //    Console.Clear();
                    //    break;
                    default:
                        Console.WriteLine("\n\n입력이 잘못되었습니다.\n");
                        break;
                }

                if(quest.questBeing == 4)
                {
                    quest.questCount2++;
                }

                if (quest.questBeing == 1 && quest.questCount >= quest.maxCount) //퀘스트를 완료했을 경우
                {
                    map1.PrintMap();
                    quest.FinishQuest();
                    quest.questName = default;
                    quest.questBeing = 3;
                    status(quest, playerHp);
                }
                else if (quest.questBeing == 4 && quest.questCount2 >= quest.maxCount) //퀘스트를 완료했을 경우
                {
                    Console.Clear();
                    map1.PrintMap();
                    quest.FinishQuest();
                    quest.questName = default;
                    quest.questCount2 = 0;
                    quest.questBeing = 5;
                    status(quest, playerHp);
                }
                else
                {
                    status(quest, playerHp);
                    map1.PrintMap();
                }
            }
        }
        static void status<T>(T quest , int playerHp) where T : Quest
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("나의 체력 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("♥ {0}", playerHp);
            Console.ResetColor();
            if (quest.questBeing == 1)
            {
                quest.PrintQuest();
            }
            else if(quest.questBeing == 4)
            {
                quest.PrintQuest2();
            }
            
        }
    }
}
