using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asciiMazeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 100, w = 100;
            string errTxt = "\npress any key to retry...";

            while (h > 10)
            {
                Console.Write("Enter how tall you want the pattern to be (max 10): ");
                h = int.Parse(Console.ReadLine());

                if (h > 10)
                {
                    Console.WriteLine($"Invalid input.{errTxt}");
                    Console.ReadKey(); Console.Clear();
                }
            }

            while (w > 10)
            {
                Console.Write("Enter how wide you want the pattern to be (max 10): ");
                w = int.Parse(Console.ReadLine());

                if (w > 10)
                {
                    Console.WriteLine($"Invalid input.{errTxt}");
                    Console.ReadKey(); Console.Clear();
                }
            }

            Console.BufferWidth *= w;
            Console.BufferHeight *= h;

            Console.Clear();

            string[] patternArr = new string[h];
            //string[] patternArr = { "///", "///" };

            Console.WriteLine($"Enter the pattern ({h}x{w}): (press the enter key after finishing entering a line)");
            for (int i = 0; i < patternArr.Length; i++)
            {

                Console.Write("[");
                patternArr[i] = Console.ReadLine();


                if (patternArr[i].Length > w || patternArr[i].Length < w)
                {
                    i--;
                    Console.WriteLine($"Invalid input.{errTxt}"); // 11+length
                    Console.ReadKey();
                    DeleteLine(errTxt.Length); // the prompt to press a key
                    DeleteLine(14); // length of the 'too long' line
                    DeleteLine(w + 2); // the incorrect input
                }
                else
                {
                    Console.SetCursorPosition(w + 1, Console.CursorTop - 1);
                    Console.WriteLine("]");
                }
            }

            Console.Clear();

            int mazeH = 0, mazeW = 0;

            while (mazeH <= 0)
            {
                Console.Write("Enter how tall you want the maze to be (has to be bigger than 0): ");
                mazeH = int.Parse(Console.ReadLine());

                if (mazeH <= 0)
                {
                    Console.WriteLine($"Invalid input.{errTxt}");
                    Console.ReadKey(); Console.Clear();
                }
            }

            while (mazeW <= 0)
            {
                Console.Write("Enter how wide you want the maze to be (has to be bigger than 0): ");
                mazeW = int.Parse(Console.ReadLine());

                if (mazeW <= 0 || mazeW > 80)
                {
                    Console.WriteLine($"Invalid input.{errTxt}");
                    Console.ReadKey(); Console.Clear();
                }
            }

            Console.WriteLine("Press a key to create the maze...");
            //Console.ReadKey();
            Console.Clear();

            Random rng = new Random();
            int dir, countB = 0;
            string outS = "";

            for (int i = 0; i < mazeH * h; i += h)
            {
                int countA = 0, countC = 1;
                Console.SetCursorPosition(0, i);

                for (int y = 0; y < mazeW * w; y += w)
                {
                    dir = rng.Next(1, 5);

                    switch (dir)
                    {
                        case 1:
                            for (int u = 0; u < patternArr.Length; u++)
                            {
                                Console.WriteLine(patternArr[u]);
                                Console.SetCursorPosition(y, u + 1 + i);
                            }
                            countA++;
                            Console.SetCursorPosition((w - 1) * countA + countC, i);
                            countC++;
                            break;

                        case 2:
                            string[] tmpArr = patternArr;
                            string tmp;

                            for (int u = 0; u < tmpArr.Length; u++)
                            {
                                tmp = tmpArr[u];

                                for (int x = 0; x < tmp.Length; x++)
                                {
                                    switch (tmp[x])
                                    {
                                        case '/':
                                            outS += "\\";
                                            break;

                                        case '\\':
                                            outS += "/";
                                            break;

                                        case '^':
                                            outS += ">";
                                            break;

                                        case '>':
                                            outS += "v";
                                            break;

                                        case 'v':
                                            outS += "<";
                                            break;

                                        case '<':
                                            outS += "^";
                                            break;

                                        case '-':
                                            outS += "|";
                                            break;

                                        case '|':
                                            outS += "-";
                                            break;

                                        case '║':
                                            outS += "=";
                                            break;

                                        case '=':
                                            outS += "║";
                                            break;

                                        default:
                                            outS += tmp[x];
                                            break;
                                    }
                                }

                                tmpArr[u] = outS;
                                outS = "";
                            }

                            for (int u = 0; u < tmpArr.Length; u++)
                            {
                                Console.WriteLine(tmpArr[u]);
                                Console.SetCursorPosition(y, u + 1 + i);
                            }
                            countA++;
                            Console.SetCursorPosition((w - 1) * countA + countC, i);
                            countC++;

                            break;

                        case 3:
                            tmpArr = patternArr;

                            for (int u = 0; u < tmpArr.Length; u++)
                            {
                                tmp = tmpArr[u];

                                for (int x = 0; x < tmp.Length; x++)
                                {
                                    switch (tmp[x])
                                    {
                                        case '^':
                                            outS += "v";
                                            break;

                                        case '>':
                                            outS += "<";
                                            break;

                                        case 'v':
                                            outS += "^";
                                            break;

                                        case '<':
                                            outS += ">";
                                            break;

                                        default:
                                            outS += tmp[x];
                                            break;
                                    }
                                }

                                tmpArr[u] = outS;
                                outS = "";
                            }

                            for (int u = 0; u < tmpArr.Length; u++)
                            {
                                Console.WriteLine(tmpArr[u]);
                                Console.SetCursorPosition(y, u + 1 + i);
                            }
                            countA++;
                            Console.SetCursorPosition((w - 1) * countA + countC, i);
                            countC++;

                            break;

                        case 4:
                            tmpArr = patternArr;

                            for (int u = 0; u < tmpArr.Length; u++)
                            {
                                tmp = tmpArr[u];

                                for (int x = 0; x < tmp.Length; x++)
                                {
                                    switch (tmp[x])
                                    {
                                        case '/':
                                            outS += "\\";
                                            break;

                                        case '\\':
                                            outS += "/";
                                            break;

                                        case '^':
                                            outS += "<";
                                            break;

                                        case '>':
                                            outS += "^";
                                            break;

                                        case 'v':
                                            outS += ">";
                                            break;

                                        case '<':
                                            outS += "v";
                                            break;

                                        case '-':
                                            outS += "|";
                                            break;

                                        case '|':
                                            outS += "-";
                                            break;

                                        case '║':
                                            outS += "=";
                                            break;

                                        case '=':
                                            outS += "║";
                                            break;

                                        default:
                                            outS += tmp[x];
                                            break;
                                    }
                                }

                                tmpArr[u] = outS;
                                outS = "";
                            }

                            for (int u = 0; u < tmpArr.Length; u++)
                            {
                                Console.WriteLine(tmpArr[u]);
                                Console.SetCursorPosition(y, u + 1 + i);
                            }
                            countA++;
                            Console.SetCursorPosition((w - 1) * countA + countC, i);
                            countC++;
                            break;

                        default:
                            break;
                    }
                }
                countB++;
            }

            Console.SetCursorPosition(0, (h * mazeH) + 1);

            Console.WriteLine("Feel free to select, copy, and paste the pattern you got into a text file now");
            Console.Write("Press any key to close the program...");

            Console.ReadKey();
        }

        // In: the length of the line you want to delete
        // out: deleting the line
        public static void DeleteLine(int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.SetCursorPosition(i, Console.CursorTop - 1);
                Console.WriteLine(" ");
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
