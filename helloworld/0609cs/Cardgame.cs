using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.Collections;

namespace _0609cs
{
    public class Cardgame
    {
      
        static void Main(string[] args)
        {
            Trumph();
        }


        static void Trumph()
        {

            int [] cards = new int[52];
            int[] cardnum = new int[52];
            string[] cardpatterns ={ "♠", "◆", "♥", "♣" };
            int[] pickcards = new int[4];           

            for (int i = 0; i < cardnum.Length; i++)
            {
                cardnum[i] = i;
            }   //카드 순서 적은 배열 선언

                for (int i = 0; i < 52; i++)
            {
                if ((i % 13) == 0)
                {
                    cards[i] = 'A';
                }
                else if ((i % 13) == 10)
                {
                    cards[i] = 'J';
                }
                else if ((i % 13) == 11)
                {
                    cards[i] = 'Q';
                }
                else if ((i % 13) == 12)
                {
                    cards[i] = 'K';
                }
                else
                {
                    cards[i] = i % 13 + 1;
                }
            } // 카드 배열 내용 선언


            Random random = new Random();
            int count = cardnum.Length;
            while (count > 1)
            {
                int k = random.Next(count--);
                int temp = cardnum[count];
                cardnum[count] = cardnum[k];
                cardnum[k] = temp;
            }       // 카드 순서 배열 셔플


           

            // 뽑은 4개의 카드 출력하는 부분
            for (int i = 0; i < 4; i++)
    {   
                if(i<2)
                {
                    Console.WriteLine("나의 {0}번째 카드",i+1);
                }
                else
                {
                    Console.WriteLine("컴퓨터의 {0}번째 카드",i-1);
                }
                if (cards[cardnum[i]] < 15)
        {
            if (cardnum[i] < 13)
            {
                Console.Write("{0} / {1} \n", cardpatterns[0], cards[cardnum[i]]);
            }
            else if (cardnum[i] < 26)
            {
                Console.Write("{0} / {1} \n", cardpatterns[1], cards[cardnum[i]]);
            }
            else if (cardnum[i] < 39)
            {
                Console.Write("{0} / {1} \n", cardpatterns[2], cards[cardnum[i]]);
            }
            else
            {
                Console.Write("{0} / {1} \n", cardpatterns[3], cards[cardnum[i]]);
            }
        }
        else
        {
            if (cardnum[i] < 13)
            {
                Console.Write("{0} / {1} \n", cardpatterns[0], (char)cards[cardnum[i]]);
            }
            else if (cardnum[i] < 26)
            {
                Console.Write("{0} / {1} \n", cardpatterns[1], (char)cards[cardnum[i]]);
            }
            else if (cardnum[i] < 39)
            {
                Console.Write("{0} / {1} \n", cardpatterns[2], (char)cards[cardnum[i]]);
            }
            else
            {
                Console.Write("{0} / {1} \n", cardpatterns[3], (char)cards[cardnum[i]]);
            }
        }
                Console.WriteLine();
    }

            
               


            for (int i = 0; i < 4; i++)
            {
                if(cards[cardnum[i]] == 65)
                {
                    cards[cardnum[i]] = 1;
                }
                else if(cards[cardnum[i]] == 74)
                {
                    cards[cardnum[i]] = 11;
                }
                else if (cards[cardnum[i]] == 75)
                {
                    cards[cardnum[i]] = 13;
                }
                else if (cards[cardnum[i]] == 81)
                {
                    cards[cardnum[i]] = 12;
                }           
            }

            int mycard1 = cards[cardnum[0]];
            int mycard2 = cards[cardnum[1]];
            int comcard1 = cards[cardnum[2]];
            int comcard2 = cards[cardnum[3]];
            int mycardsum = mycard1 + mycard2; //13; //무승부 유도시 사용
            int comcardsum = comcard1 + comcard2; //13; 무승부 유도시 사용

            Console.WriteLine("내 카드 2장 숫자의 합 : {0}\n", mycardsum);
            Console.WriteLine("컴퓨터 카드 2장 숫자의 합 : {0}\n", comcardsum);

            if (mycardsum> comcardsum)
            {
                Console.WriteLine("\n\n승리하였습니다!!\n\n");
            }
            else if(mycardsum < comcardsum)
            {
                Console.WriteLine("\n\n패배하였습니다..\n\n");
            }
            else
            {
                if (((cardnum[0]+1) / 13) < ((cardnum[2]+1) / 13))
                {
                    Console.WriteLine("\n\n승리하였습니다!!\n\n");
                }
                else if (((cardnum[0] + 1) / 13) > ((cardnum[2] + 1) / 13))
                {
                    Console.WriteLine("\n\n패배하였습니다..\n\n");
                }
                else if(((cardnum[0] + 1) / 13) == ((cardnum[2] + 1) / 13))
                {
                    if (((cardnum[1]+1) / 13) < ((cardnum[3]+1) / 13))
                    {
                        Console.WriteLine("\n\n승리하였습니다!!\n\n");
                    }
                    else if(((cardnum[1] + 1) / 13) > ((cardnum[3] + 1) / 13))
                    {
                        Console.WriteLine("\n\n패배하였습니다..\n\n");
                    }
                    else
                    {
                        Console.WriteLine("\n\n무승부입니다.\n\n");

                    }
                }
            }


        }

    }
}
