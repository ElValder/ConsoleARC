using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
namespace ConsoleApp1
{
    class Program
    {
        public static void Board()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            for (int i = 0; i <= 80; i++)
            {
                Console.Write("%");
            }
            Console.WriteLine();
            for (int i = 0; i <= 20; i++)
            {
                Console.Write("#");
                for (int z = 0; z <= 78; z++)
                {
                    Console.Write(" ");
                }
                Console.Write("#");
                Console.WriteLine();
            }
        }

        public static void Bit()
        {
            string str = Console.ReadLine();
            int top = 21, left = 39;
            Console.CursorVisible = false;

            while (true)
            {
                Console.CursorLeft = left;
                Console.CursorTop = top;
                Console.Write("|==========|");

                ConsoleKey key = Console.ReadKey(false).Key;
                Console.CursorLeft = left;
                Console.CursorTop = top;
                Console.Write("            ");

                switch (key)
                {
                    case ConsoleKey.Escape:
                        goto End;
                    case ConsoleKey.LeftArrow:
                        --left;
                        if (left < 1)
                        {
                            left = 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        ++left;
                        if (left > 68)
                        {
                            left = 68;
                        }
                        break;
                }
            }
            End:;
        }

        public static void Ball()
        {
            int x = 1, y = 1, offsetX = 1, offsetY = 1;
            Console.CursorVisible = true;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape:
                            goto End;
                    }
                }

                Console.CursorLeft = x;
                Console.CursorTop = y;
                Thread.Sleep(40);
                Console.Write(" ");

                x += offsetX;
                y += offsetY;
                if (x < 1)
                {
                    Console.Beep(800, 10);
                    x = 1;
                    offsetX = -offsetX;
                }
                if (x > 77)
                {
                    Console.Beep(800, 10);
                    x = 77;
                    offsetX = -offsetX;
                }
                if (y < 1)
                {
                    Console.Beep(800, 10);
                    y = 1;
                    offsetY = -offsetY;
                }
                if (y > 20)
                {
                    y = 20;
                    offsetY = -offsetY;
                }
            }
            End:;
        }

        static void Main(string[] args)
        {
            Board();
            new Thread(() => Ball()).Start();
            new Thread(() => Bit()).Start();

        }
    }
}