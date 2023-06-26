using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace _230619Poker
{
    public class Program
    {
        static void Main(string[] args)
        {                      
            Poker();
        }

        static void Poker()
        {
            Win win1 = new Win();


            int[] cards = new int[52];              // A~K까지 4묶음 들어가있는 배열
            int[] cardnum = new int[52];            //cards의 카드를 뽑아오기 위한 0~51까지의 인덱스 넘버가 들어가 있는 배열
            string[] cardpatterns = { "♠", "◆", "♥", "♣" };
            string[] mypatterns = new string[7];    //내 카드의 문양들을 넣을 배열
            int[] mycards = new int[5];             //내 카드의 숫자들을 넣을 배열
            int[] comcards = new int[5];            //컴퓨터 카드의 숫자들을 넣을 배열
            string[] compatterns = new string[20];  //컴퓨터 카드의 문양들을 넣을 배열 
            int point = 500;                        //배팅에 사용할 포인트

            //족보 비교 후 점수까지 설정하기 위한 변수
            string compareMyScore, compareComScore;  
            int myRank, comRank;

            for (int i = 0; i < 52; i++)            //cards 배열에 A~K 4묶음을 추가하기 위한 반복문
            {
                if ((i % 13 +1) == 1)
                {
                    cards[i] = 'A';
                }
                else if ((i % 13 + 1) == 11)
                {
                    cards[i] = 'J';
                }
                else if ((i % 13 + 1) == 12)
                {
                    cards[i] = 'Q';
                }
                else if ((i % 13 + 1) == 13)
                {
                    cards[i] = 'K';
                }
                else
                {
                    cards[i] = i % 13 + 1;
                }
            } // 카드 배열 내용 선언

            for (int i = 0; i < cardnum.Length; i++)
            {
                cardnum[i] = i;
            }   //cards 인덱스 넘버 적은 배열 선언


            while (true)  //게임 시작 후 반복
            {

                if (point > 3000)   //포인트가 3000포인트를 넘으면 게임 승리
                {
                    Console.WriteLine("당신이 가진 포인트는 무려 {0}입니다!", point);
                    Console.WriteLine("축하합니다!! 게임에서 승리했습니다!!");
                    return;
                }
                else
                {


                    string strpoint;        //입력값을 받아올 문자열 변수
                    int bettingpoint = 0;   //받아온 문자열을 정수형으로 변환해서 넣을 변수
                    Console.Clear();
                    Console.WriteLine("현재 가지고 있는 포인트 : {0}\n", point);

                    Random random = new Random();
                    int count = cardnum.Length;
                    while (count > 1)
                    {
                        int k = random.Next(count--);
                        int temp = cardnum[count];
                        cardnum[count] = cardnum[k];
                        cardnum[k] = temp;
                    }       // 카드 인덱스넘버 배열(cardnum) 셔플

                    //섞인 예시
                    //32 47 9 20 6 48 10 19 28 41 33 21 13 5 38 11 18 50 12 22 46 43 7 15 26 37 45 29
                    //4 2 1 31 30 51 0 27 42 17 8 25 14 23 49 16 39 36 35 24 3 40 34 44


                    int iredraw = default;  //입력값에 이용할 변수
                    int th1, th2;   //카드 바꾸기 관련 입력값에 이용할 변수

                    // 나의 5개의 카드를 뽑고, 출력하는 부분
                    for (int i = 0; i < 5; i++)
                    {
                        Console.SetCursorPosition((i*25), 3);
                        Console.WriteLine("나의 {0}번째 카드", i + 1);
                        Console.SetCursorPosition((i*25), 4);
                        PrintCard(cards, cardpatterns,ref mypatterns, cardnum, i);
                        if (cards[cardnum[i]] == 65)
                        {
                            cards[cardnum[i]] = 1;
                        }
                        else if (cards[cardnum[i]] == 74)
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
                        mycards[i] = cards[cardnum[i]];                        
                    }

                    // 컴퓨의 7개의 카드를 뽑고, 출력하는 부분
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine("컴퓨터의 {0}번째 카드", i + 1);
                        PrintCard(cards, cardpatterns, ref compatterns, cardnum, i+7);
                        if (cards[cardnum[i+7]] == 65)
                        {
                            cards[cardnum[i+7]] = 1;
                        }
                        else if (cards[cardnum[i+7]] == 74)
                        {
                            cards[cardnum[i+7]] = 11;
                        }
                        else if (cards[cardnum[i+7]] == 75)
                        {
                            cards[cardnum[i+7]] = 13;
                        }
                        else if (cards[cardnum[i+7]] == 81)
                        {
                            cards[cardnum[i+7]] = 12;
                        }

                        if (i <5)
                        {
                            comcards[i] = cards[cardnum[i+7]];
                        }
                    }

                    Console.Write("배팅할 금액을 입력해 주세요  ");
                    strpoint = Console.ReadLine();
                    bettingpoint = Int32.Parse(strpoint);
                    Console.WriteLine("\n카드를 교체하시겠습니까?? (Y,N)");
                    string redraw = Console.ReadLine();

                    switch (redraw)         //카드를 교체할경우 이용하는 스위치문
                    {
                        case "y":
                            Console.WriteLine("카드를 몇장 바꾸시겠습니까?");
                            redraw = Console.ReadLine();
                            iredraw = Int32.Parse(redraw);


                            for (int j = 0; j< iredraw; j++)
                            {
                                if (j == 0)
                                {
                                    Console.Write("몇번째 카드를 바꾸시겠습니까?");
                                    redraw = Console.ReadLine();
                                    th1 = Int32.Parse(redraw);
                                    mycards[th1-1] = default;                                   //바꿀 카드 자리를 비워줌
                                    Console.SetCursorPosition((th1-1)*25, 3);                      
                                    Console.WriteLine("바뀐 나의 {0}번째 카드", th1);
                                    Console.SetCursorPosition((th1-1)*25, 4);
                                    PrintCard(cards, cardpatterns, ref mypatterns, cardnum, 5); //바꾼 카드 출력
                                    mycards[th1-1] = cards[cardnum[5]];                         //바꿀 카드 자리에 새로 뽑은 카드 넣어주기
                                    mypatterns[th1-1] = mypatterns[5];      //문양도 바꾸기
                                    Console.SetCursorPosition(0, 30);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        Console.WriteLine("                                                           ");
                                    }
                                    Console.SetCursorPosition(0, 33);
                                } 
                                else  // 2장 바꿀경우 위의 구문 한번더 적용
                                {
                                    Console.Write("이번엔 몇번째 카드를 바꾸시겠습니까?");
                                    redraw = Console.ReadLine();
                                    th2 = Int32.Parse(redraw);
                                    mycards[th2-1] = default;
                                    Console.SetCursorPosition((th2-1)*25, 3);
                                    Console.WriteLine("바뀐 나의 {0}번째 카드", th2);
                                    Console.SetCursorPosition((th2-1)*25, 4);
                                    PrintCard(cards, cardpatterns, ref mypatterns, cardnum, 6);
                                    mycards[th2-1] = cards[cardnum[6]];
                                    mypatterns[th2-1] = mypatterns[6];
                                    Console.SetCursorPosition(0, 30);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        Console.WriteLine("                                                           ");
                                    }
                                    Console.SetCursorPosition(0, 30);
                                }
                            }

                            break;
                        default:
                            break;
                    }

                    // 나와 컴퓨터의 손패 정렬해주기
                    Array.Sort(mycards);
                    Array.Sort(comcards);
                    Array.Sort(compatterns);
                    Array.Reverse(compatterns);

                    
                    //데이터 확인용
                    //mycards[0] = 3;
                    //mycards[1] = 3;
                    //mycards[2] = 3;
                    //mycards[3] = 8;
                    //mycards[4] = 6;

                    //mypatterns[0] = "♠";
                    //mypatterns[1] = "♠";
                    //mypatterns[2] = "♠";
                    //mypatterns[3] = "♠";
                    //mypatterns[4] = "♠";







                    //포커 족보를 통한 점수 비교하기

                    if (win1.RoyalStFlush(mycards,mypatterns))
                    {
                        compareMyScore = "로얄 스트레이트 플러시";
                        myRank = 10;
                    }
                    else if(win1.StFlush(mycards, mypatterns))
                    {
                        compareMyScore = "스트레이트 플러시";
                        myRank = 9;
                    }
                    else if(win1.FourCard(mycards, mypatterns))
                    {
                        myRank = 8;
                        compareMyScore = "포 카드";
                    }
                    else if(win1.fullhouse(mycards,mypatterns))
                    {
                        myRank = 7;
                        compareMyScore = "풀 하우스";
                    }
                    else if(win1.Flush(mycards, mypatterns))
                    {
                        myRank = 6;
                        compareMyScore = "플러시";
                    }
                    else if(win1.Straight(mycards, mypatterns))
                    {
                        myRank = 5;
                        compareMyScore = "스트레이트";
                    }
                    else if(win1.Triple(mycards, mypatterns))
                    {
                        myRank = 4;
                        compareMyScore = "트리플";
                    }
                    else if(win1.TwoPair(mycards, mypatterns))
                    {
                        myRank = 3;
                        compareMyScore = "투 페어";
                    }
                    else if(win1.Pair(mycards, mypatterns))
                    {
                        myRank = 2;
                        compareMyScore = "페어";
                    }
                    else
                    {
                        myRank = 1;
                        compareMyScore = "하이 카드";
                    }




                    if (win1.RoyalStFlush(comcards, compatterns))
                    {
                        comRank = 10;
                        compareComScore = "로얄 스트레이트 플러시";
                    }
                    else if (win1.StFlush(comcards, compatterns))
                    {
                        comRank = 9;
                        compareComScore = "스트레이트 플러시";
                    }
                    else if (win1.FourCard(comcards, compatterns))
                    {
                        comRank = 8;
                        compareComScore = "포 카드";
                    }
                    else if (win1.fullhouse(comcards, compatterns))
                    {
                        compareComScore = "풀 하우스";
                        comRank = 7;
                    }
                    else if (win1.Flush(comcards, compatterns))
                    {
                        comRank = 6;
                        compareComScore = "플러시";
                    }
                    else if (win1.Straight(comcards, compatterns))
                    {
                        comRank = 5;
                        compareComScore = "스트레이트";
                    }
                    else if (win1.Triple(comcards, compatterns))
                    {
                        comRank = 4;
                        compareComScore = "트리플";
                    }
                    else if (win1.TwoPair(comcards, compatterns))
                    {
                        comRank = 3;
                        compareComScore = "투 페어";
                    }
                    else if (win1.Pair(comcards, compatterns))
                    {
                        comRank = 2;
                        compareComScore = "페어";
                    }
                    else
                    {
                        comRank = 1;
                        compareComScore = "하이카드";
                    }


                    if(comRank > myRank)
                    {
                        Console.WriteLine(" 컴퓨터 족보 {0} \n 나의 족보 {1} \n 컴퓨터의 승리 입니다",compareComScore,compareMyScore);
                        point -= bettingpoint;
                    }
                    else if(comRank < myRank)
                    {
                        Console.WriteLine(" 나의 족보 {0}\n 컴퓨터의 족보 {1} \n 플레이어의 승리 입니다.", compareMyScore,compareComScore);
                        point += bettingpoint;
                    }
                    else
                    {
                        Console.WriteLine("무승부 입니다.");
                    }



                    ConsoleKeyInfo keyInput;

                    Console.WriteLine("\n아무키나 입력하시면 다시 시작합니다. Q를 입력할시, 게임을 종료합니다.");
                    keyInput = Console.ReadKey();

                    switch (keyInput.Key)
                    {
                        case ConsoleKey.Q:
                            return;
                        default:
                            break;
                    }


                }
            }
        }

        // 카드 출력을 위한 함수
        static void PrintCard(int[] cards, string[] cardpatterns, ref string[] mypatterns, int[] cardnum, int i)
        {
            if (cards[cardnum[i]] < 15)     //15보다 작을경우 숫자로 판단 (2~10)
            {
                if (cardnum[i] < 13)    //첫 묶음은 스페이드
                {
                    Console.Write("{0} / {1} \n", cardpatterns[0], cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[0];    //내 문양 받아오기
                }
                else if (cardnum[i] < 26)   //두번째는 다이아
                {
                    Console.Write("{0} / {1} \n", cardpatterns[1], cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[1];
                }
                else if (cardnum[i] < 39)   //세번째는 하트로
                {
                    Console.Write("{0} / {1} \n", cardpatterns[2], cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[2];
                }
                else                        //네번째는 클로버로
                {
                    Console.Write("{0} / {1} \n", cardpatterns[3], cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[3];
                }
            }
            else        // 아닐경우 15보다 크므로 아스키코드값인 문자로 판단
            {
                if (cardnum[i] < 13)
                {
                    Console.Write("{0} / {1} \n", cardpatterns[0], (char)cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[0];
                }
                else if (cardnum[i] < 26)
                {
                    Console.Write("{0} / {1} \n", cardpatterns[1], (char)cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[1];
                }
                else if (cardnum[i] < 39)
                {
                    Console.Write("{0} / {1} \n", cardpatterns[2], (char)cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[2];
                }
                else
                {
                    Console.Write("{0} / {1} \n", cardpatterns[3], (char)cards[cardnum[i]]);
                    mypatterns[i] = cardpatterns[3];
                }
            }
            Console.WriteLine();
        }
    }
}
