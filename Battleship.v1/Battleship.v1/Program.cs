using System;

namespace Battleship
{
    class Program
    {
        static int row = 11;
        static int column = 11;
        static string[,] player1Board = new string[row, column];
        static string[,] player1GameBoard = new string[row, column];

        static string[,] player2Board = new string[row, column];
        static string[,] player2GameBoard = new string[row, column];

        static void Main(string[] args)
        {
            Console.WriteLine("...........................Welcome to the BATTLE ........................");
            Console.WriteLine();

            // create boards for each player

            gridSetUp();
            displayBattleGround(player1Board);
            placeShips();
            placeOpponentShips();
            Console.WriteLine();
            Console.WriteLine("Do you want the opponent board to be visible? [y/N]");
            string choice1 = Console.ReadLine();

            if (choice1 == "y" || choice1 == "Y" || choice1 == "yes")
            {
                displayBattleGround(player2Board);
            }

            Console.WriteLine();
            Console.WriteLine("Let the BATTLES begin........... [y,N]");
            string choice2 = Console.ReadLine();

            if (choice1 == "y" || choice1 == "Y" || choice1 == "yes")
            {
                fire();
            }
            


            // create fire logic 

        }

        // Initializating Battle grounds  for both players
        public static void gridSetUp()
        {
            int firstRow = 0;
            int firstCol = 0;
            //labeling Grids
            for (int j = 0; j < column; j++)
            {
                player1Board[firstRow, j] = Convert.ToString(j);
                player2Board[firstRow, j] = Convert.ToString(j);

                player2GameBoard[firstRow, j] = Convert.ToString(j);
            }
            for (int j = 0; j < column; j++)
            {
                player1Board[j, firstCol] = Convert.ToString(j);
                player2Board[firstRow, j] = Convert.ToString(j);

                player2GameBoard[j, firstCol] = Convert.ToString(j);
            }

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < column; j++)
                {
                    player1Board[i, j] = ".";
                    player1GameBoard[i, j] = ".";
                    player2Board[i, j] = ".";
                    player2GameBoard[i, j] = ".";

                }
            }

        }

        // Display Battle ground
        public static void displayBattleGround(string[,] ground)
        {
            // grid size questionable ??????????
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(ground[i, j] + "\t");

                }
                Console.WriteLine();

            }
        }

        // fill ship cells
      /*  public static void fillCells(string direction, int shipSize, int coordRow, int coordColumn)
        {
            for (int i = 0; i < shipSize; i++)
            {
                player1Board[coordRow, coordColumn] = "8";
                if (direction == "r")
                {
                    coordColumn++;
                }
                else if (direction == "d")
                {
                    coordRow++;
                }
            }

        }*/

        public static void placeShips()
        {
            string[] coordinates;
            int coorRow;
            int coordColumn;
            string direction;
            int class4ShipsCounter = 1;
            while (class4ShipsCounter > 0)
            {
                // ask for direction, coordinates and length
                Console.WriteLine("Please enter [X,Y] coordinates for 4 masterd ship separated by comma ");
                /*int x = Convert.ToInt32( Console.ReadLine());*/
                coordinates = Console.ReadLine().Split(",");

                // !!!!!!!!DON'T Forget To Make  Exception handling check when user inputs incorrect Format 
                coorRow = Convert.ToInt32(coordinates[0]);
                coordColumn = Convert.ToInt32(coordinates[1]);
                Console.WriteLine("Please Enter direction of ship placement (right/down)(r/d)");
                direction = Console.ReadLine();

                if (direction == "d" || direction == "down" || direction == "D")
                {
                    int invalidSpotCounter = 0;
                    for (int i = 0; i < 3; i++)
                    {

                        if ((10 - coorRow < 3))
                        {
                            Console.Clear();
                            displayBattleGround(player1Board);
                            Console.WriteLine("Invalid Spot, Please enter values again");
                            invalidSpotCounter++;
                            break;
                        }
                    }
                    if (invalidSpotCounter > 0)
                    {
                        continue;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        player1Board[coorRow, coordColumn] = "8";
                        coorRow++;
                        class4ShipsCounter--;
                    }
                    Console.Clear();
                    displayBattleGround(player1Board);
                }
                else if (direction == "r" || direction == "Right" || direction == "R")
                {
                    int invalidSpotCounter = 0;
                    for (int i = 0; i < 3; i++)
                    {

                        if ((10 - coordColumn < 3))
                        {
                            Console.Clear();
                            displayBattleGround(player1Board);
                            Console.WriteLine("Invalid Spot, Please enter values again");
                            invalidSpotCounter++;
                            break;
                        }
                    }
                    if (invalidSpotCounter > 0)
                    {
                        continue;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        player1Board[coorRow, coordColumn] = "8";
                        coordColumn++;
                        class4ShipsCounter--;

                    }
                    Console.Clear();
                    displayBattleGround(player1Board);
                }

            }



            // 3-Master class ships

            int class3ShipsCounter = 2;
            while (class3ShipsCounter > 0)
            {
                Console.WriteLine("Enter [X,y] coord for 3-master class ship 0-10");
                coordinates = Console.ReadLine().Split(",");
                coorRow = Convert.ToInt32(coordinates[0]);
                coordColumn = Convert.ToInt32(coordinates[1]);
                int invalidSpotCounter = 0;

                if (player1Board[coorRow, coordColumn] == "8")
                {
                    Console.Clear();
                    displayBattleGround(player1Board);
                    Console.WriteLine("Space already occupied, please enter values again");

                    continue;
                }
                else
                {
                    Console.WriteLine("Please Enter direction of ship placement (right/down)(r/d)");
                    direction = Console.ReadLine();
                    if (direction == "d" || direction == "down" || direction == "D")
                    {
                        // are there any ships right of me chek validity of spot
                        for (int i = 0; i < 2; i++)
                        {

                            if ((10 - coorRow < 2) || player1Board[coorRow + 1, coordColumn] == "8")
                            {
                                Console.Clear();
                                displayBattleGround(player1Board);
                                Console.WriteLine("Invalid Spot, Please enter values again");
                                invalidSpotCounter++;
                                break;
                            }
                        }

                        if (invalidSpotCounter > 0)
                        {
                            continue;
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            player1Board[coorRow, coordColumn] = "8";
                            coorRow++;
                        }
                        Console.Clear();
                        displayBattleGround(player1Board);
                    }
                    else if (direction == "r" || direction == "right" || direction == "R")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (((10 - coordColumn) < 2) || player1Board[coorRow, coordColumn + 1] == "8")
                            {
                                Console.Clear();
                                displayBattleGround(player1Board);
                                Console.WriteLine("Invalid Spot, Please enter values again");
                                invalidSpotCounter++;
                                break;
                            }
                        }
                        if (invalidSpotCounter > 0)
                        {
                            continue;
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            player1Board[coorRow, coordColumn] = "8";
                            coordColumn++;
                        }
                        Console.Clear();
                        displayBattleGround(player1Board);
                    }

                }

                class3ShipsCounter--;
            }


            // 2_Master class Ships
            int class2shipsCounter = 3;
            while (class2shipsCounter > 0)
            {
                Console.WriteLine("Enter [X,y] coord for 2-master class ship 0-10");
                coordinates = Console.ReadLine().Split(",");
                coorRow = Convert.ToInt32(coordinates[0]);
                coordColumn = Convert.ToInt32(coordinates[1]);
                //int invalidSpotCounter = 0;
                if (player1Board[coorRow, coordColumn] == "8")
                {
                    Console.Clear();
                    displayBattleGround(player1Board);
                    Console.WriteLine("Space already occupied, please enter values again");
                    continue;
                }
                else
                {
                    Console.WriteLine("Please Enter direction of ship placement (right/down)(r/d)");
                    direction = Console.ReadLine();
                    if (direction == "d" || direction == "down" || direction == "D")
                    {
                        // are there any ships right of me chek validity of spot

                        if ((10 - coorRow < 1) || player1Board[coorRow + 1, coordColumn] == "8")
                        {
                            Console.Clear();
                            displayBattleGround(player1Board);
                            Console.WriteLine("Invalid Spot, Please enter values again");
                            // invalidSpotCounter++;
                            continue;

                        }
                        /*if (invalidSpotCounter > 0)
                        {
                            continue;
                        }*/
                        for (int i = 0; i < 2; i++)
                        {
                            player1Board[coorRow, coordColumn] = "8";
                            coorRow++;

                        }
                        Console.Clear();
                        displayBattleGround(player1Board);
                    }
                    else if (direction == "r" || direction == "right" || direction == "R")
                    {
                        // are there any ships below me
                        if (((10 - coordColumn) < 1) || player1Board[coorRow, coordColumn + 1] == "8")
                        {
                            Console.Clear();
                            displayBattleGround(player1Board);
                            Console.WriteLine("Invalid Spot, Please enter values again");
                            // invalidSpotCounter++;
                            continue;

                        }

                        /*if (invalidSpotCounter > 0)
                        {
                            continue;
                        }*/
                        for (int i = 0; i < 2; i++)
                        {
                            player1Board[coorRow, coordColumn] = "8";
                            coordColumn++;
                        }
                        Console.Clear();
                        displayBattleGround(player1Board);
                    }
                }

                class2shipsCounter--;
            }

            // 1_Master class ships
            int class1ShipsCounter = 4;
            while (class1ShipsCounter > 0)
            {
                Console.WriteLine("Enter [X,y] coord for 1-master class ship 0-10");
                coordinates = Console.ReadLine().Split(",");
                coorRow = Convert.ToInt32(coordinates[0]);
                coordColumn = Convert.ToInt32(coordinates[1]);
                if (player1Board[coorRow, coordColumn] == "8")
                {

                    Console.Clear();
                    displayBattleGround(player1Board);
                    Console.WriteLine("Space already occupied, please enter values again");
                    
                }
                else
                {
                    player1Board[coorRow, coordColumn] = "8";
                    class1ShipsCounter--;
                    Console.Clear();
                    displayBattleGround(player1Board);
                    
                }
            }

        }

        public static void placeOpponentShips()
        {
            // place ships and track their position 

            // 1.generate random number for index
            Random random = new Random();
            int randomRowCoord = random.Next(1, 11);
            int randomColumnCoord = random.Next(1, 11);
            int direction = random.Next(0, 2); // 0 - Right Direction  1 - Down direction


            // 4-Master calss Ship
            int correctPlacement = 0;
            while (correctPlacement == 0)
            {
                randomColumnCoord = random.Next(1, 11);
                randomRowCoord = random.Next(1, 11);
                if (direction == 0)
                {
                    if (10 - randomColumnCoord >= 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            player2Board[randomRowCoord, randomColumnCoord] = "8";
                            randomColumnCoord++;
                        }
                        correctPlacement++;
                    }
                }
                else if (direction == 1)
                {
                    if (10 - randomRowCoord >= 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            player2Board[randomRowCoord, randomColumnCoord] = "8";
                            randomRowCoord++;
                        }
                        correctPlacement++;
                    }
                }
            }

            // 3 _masterd Ships

            int class3ShipsPlacement = 2;
            while(class3ShipsPlacement > 0)
            {
                randomColumnCoord = random.Next(1, 11);
                randomRowCoord = random.Next(1, 11);
                direction = random.Next(0, 2);

                if(player2Board[randomRowCoord,randomColumnCoord] == "8")
                {
                    continue;
                }
                else
                {
                    if(10 - randomColumnCoord < 2 || 10 - randomRowCoord < 2) { 
                   
                        continue;
                    }
                    else
                    {
                        if(direction == 0)
                        {
                            int invalidSpotCounter = 0;
                            int tempCol = randomColumnCoord;
                            for (int i = 0; i < 3; i++)
                            {
                                if (player2Board[randomRowCoord, tempCol] == "8")
                                {
                                    invalidSpotCounter++;
                                    break;
                                }
                                tempCol++;
                               // randomColumnCoord++;
                            }
                            if (invalidSpotCounter > 0)
                            {
                                continue;
                            }
                            for (int i = 0; i < 3; i++)
                            {
                                player2Board[randomRowCoord, randomColumnCoord] = "8";
                                randomColumnCoord++;
                            }
                            class3ShipsPlacement--;
                        }
                        else if(direction == 1)
                        {
                            int invalidSpotCounter = 0;
                            int tempRow = randomRowCoord;
                            for (int i = 0; i < 3; i++)
                            {
                                if (player2Board[tempRow, randomColumnCoord] == "8")
                                {
                                    invalidSpotCounter++;
                                    break;
                                }
                                tempRow++;
                                //randomRowCoord++;
                            }
                            if (invalidSpotCounter > 0)
                            {
                                continue;
                            }
                            for (int i = 0; i < 3; i++)
                            {
                                player2Board[randomRowCoord, randomColumnCoord] = "8";
                                randomRowCoord++;
                            }
                            class3ShipsPlacement--;

                        }

                    }
                }
            }

            // 2-Mastered Ships
            int class2ShipsCounter = 3;
            while(class2ShipsCounter > 0)
            {
                randomColumnCoord = random.Next(1, 11);
                randomRowCoord = random.Next(1, 11);
                direction = random.Next(0, 2);
                if (player2Board[randomRowCoord, randomColumnCoord] == "8")
                {
                    continue;
                }
                else
                {
                    if (10 - randomColumnCoord < 1 || 10 - randomRowCoord < 1)
                    {
                        continue;
                    }
                    else
                    {
                        if(direction == 0)
                        {
                            if(player2Board[randomRowCoord, randomColumnCoord + 1] == "8")
                            {
                                continue;
                            }
                            player2Board[randomRowCoord, randomColumnCoord] = "8";
                            player2Board[randomRowCoord, randomColumnCoord + 1] = "8";
                            class2ShipsCounter--;

                        }
                        else if(direction == 1)
                        {
                            if (player2Board[randomRowCoord + 1, randomColumnCoord] == "8")
                            {
                                continue;
                            }
                            player2Board[randomRowCoord, randomColumnCoord] = "8";
                            player2Board[randomRowCoord+1, randomColumnCoord] = "8";
                            class2ShipsCounter--;
                        }

                    }
                }

            }

            // 1-Mastered Ships
            int class1ShipsCounter = 4;
            while(class1ShipsCounter > 0)
            {
                randomRowCoord = random.Next(1, 11);
                randomRowCoord = random.Next(1, 11);

                if(player2Board[randomRowCoord,randomColumnCoord] == "8")
                {
                    continue;
                }
                player2Board[randomRowCoord, randomColumnCoord] = "8";
                class1ShipsCounter--;

            }
        }

        public static void fire()
        {
            int player1DamageCount = 0;
            int player2DamageCount = 0;

            int switchPlayer = 0;
            while(player1DamageCount < 20 || player2DamageCount < 20)
            {
                Random random = new Random();
                string[] fireCoordonates;
                int fireCoordX;
                int fireCoordY;
                string message = "";

                while (switchPlayer == 0)
                {
                   
                    
                    Console.WriteLine("................................OPPONENT PLAYER Game Board................................");
                    displayBattleGround(player2GameBoard);
                    
                    Console.WriteLine("Fire Your Rockets ^^^^ [X,Y]");
                    // accept input from user
                    fireCoordonates = Console.ReadLine().Split(",");
                    fireCoordX = Convert.ToInt32(fireCoordonates[0]);
                    fireCoordY = Convert.ToInt32(fireCoordonates[1]);

                    // correctness of input
                    if (fireCoordX > 10 || fireCoordY > 10)
                    {
                        message = "Please Enter Valid Coordinates";
                        continue;
                    }
                    
                    if(player2Board[fireCoordX, fireCoordY] == ".")
                    {
                        message = "You Missed !! ";
                        switchPlayer = 1;
                    }
                    else if(player2GameBoard[fireCoordX, fireCoordY] == "X")
                    {
                        message = "Wasted Shot! Shoot Again"  ;
                       // switchPlayer = 1;
                    }
                    else if (player2Board[fireCoordX, fireCoordY] == "8" && player2GameBoard[fireCoordX, fireCoordY] == ".")
                    {
                        player1DamageCount++;
                        player2GameBoard[fireCoordX, fireCoordY] = "X";
                        message = "Nice Shot! Take a Shot AGAIN!!";
                        Console.WriteLine(message);
                        //switchPlayer = 1;
                    }
                    Console.Clear();
                    Console.WriteLine(message);
                    
                    Console.WriteLine();
                }
                
                
               
                while (switchPlayer == 1)
                {
                   /* Console.WriteLine("..................PLAYER 1 Game Board............................");
                    displayBattleGround(player1GameBoard);*/
                    fireCoordX = random.Next(1, 11);
                    fireCoordY = random.Next(1, 11);

                    if (player1Board[fireCoordX, fireCoordY] == ".")
                    {
                        message = "Opponent Missed !! Your Turn";
                        
                        switchPlayer = 0;
                    }
                    else if (player1GameBoard[fireCoordX, fireCoordY] == "X")
                    {
                        
                        message = "Opponent wasted his Shot! Making another Try. ";
                        switchPlayer = 0;
                    }
                    else if (player1Board[fireCoordX, fireCoordY] == "8")
                    {
                        player2DamageCount++;
                        player1GameBoard[fireCoordX, fireCoordY] = "X";
                        Console.WriteLine( "Opponent Shot Your ship ");
                    }

                }

                Console.WriteLine(message);
                Console.WriteLine();
              
                if(player1DamageCount == 20)
                {
                    Console.WriteLine("Congratulations !!!! You WON !!!!");
                    break;
                }
                else if(player2DamageCount == 20)
                {
                    Console.WriteLine("You OPPONENT  WON !!!!");
                    break;
                }

            }


        }


    }
}
    
