#include <iostream>
#include <conio.h>
#include <time.h>
#include <windows.h>

void Desc002();
void ShuffleOnce(int* firstNumber, int* secondNumber);
bool clear(int arr[][6], int arr2[][6]);

int main()
{
    Desc002();
}

void Desc002()
{
    char keyInput = 0;
    int char2_[6][6] = { 0, };
    int puzzlearea = 0;
    int count = 1;
    int clearpoint = 0;

    printf("슬라이딩 퍼즐의 크기를 입력해주세요 (3 ~ 6)");
    std::cin >> puzzlearea;

    int x_axis = puzzlearea-1;
    int y_axis = puzzlearea-1;

    for (int y = 0; y < puzzlearea; y++)
    {
        for (int x = 0; x < puzzlearea; x++)
        {
            if (x == puzzlearea - 1 && y == puzzlearea - 1)
            {
                char2_[y][x] = 0;
                continue;
            }
            char2_[y][x] = count++;
        }
    }
    
    count = 1;
    int clearpuzzle[6][6] = { 0, };

    for (int y = 0; y < puzzlearea; y++)
    {
        for (int x = 0; x < puzzlearea; x++)
        {
            if (x == puzzlearea - 1 && y == puzzlearea - 1)
            {
                clearpuzzle[y][x] = 0;
                continue;
            }
            clearpuzzle[y][x] = count++;
        }
    }

    const int shuffleCount = 500;
    int randomIdx1, randomIdx2, randomIdx3, randomIdx4 = 0;
    int randompoint = 0;
    srand(time(NULL));

    /*for (int i = 0; i < shuffleCount; i++)
    {
        randomIdx1 = rand() % puzzlearea;
        randomIdx2 = rand() % (puzzlearea-1);
        randomIdx3 = rand() % (puzzlearea-1);
        randomIdx4 = rand() % puzzlearea;
        ShuffleOnce(&char2_[randomIdx1][randomIdx3], &char2_[randomIdx2][randomIdx4]);
    }*/

    for (int i = 0; i < shuffleCount; i++)
    {
        randompoint = rand() % 4;
        switch (randompoint)
        {
        case 0:
            if (x_axis <= 0)
            {
                break;
            }
            else
            {
                char2_[y_axis][x_axis] = char2_[y_axis][x_axis - 1];
                char2_[y_axis][--x_axis] = 0;

            }
            break;

        case 1:
            if (x_axis < puzzlearea - 1)
            {
                char2_[y_axis][x_axis] = char2_[y_axis][x_axis + 1];
                char2_[y_axis][++x_axis] = 0;

                break;
            }
            else
            {

                break;
            }

        case 2:
            if (y_axis < 1)
            {



                break;
            }
            else
            {
                char2_[y_axis][x_axis] = char2_[y_axis - 1][x_axis];
                char2_[--y_axis][x_axis] = 0;

            }
            break;

        default :
            if (y_axis < puzzlearea - 1)
            {
                char2_[y_axis][x_axis] = char2_[y_axis + 1][x_axis];
                char2_[++y_axis][x_axis] = 0;
            }
            else
            {



                break;

            }
            break;


        }
    }

    //셔플 로직

    printf("\n\n\n");

    //출력 부분
    for (int y = 0; y < puzzlearea; y++)
    {
        for (int x = 0; x < puzzlearea; x++)
        {
            printf("|%2d| ", char2_[y][x]);
        }
        printf("\n");
    }

    while (clearpoint <= 0)
    {
        keyInput = _getch(); //키입력을 받고 확인하는 내용
        system("cls");
        switch (keyInput)
        {
        case 'a':
            if (x_axis <= 0)
            {                             
                break;
            }
            else
            {
                char2_[y_axis][x_axis] = char2_[y_axis][x_axis-1];
                char2_[y_axis][--x_axis] = 0;
                
            }
            break;
        case 'd':
            if (x_axis < puzzlearea-1)
            {
                char2_[y_axis][x_axis] = char2_[y_axis][x_axis + 1];
                char2_[y_axis][++x_axis] = 0;

                break;
            }
            else
            {
                
                break;
            }
        case 'w':
            if (y_axis < 1)
            {
               
               

                break;
            }
            else
            {
                char2_[y_axis][x_axis] = char2_[y_axis-1][x_axis];
                char2_[--y_axis][x_axis] = 0;
                
            }
            break;



        case 's':
            if (y_axis < puzzlearea-1)
            {
                char2_[y_axis][x_axis] = char2_[y_axis+1][x_axis];
                char2_[++y_axis][x_axis] = 0;
            }
            else
            {

                

                break;

            }
            break;

        default:
            printf("\n\n입력이 잘못되었습니다.\n");
        }
        if (clear(char2_, clearpuzzle))
        {
            printf("\n\n퍼즐을 클리어하였습니다!!");
            clearpoint++;
        }
        else
        {
            for (int y = 0; y < puzzlearea; y++)
            {
                for (int x = 0; x < puzzlearea; x++)
                {
                    printf("|%2d| ", clearpuzzle[y][x]);
                }
                printf("\n");
            }
            printf("\n아래의 퍼즐을 움직여 위의 퍼즐과 똑같이 맞춰보세요 \n\n");

            for (int y = 0; y < puzzlearea; y++)
            {
                for (int x = 0; x < puzzlearea; x++)
                {
                    printf("|%2d| ", char2_[y][x]);
                }
                printf("\n");
            }

        }
    }
}

void ShuffleOnce(int* firstNumber, int* secondNumber)
{
    int temp = 0;
    temp = *firstNumber;
    *firstNumber = *secondNumber;
    *secondNumber = temp;
}

bool clear(int arr[][6], int arr2[][6])
{
    for (int j = 0; j < 6; j++)
    {
        for (int i = 0; i < 6; i++)
        {
            if (arr[j][i] != arr2[j][i])
            {
                return false;
            }
            
        }
    }
    return true;
}