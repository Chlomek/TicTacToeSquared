using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToeSquared
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Getting stuck on full square
            //Game Draw
            //Bot drawing on full square -- give 10 tries to bot
            Random rnd = new Random();
            int[,] squares = new int[9, 9];
            int turn = 1, activeSquare = 9, userInput = 9, winner = 0, gameMode = 0, difficulty = 1;
            bool success = false, end = false, numPad = false, skip = false, animations = true;
            string player1 = "JendaZeZatáčky", player2 = "BowlingovaKoule";

            Console.WriteLine("Choose gamemode: Singleplayer / Multiplayer");
            while(gameMode == 0)
            {
                string playerMode = Console.ReadLine();
                if (playerMode.ToLower() == "singleplayer" || playerMode.ToLower() == "single")
                {
                    gameMode = 1;
                }
                else if (playerMode.ToLower() == "multiplayer" || playerMode.ToLower() == "multi")
                {
                    gameMode = 2;
                }
                else if (playerMode.ToLower() == "pre1")
                {
                    gameMode = 1;
                    skip = true;
                    difficulty = 2;
                }
                else if (playerMode.ToLower() == "pre2")
                {
                    gameMode = 1;
                    skip = true;
                    numPad = true;
                    difficulty = 2;
                }

                else
                {
                    Console.WriteLine("Wrong input");
                }
            }

            if(skip == false || gameMode == 0)
            {
                Console.WriteLine("Vyberte obtížnost bota");
                Console.WriteLine(" - Jednoduchá (1)");
                Console.WriteLine(" - Střední    (2)");

                difficulty = Convert.ToInt32(Console.ReadLine());
            }

            if (skip == false) 
            {
                Console.WriteLine("Chcete použít vylepšené zadávání pomocí numpadu? (ano/ne)");
                string numero = Console.ReadLine();
                if (numero.ToLower() == "ano")
                {
                    numPad = true;
                }
            }

            if (skip == false)
            {
                Console.WriteLine("Vyberte jméno hráče 1:");
                player1 = Console.ReadLine();
                if (gameMode == 2)
                {
                    Console.WriteLine("Vyberte jméno hráče 2:");
                    player2 = Console.ReadLine();
                }
                else
                {
                    if (difficulty == 1)
                    {
                        player2 = "Easy bot";
                    }
                    else if (difficulty == 2)
                    {
                        player2 = "Medium bot";
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    squares[i, j] = 0;
                }
            }

            while (end == false)
            {
                Console.Clear();
                drawSquares(activeSquare, turn, squares);

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
                    if(gameMode == 1 && turn == 2) 
                    {
                        //Bot square select
                        if(difficulty == 1)
                        {
                            activeSquare = rnd.Next(0, 9);
                        }
                        else if(difficulty == 2)
                        {
                            mediumDiffSquareSelect(squares,out activeSquare);
                        }
                    }
                    else
                    {
                        //Player square select
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
                                if (numPad)
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
                                }
                                activeSquare = userInput;
                            }
                        }
                    }
                    continue;
                }

                if (gameMode == 1 && turn == 2)
                {
                    //Bot move
                    success = false;
                    while(success == false)
                    {
                        if (difficulty == 1)
                        {
                            userInput = rnd.Next(0, 9);
                        }
                        else if (difficulty == 2)
                        {
                            mediumDiff(squares, activeSquare,out userInput);
                        }

                        if (squares[activeSquare, userInput] != 0)
                        {
                            success = false;
                        }
                        else if (animations == true)
                        {
                            Thread.Sleep(1000);
                            squares[activeSquare, userInput] = turn;
                            success = true;
                            Console.Clear();
                            drawSquares(activeSquare, turn, squares);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            squares[activeSquare, userInput] = turn;
                            success = true;
                        }
                    }       
                }
                else
                {
                    //Player move
                    success = false;
                    while (success == false)
                    {
                        if (turn == 1)
                            Console.WriteLine("Enter your move(X)");
                        else if (turn == 2)
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
                            if (numPad)
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
                            }

                            //Making move
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
                }


                //Win
                int i;
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
                    else if (squares[3, 0] == squares[4, 0] && squares[3, 0] == squares[5, 0] && squares[3, 0] > 2)
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
                {
                    Console.WriteLine("error-turn:" + turn);
                    Console.Read();
                }
            }
            Console.Clear();
            drawSquares(activeSquare, turn, squares);

            if(winner == 3)
            {
                Console.WriteLine($"{player1} has won.");
            }
            else if (winner == 4) 
            {
                Console.WriteLine($"{player2} has won.");
            }
            else
            {
                Console.WriteLine("error-winner");
                Console.Read();
            }
            Console.ReadLine();
        }

        public static void drawSquares(int activeSquare, int turn, int[,] squares)
        {
            int i = 0, j = 0, k = 0;
            for (i = 0; i < 3; i++)
            {
                for (k = 0; k < 3; k++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (activeSquare == i * 3)
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
        }
        public static void mediumDiff(int[,] squares, int activeSquare, out int userInput)
        {
            if (squares[activeSquare, 0] == squares[activeSquare, 1] && squares[activeSquare, 2]  == 0 && squares[activeSquare, 0] != 0)
            {
                userInput = 2;
            }
            else if (squares[activeSquare, 0] == squares[activeSquare, 3] && squares[activeSquare, 6] == 0 && squares[activeSquare, 0] != 0)
            {
                userInput = 6;
            }
            else if (squares[activeSquare, 0] == squares[activeSquare, 4] && squares[activeSquare, 8] == 0 && squares[activeSquare, 0] != 0)
            {
                userInput = 8;
            }
            else if (squares[activeSquare, 1] == squares[activeSquare, 4] && squares[activeSquare, 7] == 0 && squares[activeSquare, 1] != 0)
            {
                userInput = 7;
            }
            else if (squares[activeSquare, 1] == squares[activeSquare, 4] && squares[activeSquare, 7] == 0 && squares[activeSquare, 1] != 0)
            {
                userInput = 7;
            }
            else if (squares[activeSquare, 1] == squares[activeSquare, 2] && squares[activeSquare, 0] == 0 && squares[activeSquare, 1] != 0)
            {
                userInput = 0;
            }
            else if (squares[activeSquare, 1] == squares[activeSquare, 4] && squares[activeSquare, 7] == 0 && squares[activeSquare, 1] != 0)
            {
                userInput = 7;
            }
            else if (squares[activeSquare, 2] == squares[activeSquare, 5] && squares[activeSquare, 8] == 0 && squares[activeSquare, 2] != 0)
            {
                userInput = 8;
            }
            else if (squares[activeSquare, 2] == squares[activeSquare, 4] && squares[activeSquare, 6] == 0 && squares[activeSquare, 2] != 0)
            {
                userInput = 6;
            }
            else if (squares[activeSquare, 7] == squares[activeSquare, 8] && squares[activeSquare, 6] == 0 && squares[activeSquare, 7] != 0)
            {
                userInput = 6;
            }
            else if (squares[activeSquare, 3] == squares[activeSquare, 4] && squares[activeSquare, 5] == 0 && squares[activeSquare, 3] != 0)
            {
                userInput = 5;
            }
            else if (squares[activeSquare, 2] == squares[activeSquare, 8] && squares[activeSquare, 5] == 0 && squares[activeSquare, 2] != 0)
            {
                userInput = 5;
            }
            else if (squares[activeSquare, 3] == squares[activeSquare, 6] && squares[activeSquare, 0] == 0 && squares[activeSquare, 3] != 0)
            {
                userInput = 0;
            }
            else if (squares[activeSquare, 4] == squares[activeSquare, 5] && squares[activeSquare, 3] == 0 && squares[activeSquare, 4] != 0)
            {
                userInput = 3;
            }
            else if (squares[activeSquare, 0] == squares[activeSquare, 6] && squares[activeSquare, 3] == 0 && squares[activeSquare, 0] != 0)
            {
                userInput = 3;
            }
            else if (squares[activeSquare, 4] == squares[activeSquare, 6] && squares[activeSquare, 2] == 0 && squares[activeSquare, 4] != 0)
            {
                userInput = 2;
            }
            else if (squares[activeSquare, 4] == squares[activeSquare, 7] && squares[activeSquare, 1] == 0 && squares[activeSquare, 4] != 0)
            {
                userInput = 1;
            }
            else if (squares[activeSquare, 0] == squares[activeSquare, 2] && squares[activeSquare, 1] == 0 && squares[activeSquare, 0] != 0)
            {
                userInput = 1;
            }
            else if (squares[activeSquare, 4] == squares[activeSquare, 8] && squares[activeSquare, 0] == 0 && squares[activeSquare, 4] != 0)
            {
                userInput = 0;
            }
            else if (squares[activeSquare, 5] == squares[activeSquare, 8] && squares[activeSquare, 2] == 0 && squares[activeSquare, 5] != 0)
            {
                userInput = 2;
            }
            else if (squares[activeSquare, 6] == squares[activeSquare, 7] && squares[activeSquare, 8] == 0 && squares[activeSquare, 6] != 0)
            {
                userInput = 8;
            }
            else if (squares[activeSquare, 3] == squares[activeSquare, 5] && squares[activeSquare, 4] == 0 && squares[activeSquare, 3] != 0)
            {
                userInput = 4;
            }
            else if (squares[activeSquare, 2] == squares[activeSquare, 6] && squares[activeSquare, 4] == 0 && squares[activeSquare, 2] != 0)
            {
                userInput = 4;
            }
            else if (squares[activeSquare, 1] == squares[activeSquare, 7] && squares[activeSquare, 4] == 0 && squares[activeSquare, 1] != 0)
            {
                userInput = 4;
            }
            else if (squares[activeSquare, 0] == squares[activeSquare, 8] && squares[activeSquare, 4] == 0 && squares[activeSquare, 0] != 0)
            {
                userInput = 4;
            }
            else
            {
                Random rnd = new Random();
                userInput = rnd.Next(0, 9);
            }
        }
        public static void mediumDiffSquareSelect(int[,] squares, out int activeSquare)
        {
            if (squares[0, 0] == squares[1,0] && squares[2,0] > 3 && squares[0, 0] > 2)
            {
                activeSquare = 2;
            }
            else if (squares[0, 0] == squares[3, 0] && squares[6, 0] < 3 && squares[0, 0] > 2)
            {
                activeSquare = 6;
            }
            else if (squares[0, 0] == squares[4, 0] && squares[8, 0] < 3 && squares[0, 0] > 2)
            {
                activeSquare = 8;
            }
            else if (squares[1, 0] == squares[2, 0] && squares[0, 0] < 3 && squares[1, 0] > 2)
            {
                activeSquare = 0;
            }
            else if (squares[1, 0] == squares[4, 0] && squares[7, 0] < 3 && squares[1, 0] > 2)
            {
                activeSquare = 7;   
            }
            else if (squares[2, 0] == squares[5, 0] && squares[8, 0] < 3 && squares[2, 0] > 2)
            {
                activeSquare = 8;
            }
            else if (squares[2, 0] == squares[4, 0] && squares[6, 0] < 3 && squares[2, 0] > 2)
            {
                activeSquare = 6;
            }
            else if (squares[3, 0] == squares[4, 0] && squares[5, 0] < 3 && squares[3, 0] > 2)
            {
                activeSquare = 5;
            }
            else if (squares[3, 0] == squares[6, 0] && squares[0, 0] < 3 && squares[3, 0] > 2)
            {
                activeSquare = 0;
            }
            else if (squares[4, 0] == squares[5, 0] && squares[3, 0] < 3 && squares[4, 0] > 2)
            {
                activeSquare = 3;
            }
            else if (squares[4, 0] == squares[6, 0] && squares[2, 0] < 3 && squares[4, 0] > 2)
            {
                activeSquare = 2;
            }
            else if (squares[4, 0] == squares[7, 0] && squares[1, 0] < 3 && squares[4, 0] > 2)
            {
                activeSquare = 1;
            }
            else if (squares[4, 0] == squares[8, 0] && squares[0, 0] < 3 && squares[4, 0] > 2)
            {
                activeSquare = 0;
            }
            else if (squares[5, 0] == squares[8, 0] && squares[2, 0] < 3 && squares[5, 0] > 2)
            {
                activeSquare = 2;
            }
            else if (squares[6, 0] == squares[7, 0] && squares[8, 0] < 3 && squares[6, 0] > 2)
            {
                activeSquare = 8;
            }
            else if (squares[7, 0] == squares[8, 0] && squares[6, 0] < 3 && squares[7, 0] > 2)
            {
                activeSquare = 6;
            }
            else if (squares[0, 0] == squares[2, 0] && squares[1, 0] < 3 && squares[0, 0] > 2)
            {
                activeSquare = 1;
            }
            else if (squares[0, 0] == squares[6, 0] && squares[3, 0] < 3 && squares[0, 0] > 2)
            {
                activeSquare = 3;
            }
            else if (squares[2, 0] == squares[8, 0] && squares[5, 0] < 3 && squares[2, 0] > 2)
            {
                activeSquare = 5;
            }
            else if (squares[0, 0] == squares[8, 0] && squares[4, 0] < 3 && squares[0, 0] > 2)
            {
                activeSquare = 4;
            }
            else if (squares[6, 0] == squares[8, 0] && squares[7, 0] < 3 && squares[6, 0] > 2)
            {
                activeSquare = 7;
            }
            else if (squares[1, 0] == squares[7, 0] && squares[4, 0] < 3 && squares[1, 0] > 2)
            {
                activeSquare = 4;
            }
            else if (squares[2, 0] == squares[6, 0] && squares[4, 0] < 3 && squares[2, 0] > 2)
            {
                activeSquare = 4;
            }
            else if (squares[3, 0] == squares[5, 0] && squares[4, 0] < 3 && squares[3, 0] > 2)
            {
                activeSquare = 4;
            }
            else
            {
                Random random = new Random();
                activeSquare = random.Next(0, 9);
            }
        }
    }
}
