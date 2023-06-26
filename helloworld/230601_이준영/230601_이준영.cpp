#include <iostream>

void makesquare(int count);



int main()
{
    int size = 0;
    printf("원하시는 사각형의 사이즈를 3부터 10사이로 입력해주세요 -> ");
    scanf_s("%d", &size);
    while (size < 3 || size > 10)
    {
        printf("3부터 10사이만 가능합니다 다시 입력해주세요 -> ");
        scanf_s("%d", &size);
    }
    printf("\n");
    makesquare(size);
}

void makesquare(int count)
{
    int whilecount = count * count;
    int savecount = count;
    
    {
        while (whilecount >= 1)
        {
            while (savecount >= 1)
            {
                printf("* ");
                savecount -= 1;
                whilecount -= 1;
            }
            printf("\n");
            savecount = count;
        }
    }
}