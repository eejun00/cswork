using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

  namespace _0622questBush
{
    public class Quest
    {
        public string questName;
        public int questCount;
        public int questCount2;
        public int maxCount = 0;
        public int questBeing= 0;
        static public string npcScript1 = "안녕하세요, 저를 도와주러 오셨나요??";
        static public string npcScript1Y = "도와주시는거군요! 감사합니다! 위의 수풀에서 몬스터 두마리만 잡아주세요!";
        static public string npcScript1B = "도와주실거라면서 왜 그냥 오셨나요..?";
        static public string npcScript1N = "안 도와주시는거군요..";
        static public string npcScript2 = "도와주셔서 감사합니다!! 혹시 시간이 남으신다면 제 실습 좀 도와주세요...";
        static public string npcScript2Y = "도와주시는거군요! 감사합니다! 길을 걸으면서 고민을 부탁드릴게요!";
        static public string npcScript3 = "도와주셔서 감사합니다! 이제 더 이상 부탁드릴건 없어요!";

        //static public string npcScript1 = "안 녕 하 세 요. ㅤ 저 를 ㅤ  도 와 주 러 오 셨 나 요 ?";
        //static public string npcScript1Y = "도 와 주 시 는 거 군 요 ! ㅤ 감 사 합 니 다! ㅤ 위 의 수 풀 에 서 ㅤ 몬 스 터 두 마 리 만 ㅤ 잡 아 주 세 요!";
        //static public string npcScript1B = "도 와 주 실 거 라 면 서 ㅤ 왜 ㅤ 그 냥 ㅤ 오 셨 나 요 . . ?";
        //static public string npcScript1N = "안 ㅤ 도 와 주 시 는 거 군 요 ㅠ ㅠ . . .";
        //static public string npcScript2 = "도 와 주 셔 서 ㅤ 감 사 합 니 다 ! ! ! ㅤ 혹 시 ㅤ 시 간 이 ㅤ 남 으 신 다 면 ㅤ 제 ㅤ 실 습 좀 ㅤ 도 와 주 세 요 . . .";
        //static public string npcScript2Y = "도 와 주 시 는 거 군 요 ! ㅤ 감 사 합 니 다! ㅤ 길 을 ㅤ 걸 으 면 서 ㅤ 고 민 을 ㅤ 부 탁 드 릴 게 요 !";
        //static public string npcScript3 = "도 와 주 셔 서 ㅤ 감 사 합 니 다 ! ! ! ㅤ 이 제 ㅤ 더 ㅤ 이 상 ㅤ 부 탁 드 릴 건 ㅤ 없 어 요 !";




        //public string[] npcScript1A = npcScript1.Split(' ');
        //public string[] npcScript1YA = npcScript1Y.Split(' ');
        //public string[] npcScript1BA = npcScript1B.Split(' ');
        //public string[] npcScript1NA = npcScript1N.Split(' ');
        //public string[] npcScript2A = npcScript2.Split(' ');
        //public string[] npcScript2YA = npcScript2Y.Split(' ');
        //public string[] npcScript3A = npcScript3.Split(' ');




        public void AcceptQuest()
        {
            questName = "몬스터 2마리를 잡아주세요. ";
            questCount = 0;
            maxCount = 2;
        }

        public void AcceptQuest2()
        {
            questName = "길을 걸으면서 실습을 같이 고민해주세요. ";
            maxCount = 100;
            questCount = 0;
        }

        public void PrintQuest()
        {
            Console.WriteLine("↓ 퀘스트 내용 ↓");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}",questName);
            Console.ResetColor();
            Console.WriteLine("현재 잡은 몬스터 : [{0}] 마리 / 목표 [{1}] 마리 ", questCount,maxCount);
        }

        public void PrintQuest2()
        {
            Console.WriteLine("↓ 퀘스트 내용 ↓");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}", questName);
            Console.ResetColor();
            Console.WriteLine("현재 걸은 걸음 수 : [{0}] 걸음 / 목표 [{1}] 걸음 ", questCount2, maxCount);
        }

        public void FinishQuest()
        {
            Console.SetCursorPosition(0, 35);
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                             퀘 스 트 를 클 리 어 하 셨 습 니 다 !");
                Console.ResetColor();
                Thread.Sleep(300);
                Console.SetCursorPosition(0, 35);
                Console.WriteLine("                                                                                                                       ");
                Console.SetCursorPosition(0, 35);
                Thread.Sleep(300);               
            }
            Console.ReadKey();
        }

        public bool TalkNpc()
        {
            string answer = default;
            Console.SetCursorPosition(1, 35);
            for(int i  = 0; i < 43; i++)
            {
                Console.Write("ㅡ");
                Thread.Sleep(20);
            }
            Console.WriteLine();
            if (questBeing == 0)
            {
                for (int i = 0; i < npcScript1.Length; i++)
                {
                    Console.Write(npcScript1[i]);
                    Thread.Sleep(100);
                }
                Console.WriteLine();
                Console.Write("도와주려면 Y를 입력해주세요 : ");
                answer = Console.ReadLine();
                Console.SetCursorPosition(0, 36);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("                                                                                          ");
                }
                switch (answer[0])
                {
                    case 'y':
                        Console.SetCursorPosition(0, 36);
                        for (int i = 0; i < npcScript1Y.Length; i++)
                        {
                            Console.Write(npcScript1Y[i]);
                            Thread.Sleep(100);
                        }
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 35);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("                                                                                          ");
                        }
                        questBeing = 1;
                        return true;
                    default:
                        Console.SetCursorPosition(0, 36);
                        for (int i = 0; i < npcScript1N.Length; i++)
                        {
                            Console.Write(npcScript1N[i]);
                            Thread.Sleep(100);
                        }
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 35);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("                                                                                          ");
                        }
                        return false;
                }
            }
            else if(questBeing == 1 || questBeing == 4)
            {
                for (int i = 0; i < npcScript1B.Length; i++)
                {
                    Console.Write(npcScript1B[i]);
                    Thread.Sleep(100);                   
                }
                Console.ReadKey();
                return false;
            }
            else if (questBeing == 3)   //두번째 퀘스트
            {
                for (int i = 0; i < npcScript2.Length; i++)
                {
                    Console.Write(npcScript2[i]);
                    Thread.Sleep(100);
                }
                Console.WriteLine();
                Console.Write("도와주려면 Y를 입력해주세요 : ");
                answer = Console.ReadLine();
                Console.SetCursorPosition(0, 36);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("                                                                                                                                    ");
                }
                switch (answer[0])
                {
                    case 'y':
                        Console.SetCursorPosition(0, 36);
                        for (int i = 0; i < npcScript2Y.Length; i++)
                        {
                            Console.Write(npcScript2Y[i]);
                            Thread.Sleep(100);
                        }
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 35);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("                                                                                                                                                      ");
                        }
                        questBeing = 4;
                        return true;
                    default:
                        Console.SetCursorPosition(0, 36);
                        for (int i = 0; i < npcScript1N.Length; i++)
                        {
                            Console.Write(npcScript1N[i]);
                            Thread.Sleep(100);
                        }
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 35);
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("                                                                                                                                    ");
                        }
                        return false;
                }
            }
            else if (questBeing == 5)
            {
                for (int i = 0; i < npcScript3.Length; i++)
                {
                    Console.Write(npcScript3[i]);
                    Thread.Sleep(100);
                }
                Console.ReadKey();
                return false;
            }
            return false;
        }
    }
}
