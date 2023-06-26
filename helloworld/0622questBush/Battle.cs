using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0622questBush
{
    public class Battle
    {
        public void BattleStart(ref int playerHp)
        {
            Random random = new Random();
            int slimeHp = 30;       //몬스터들의 체력과 공격력
            int slimeAttack = 3;
            int wolfHp = 40;
            int wolfAttack = 5;
            int undeadHp = 50;
            int undeadAttack = 4;



            int playerAttack = 10;
            int mobdice = random.Next(1, 4); // 몬스터 만날 확률 주사위

            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 35; i++)
            {
                Console.WriteLine("                                                                                                                                                                                                                     ");
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(0, 2);

            switch (mobdice) //몬스터 종류 정하는 스위치문
            {
                case 1:
                    Console.WriteLine("박정근의 저주받은 다리털을 조우했다.\n");
                    Thread.Sleep(500);
                    monsterbattle(slimeHp, slimeAttack, playerAttack, ref playerHp);
                    break;
                case 2:
                    Console.WriteLine("승규의 찰랑이는 머리카락을 조우했다.\n ");
                    Thread.Sleep(500);
                    monsterbattle(wolfHp, wolfAttack, playerAttack, ref playerHp);
                    break;
                default:
                    Console.WriteLine("기어다니는 승주를 조우했다.\n ");
                    Thread.Sleep(500);
                    monsterbattle(undeadHp, undeadAttack, playerAttack, ref playerHp);
                    break;

            }

        }




        public void monsterbattle(int monsterHp, int monsterAttack, int playerAttack, ref int playerHp) //몬스터와의 배틀 계산 함수
        {

            while (monsterHp > 0 && playerHp > 0)
            {
                Console.WriteLine("\n적의 체력 : {0} 적의 공격력 : {1}", monsterHp, monsterAttack);
                Console.WriteLine("나의 체력 : {0} 나의 공격력 {1}\n", playerHp, playerAttack);
                Thread.Sleep(700);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n적을 공격합니다! 데미지 {0}!\n ", playerAttack);
                monsterHp -= playerAttack;
                Thread.Sleep(300);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n적이 나를 공격합니다! 데미지 {0}!\n", monsterAttack);
                playerHp -= monsterAttack;
                Console.WriteLine();
                Thread.Sleep(500);
                Console.ResetColor();
            }
            if (playerHp <= 0)
            {
                Console.Write("\n적과의 전투에서 패배했습니다.. 다음에 다시 도전해보세요..\n\n");
                return;
            }
            Console.Write("\n적의 체력 : {0} 적의 공격력 : {1}        나의 체력 : {2} 나의 공격력 {3}\n", monsterHp, monsterAttack, playerHp, playerAttack);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\n적과의 전투에서 승리했습니다!\n\n");
            Console.ResetColor();
            Console.ReadKey();


        }

    }
}
