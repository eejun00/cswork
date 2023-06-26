#include <iostream>
#include <time.h>
#include <windows.h>

void trumphcard();
void ShuffleOnce(int* firstNumber, int* secondNumber);

int main()
{
    trumphcard();
}

void trumphcard() //트럼프 카드 1장을 랜덤하게 뽑아서 출력하는 함수
{
    int cards[52] = { 0, };
    char cardpatterns[4][4] = { "♠","◆","♥","♣" };
    //char cardPatterns[4][4] = {'S','D','h','c'};

    int onecard = 0;

    //52개의 배열칸에 하나하나 숫자를 넣는 반복문
    //0~12 스페이드 13~25 다이아 26~38 하트 39~52 클로버
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

    }    //배열의 선언과 초기화



    const int shuffleCount = 500;
    int randomIdx1, randomIdx2 = 0;
    srand(time(NULL));

    for (int i = 0; i < shuffleCount; i++)
    {
        randomIdx1 = rand() % 52;
        randomIdx2 = rand() % 52;
        ShuffleOnce(&cards[randomIdx1], &cards[randomIdx2]);
    }
    //셔플 로직
    printf("\n");

    //배열의 출력
    printf("52가지의 트럼프 카드중 1장을 뽑습니다. \n\n");

    onecard = rand() % 52 + 1;



    if (cards[onecard] < 15) //뽑은 카드의 수가 숫자일 경우 %d로 출력되도록
    {
        if (onecard < 13)
        {
            printf("%s / %d ", cardpatterns[0], cards[onecard]);
        }
        else if (onecard < 26)
        {
            printf("%s / %d ", cardpatterns[1], cards[onecard]);
        }
        else if (onecard < 39)
        {
            printf("%s / %d ", cardpatterns[2], cards[onecard]);
        }
        else
        {
            printf("%s / %d ", cardpatterns[3], cards[onecard]);
        }
        printf("\n\n");
    }
    else
    {
        if (onecard < 13) //뽑은 카드의 수가 A,J같은 문자일경우 %c로 출력
        {
            printf("%s / %c ", cardpatterns[0], cards[onecard]);
        }
        else if (onecard < 26)
        {
            printf("%s / %c ", cardpatterns[1], cards[onecard]);
        }
        else if (onecard < 39)
        {
            printf("%s / %c ", cardpatterns[2], cards[onecard]);
        }
        else
        {
            printf("%s / %c ", cardpatterns[3], cards[onecard]);
        }
        printf("\n\n");
    }


    /*for (int i = 0; i < 52; i++)
    {
        if (cards[i] < 15)
        {
            if (i < 13)
            {
                printf("%s / %d \n", cardpatterns[0], cards[i]);
            }
            else if (i < 26)
            {
                printf("%s / %d \n", cardpatterns[1], cards[i]);
            }
            else if (i < 39)
            {
                printf("%s / %d \n", cardpatterns[2], cards[i]);
            }
            else
            {
                printf("%s / %d \n", cardpatterns[3], cards[i]);
            }
        }
        else
        {
            if (i < 13)
            {
                printf("%s / %c \n", cardpatterns[0], cards[i]);
            }
            else if (i < 26)
            {
                printf("%s / %c \n", cardpatterns[1], cards[i]);
            }
            else if (i < 39)
            {
                printf("%s / %c \n", cardpatterns[2], cards[i]);
            }
            else
            {
                printf("%s / %c \n", cardpatterns[3], cards[i]);
            }
        }
    }*/





}

void ShuffleOnce(int* firstNumber, int* secondNumber)
{
    int temp = 0;
    temp = *firstNumber;
    *firstNumber = *secondNumber;
    *secondNumber = temp;
}
