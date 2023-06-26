using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0615HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            StoneGame();
        }

        static void StoneGame()
        {

            int size = 20;
            int point = 0; ;    // 돌3개로 깰때마다 올라감
            //DateTime nowDate = DateTime.Today;
            Console.WriteLine("게임을 시작하기 전, 맵의 크기를 입력하여 주세요(5~15)");
            size = int.Parse(Console.ReadLine());

           
            
            reset:      
            //스위치문에서 R을 입력받았을 시 여기로 이동

            // 맵 사이즈 입력받는 부분
            int x_axis = (size/2);
            int y_axis = (size/2);
            char[,] board = new char[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == (size/2) && y == (size/2))
                    {
                        board[size/2, size/2] = '&';
                        continue;
                    }
                    if ((x == 0 || y == 0)|| (x == (size-1) || y == (size-1)))
                    {
                        board[y, x] = '#';
                        continue;
                    }

                    board[y, x] = '*';
                }
            }

            // 기본 맵 생성하는 부분

            //출력 부분
            printmap(board, size, point);

            int moveCount = 0;
            int stoneX = 0;
            int stoneY = 0;
            Random random = new Random();
            bool noStone = true;    //돌이 필드에 있는지 없는지 체크하는 변수

            
            while (point < 5)
            {

                bool stone = false;     //돌을 밀때 그 건너에 돌이있을때 체크하는 변수
                int stoneLocation = 0;
                ConsoleKeyInfo keyInput = Console.ReadKey(true); //키입력을 받고 확인하는 내용

                if (noStone)  //돌생성 부분
                {
                    for (int i = 0; i <3; i++)
                    {
                        do
                        {
                            stoneX = random.Next(1, (size-2));
                            stoneY = random.Next(1, (size-2));
                        }
                        while (((y_axis == stoneY) && (x_axis == stoneX)) || board[stoneY,stoneX] == '@');
                        board[stoneY, stoneX] = '@';
                    }
                    noStone = false;    //돌생성시 bool변수를 거짓으로 만들어 돌이 사라질때까지 재생성되지 않게함
                }

                switch (keyInput.Key)
                {
                    case ConsoleKey.R:  //R입력시 리셋부분으로 이동
                        goto reset;
                    
                    case ConsoleKey.LeftArrow:
                        if (x_axis <= 1)
                        {                           
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                        }
                        else
                        {
                            if (x_axis > 1) // 이동 가능할 경우
                            {
                                if (board[y_axis, (x_axis-1)] == '@') // 돌을 만났을 경우
                                {
                                    for (int i = (x_axis-2); i >= 0; i--) //돌 앞쪽에 돌이 있는지 확인
                                    {
                                        if (board[y_axis, i] == '@')
                                        {
                                            stoneLocation = i;
                                            stone = true;
                                            break;
                                        }
                                    }
                                    if (board[y_axis,stoneLocation] == '@' && stone) //돌이 돌에 막혔을경우의 출력문
                                    {
                                        board[y_axis, (x_axis-1)] = '*';
                                        board[y_axis, stoneLocation+1] = '@';                                        
                                    }
                                    else  // 돌에 막히지 않았을 경우의 출력문
                                    {                                       
                                        board[y_axis, (x_axis-1)] = '*';
                                        board[y_axis, 1] = '@';
                                    }
                                }
                                else //돌을 안만났을경우
                                {
                                    board[y_axis, x_axis] = '*';
                                    board[y_axis, --x_axis] = '&';
                                }
                            }
                            
                            
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (x_axis < (size-2)) // 이동 가능한 경우
                        {
                            if (board[y_axis, (x_axis+1)] == '@') // 돌을 만났을 경우
                            {
                                for (int i = (x_axis+2); i < size-1; i++) //돌 앞쪽에 돌이 있는지 확인
                                {
                                    if (board[y_axis, i] == '@')
                                    {
                                        stoneLocation = i;
                                        stone = true;
                                        break;
                                    }
                                }   
                                if (board[y_axis, stoneLocation] == '@' && stone) //돌이 돌에 막혔을경우의 출력문
                                {
                                    board[y_axis, (x_axis+1)] = '*';
                                    board[y_axis, stoneLocation-1] = '@';
                                }
                                else  // 돌에 막히지 않았을 경우의 출력문
                                {
                                    board[y_axis, (x_axis+1)] = '*';
                                    board[y_axis, size-2] = '@';
                                }
                            }
                            else
                            {
                                board[y_axis, x_axis] = '*';
                                board[y_axis, ++x_axis] = '&';
                            }
                            
                        }
                        else //돌을 안만났을경우
                        {                           
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (y_axis <= 1)
                        {                           
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                            break;
                        }
                        else
                        {                         
                            if (board[(y_axis-1), x_axis] == '@') // 돌을 만났을 경우
                            {
                                for (int i = (y_axis-2); i >= 0; i--) //돌 앞쪽에 돌이 있는지 확인
                                {
                                    if (board[i, x_axis] == '@')
                                    {
                                        stoneLocation = i;
                                        stone = true;
                                        break;
                                    }
                                }
                                if (board[stoneLocation, x_axis] == '@' && stone) //돌이 돌에 막혔을경우의 출력문
                                {
                                    board[(y_axis-1),x_axis] = '*';
                                    board[stoneLocation+1,x_axis] = '@';
                                }
                                else  // 돌에 막히지 않았을 경우의 출력문
                                {
                                    board[(y_axis-1), x_axis] = '*';
                                    board[1, x_axis] = '@';
                                }
                            }
                            else //돌을 안만났을경우
                            {
                                board[y_axis, x_axis] = '*';
                                board[--y_axis, x_axis] = '&';
                            }
                           
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (y_axis < (size-2))
                        {
                            if (board[(y_axis+1), x_axis] == '@') // 돌을 만났을 경우
                            {
                                for (int i = (y_axis+2); i <= (size-2); i++) //돌 앞쪽에 돌이 있는지 확인
                                {
                                    if (board[i, x_axis] == '@')
                                    {
                                        stoneLocation = i;
                                        stone = true;
                                        break;
                                    }
                                }
                                if (board[stoneLocation, x_axis] == '@' && stone) //돌이 돌에 막혔을경우의 출력문
                                {
                                    board[(y_axis + 1), x_axis] = '*';
                                    board[stoneLocation-1, x_axis] = '@';
                                }
                                else  // 돌에 막히지 않았을 경우의 출력문
                                {
                                    board[(y_axis+1), x_axis] = '*';
                                    board[(size-2), x_axis] = '@';
                                }
                            }
                            else //돌을 안만났을경우
                            {
                                board[y_axis, x_axis] = '*';
                                board[++y_axis, x_axis] = '&';
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("\n벽에 막혀 더이상 갈 수 없습니다.");
                        }
                        break;

                    default:                        
                        Console.WriteLine("\n\n입력이 잘못되었습니다.\n");
                        break;
                }

                //돌 3개가 완성됐을 경우
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        if (board[i, j] == '@' && board[i, j+1] == '@'&& board[i, j+2] == '@') //x축으로 쭈루룩 3개인지 확인
                        {
                            board[i, j] = '*';
                            board[i, j+1] = '*';
                            board[i, j+2] = '*';
                            point += 1;
                            noStone = true; //bool변수를 참으로 바꿔서 돌이 재생성 되게함
                        }
                        if (board[i, j] == '@' && board[i+1, j] == '@'&& board[i+2, j] == '@') //y축으로 쭈루룩 3개인지 확인
                        {
                            board[i, j] = '*';
                            board[i+1, j] = '*';
                            board[i+2, j] = '*';
                            point += 1;
                            noStone = true; //bool변수를 참으로 바꿔서 돌이 재생성 되게함
                        }

                    }
                }

                printmap(board, size, point);



                moveCount += 1;
            }
            Console.Clear();
            printmap(board, size, point);
            Console.WriteLine("\n\n{0}번의 움직임으로 점수 {1}만큼을 달성했습니다!\n\n", moveCount, point);
        }



        //맵 재출력시 사용하는 함수
        static void printmap(char[,] map, int size, int point)      
        {
            Console.Clear();
            Console.WriteLine("현재 나의 점수 : {0}\n\n", point);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map[y, x] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == '&')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
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


//리얼타임 출력시 사용할 부분

//string second = System.DateTime.Now.ToString("ss"); 
//int coinsec = int.Parse(second);
//Console.WriteLine("{0} ", coinsec);


//int savesec = default;

//if (savesec > (50+coinsec))
//{
//    savesec = default;
//}

//if (coinsec > savesec)
//{
//    do
//    {
//        stoneX = random.Next(1, (size-2));
//        stoneY = random.Next(1, (size-2));
//    }
//    while ((y_axis == stoneY) && (x_axis == stoneX));
//    board[stoneY, stoneX] = '@';

//    savesec = 2+coinsec;
//}
