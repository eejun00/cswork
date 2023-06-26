using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230618HW
{
    public class Map
    {
        public const int MAP_SIZE_X = 30;
        public const int MAP_SIZE_Y = 15;
        public int x_axis = (MAP_SIZE_X/2);
        public int y_axis = (MAP_SIZE_Y/2);
        public char[,] map = new char[MAP_SIZE_Y, MAP_SIZE_X];

        public void CreateMap()
        {
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (x == (MAP_SIZE_X/2) && y == (MAP_SIZE_Y/2)) // 플레이어
                    {
                        map[MAP_SIZE_Y/2, MAP_SIZE_X/2] = '◎';
                        continue;
                    }                  
                    if ((x == 0 || y == 0)|| (x == (MAP_SIZE_X-1) || y == (MAP_SIZE_Y-1)))  // 벽
                    {
                        map[y, x] = '□';
                        continue;
                    }                    
                    map[y, x] = 'ㅤ';
                }
            }
            map[2, 15] = '▲';
            map[3, 14] = '▲';
            map[3, 15] = '▲';
            map[3, 16] = '▲';
            map[10, 5] = 'ⓒ';
            map[10, 25]='♥';
        }
        public void PrintMap()
        {
            
            Console.SetCursorPosition(0, 5);
            //Console.WriteLine("현재 나의 점수 : {0}\n\n", point);


            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (map[y, x] == '□')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == '▲')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == '♥')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    if (map[y, x] == 'ⓒ')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write("{0} ", map[y, x]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
