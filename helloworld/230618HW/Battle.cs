using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230618HW
{
    public class Battle
    {
        public void battleStart(ref int playerHp)
        {
            Random random = new Random();
            int slimeHp = 30;       //몬스터들의 체력과 공격력
            int slimeAttack = 3;
            int wolfHp = 40;
            int wolfAttack = 5;
            int undeadHp = 50;
            int undeadAttack = 4;



            int playerAttack = 10;           
            int mobdice = random.Next(1,4); // 몬스터 만날 확률 주사위

            
                switch (mobdice) //몬스터 종류 정하는 스위치문
                {
                    case 1:
                        Console.Write("슬라임을 조우했다.\n");
                        monsterbattle(slimeHp, slimeAttack, playerAttack, ref playerHp);
                        break;
                    case 2:
                        Console.Write("울프를 조우했다.\n ");
                        monsterbattle(wolfHp, wolfAttack, playerAttack, ref playerHp);
                        break;
                    default:
                        Console.Write("언데드를 조우했다.\n ");
                        monsterbattle(undeadHp, undeadAttack, playerAttack, ref playerHp);
                        break;

                }                    

        }


            

            public void monsterbattle(int monsterHp, int monsterAttack, int playerAttack, ref int playerHp) //몬스터와의 배틀 계산 함수
            {
                while (monsterHp > 0 && playerHp > 0)
                {
                    Console.Write("\n적의 체력 : {0} 적의 공격력 : {1}         나의 체력 : {2} 나의 공격력 {3}\n", monsterHp, monsterAttack, playerHp, playerAttack);
                    Thread.Sleep(500);
                    Console.Write("\n적을 공격합니다! 데미지 {0}!\n ", playerAttack);
                    monsterHp -= playerAttack;
                    Thread.Sleep(500);
                    Console.Write("\n적이 나를 공격합니다! 데미지 {0}!\n", monsterAttack);
                    playerHp -= monsterAttack;


                }
                Console.Write("\n적의 체력 : {0} 적의 공격력 : {1}        나의 체력 : {2} 나의 공격력 {3}\n", monsterHp, monsterAttack, playerHp, playerAttack);
                if (monsterHp <= 0)
                {
                    Console.Write("\n적과의 전투에서 승리했습니다!\n\n");
                }
                else
                {
                    Console.Write("\n적과의 전투에서 패배했습니다.. 다음에 다시 도전해보세요..\n\n");
                return;
                }

            }
        
    }
}
