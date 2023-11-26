using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeSquared
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] squares = new int[9, 9];
            int i = 0, j = 0, k = 0;
            int turn = 1, activeSquare = 9, userInput = 9, winner = 0;
            bool success = false, end = false;
            string player1 = "JendaZeZatáčky", player2 = "BowlingovaKoule";

            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    squares[i, j] = 0;
                }
            }
            //Getting stuck on full square
            //Game Draw

            while (end == false)
            {
                Console.Clear();
                //Drawing Squares
                for (i = 0; i < 3; i++)
                {
                    for (k = 0; k < 3; k++)
                    {
                        for (j = 0; j < 3; j++)
                        {
                            if (activeSquare == i * 3)
                            {
                                if(turn == 1) 
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else if(turn == 2) 
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                            }
                                
                            switch (squares[i * 3, k * 3 + j])
                            {
                                case 0:
                                    Console.Write(" "); break;
                                case 1:
                                    Console.Write("X"); break;
                                case 2:
                                    Console.Write("O"); break;
                                case 3:
                                    Console.Write("X"); break;
                                case 4:
                                    Console.Write("O"); break;
                                default:
                                    Console.Write("?"); break;
                            }
                            if (j < 2)
                                Console.Write(" | ");
                            Console.ResetColor();
                        }

                        Console.Write(" \u001b[95m| |\u001b[0m ");

                        for (j = 0; j < 3; j++)
                        {
                            if (activeSquare == i * 3 + 1)
                            {
                                if (turn == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else if (turn == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                            }
                            switch (squares[i * 3 + 1, k * 3 + j])
                            {
                                case 0:
                                    Console.Write(" "); break;
                                case 1:
                                    Console.Write("X"); break;
                                case 2:
                                    Console.Write("O"); break;
                                case 3:
                                    Console.Write("X"); break;
                                case 4:
                                    Console.Write("O"); break;
                                default:
                                    Console.Write("?"); break;
                            }
                            if (j < 2)
                                Console.Write(" | ");
                            Console.ResetColor();
                        }

                        Console.Write(" \u001b[95m| |\u001b[0m ");

                        for (j = 0; j < 3; j++)
                        {
                            if (activeSquare == i * 3 + 2)
                            {
                                if (turn == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else if (turn == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                            }
                            switch (squares[i * 3 + 2, k * 3 + j])
                            {
                                case 0:
                                    Console.Write(" "); break;
                                case 1:
                                    Console.Write("X"); break;
                                case 2:
                                    Console.Write("O"); break;
                                case 3:
                                    Console.Write("X"); break;
                                case 4:
                                    Console.Write("O"); break;
                                default:
                                    Console.Write("?"); break;
                            }

                            if (j < 2)
                                Console.Write(" | ");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        if (k < 2)
                        {
                            if (turn == 1)
                            {
                                if (activeSquare == i * 3)
                                {
                                    Console.WriteLine("\u001b[32m---------\u001b[0m \x1b[95m| |\x1b[0m --------- \u001b[95m| |\u001b[0m ---------");
                                }
                                else if (activeSquare == i * 3 + 1)
                                {
                                    Console.WriteLine("--------- \x1b[95m| |\x1b[0m \u001b[32m---------\u001b[0m \u001b[95m| |\u001b[0m ---------");
                                }
                                else if (activeSquare == i * 3 + 2)
                                {
                                    Console.WriteLine("--------- \x1b[95m| |\x1b[0m --------- \u001b[95m| |\u001b[0m \u001b[32m---------\u001b[0m");
                                }
                                else
                                {
                                    Console.WriteLine("--------- \x1b[95m| |\x1b[0m --------- \u001b[95m| |\u001b[0m ---------");
                                }
                            }
                            else if (turn == 2)
                            {
                                if (activeSquare == i * 3)
                                {
                                    Console.WriteLine("\u001b[94m---------\u001b[0m \x1b[95m| |\x1b[0m --------- \u001b[95m| |\u001b[0m ---------");
                                }
                                else if (activeSquare == i * 3 + 1)
                                {
                                    Console.WriteLine("--------- \x1b[95m| |\x1b[0m \u001b[94m---------\u001b[0m \u001b[95m| |\u001b[0m ---------");
                                }
                                else if (activeSquare == i * 3 + 2)
                                {
                                    Console.WriteLine("--------- \x1b[95m| |\x1b[0m --------- \u001b[95m| |\u001b[0m \u001b[94m---------\u001b[0m");
                                }
                                else
                                {
                                    Console.WriteLine("--------- \x1b[95m| |\x1b[0m --------- \u001b[95m| |\u001b[0m ---------");
                                }
                            }
                            
                        }

                        else if (i < 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("----------| |-----------| |----------");
                            Console.WriteLine("----------| |-----------| |----------");
                            Console.ResetColor();
                        }
                    }
                }

                try
                {
                    if (squares[activeSquare, 0] == 3 || squares[activeSquare, 0] == 4)
                    {
                        activeSquare = 9;
                    }
                }
                catch { }

                success = false;
                if (activeSquare == 9)
                {
                    Console.WriteLine("Choose square you want to play in");
                    while (success == false)
                    {
                        success = int.TryParse(Console.ReadLine(), out userInput);
                        userInput--;
                        if (userInput < 0 || userInput > 8 || success == false)
                        {
                            success = false;
                            Console.WriteLine("Invalid input. Enter number between 1-9");
                        }
                        else
                        {
                            switch (userInput)
                            {
                                case 0:
                                    userInput = 6; break;
                                case 1:
                                    userInput = 7; break;
                                case 2:
                                    userInput = 8; break;
                                case 3:
                                    userInput = 3; break;
                                case 4:
                                    userInput = 4; break;
                                case 5:
                                    userInput = 5; break;
                                case 6:
                                    userInput = 0; break;
                                case 7:
                                    userInput = 1; break;
                                case 8:
                                    userInput = 2; break;
                            }
                            activeSquare = userInput;
                        }
                    }
                    continue;
                }

                success = false;
                while (success == false)
                {
                    if(turn == 1)
                        Console.WriteLine("Enter your move(X)");
                    else if(turn == 2)
                        Console.WriteLine("Enter your move(O)");

                    success = int.TryParse(Console.ReadLine(), out userInput);
                    userInput--;
                    if (userInput < 0 || userInput > 8 || success == false)
                    {
                        success = false;
                        Console.WriteLine("Invalid input. Enter number between 1-9");
                    }
                    else
                    {
                        switch(userInput)
                        {
                            case 0:
                                userInput = 6; break;
                            case 1:
                                userInput = 7; break;
                            case 2:
                                userInput = 8; break;
                            case 3:
                                userInput = 3; break;
                            case 4:
                                userInput = 4; break;
                            case 5:
                                userInput = 5; break;
                            case 6:
                                userInput = 0; break;
                            case 7:
                                userInput = 1; break;
                            case 8:
                                userInput = 2; break;
                        }
                            
                        if (squares[activeSquare, userInput] != 0)
                        {
                            success = false;
                            Console.WriteLine("Square is already taken. Try again.");
                        }
                        else if (squares[activeSquare, userInput] == 0)
                        {
                            squares[activeSquare, userInput] = turn;
                        }
                    } 
                }                

                //Win horizontal
                if (squares[activeSquare, 0] == squares[activeSquare, 1] && squares[activeSquare, 0] == squares[activeSquare, 2] && squares[activeSquare, 0] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                else if (squares[activeSquare, 3] == squares[activeSquare, 4] && squares[activeSquare, 3] == squares[activeSquare, 5] && squares[activeSquare, 3] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                else if (squares[activeSquare, 6] == squares[activeSquare, 7] && squares[activeSquare, 6] == squares[activeSquare, 8] && squares[activeSquare, 6] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                //Win vertical
                else if (squares[activeSquare, 0] == squares[activeSquare, 3] && squares[activeSquare, 0] == squares[activeSquare, 6] && squares[activeSquare, 0] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                else if (squares[activeSquare, 1] == squares[activeSquare, 4] && squares[activeSquare, 1] == squares[activeSquare, 7] && squares[activeSquare, 1] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                else if (squares[activeSquare, 2] == squares[activeSquare, 5] && squares[activeSquare, 2] == squares[activeSquare, 8] && squares[activeSquare, 2] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                //Win diagonal
                else if (squares[activeSquare, 0] == squares[activeSquare, 4] && squares[activeSquare, 0] == squares[activeSquare, 8] && squares[activeSquare, 0] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }
                else if (squares[activeSquare, 2] == squares[activeSquare, 4] && squares[activeSquare, 2] == squares[activeSquare, 6] && squares[activeSquare, 2] != 0)
                {
                    for (i = 0; i < 9; i++)
                    {
                        squares[activeSquare, i] = turn + 2;
                    }
                }

                //Win game
                if (squares[0, 0] > 2 || squares[4, 0] > 2 || squares[8, 0] > 2)
                {
                    //horizontal
                    if (squares[0, 0] == squares[1, 0] && squares[0, 0] == squares[2, 0] && squares[0, 0] > 2)
                    {
                        winner = squares[0, 0];
                        end = true;
                    }
                    else if (squares[3, 0] == squares[4, 0] && squares[3, 0] == squares[2, 5] && squares[3, 0] > 2)
                    {
                        winner = squares[3, 0];
                        end = true;
                    }
                    else if (squares[6, 0] == squares[7, 0] && squares[6, 0] == squares[8, 0] && squares[6, 0] > 2)
                    {
                        winner = squares[6, 0];
                        end = true;
                    }
                    //vertical
                    else if (squares[0, 0] == squares[3, 0] && squares[0, 0] == squares[6, 0] && squares[0, 0] > 2)
                    {
                        winner = squares[0, 0];
                        end = true;
                    }
                    else if (squares[1, 0] == squares[4, 0] && squares[1, 0] == squares[7, 0] && squares[1, 0] > 2)
                    {
                        winner = squares[1, 0];
                        end = true;
                    }
                    else if (squares[2, 0] == squares[5, 0] && squares[2, 0] == squares[8, 0] && squares[2, 0] > 2)
                    {
                        winner = squares[2, 0];
                        end = true;
                    }
                    //diagonal
                    else if (squares[0, 0] == squares[4, 0] && squares[0, 0] == squares[8, 0] && squares[0, 0] > 2)
                    {
                        winner = squares[0, 0];
                        end = true;
                    }
                    else if (squares[2, 0] == squares[4, 0] && squares[2, 0] == squares[6, 0] && squares[2, 0] > 2)
                    {
                        winner = squares[2, 0];
                        end = true;
                    }
                }

                activeSquare = userInput;
                if (turn == 1)
                    turn = 2;
                else if (turn == 2)
                    turn = 1;
                else
                    Console.WriteLine(turn);
            }
            if(winner == 3)
            {
                Console.WriteLine($"{player1} has won.");
            }
            else if (winner == 4) 
            {
                Console.WriteLine($"{player2} has won.");
            }
        }
    }
}
