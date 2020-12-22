using System;
using System.Diagnostics;
using System.Threading;


namespace Console_Game___Codecademy_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endGame = false;

            while (!endGame)
            {
           
                Random rand = new Random();
                Console.CursorVisible = false;

                // Determine bounds and set starting positions
                int rows = 30;
                int cols = 100;
                char cursor = 'o';
                int characterRow = rows / 2;
                int characterCol = cols / 2;
                char fruit = '$';
                int fruitRow = rand.Next(1, rows);
                int fruitCol = rand.Next(1, cols);
                int score = 0;
                int shiftfruit = 10;

                // Include a stopwatch to show time
                Stopwatch timepassed = new Stopwatch();
                timepassed.Start();

                // Code in this loop executes infinitely
                // unless Q or CTRL + C is pressed
                while (true)
                {
                    // Draw score, character, timer and fruit

                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("EAT THE MONEY FRUIT - CONSOLE GAME");
                    Console.WriteLine($"Score: {score}");
                    TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(timepassed.Elapsed.TotalSeconds));
                    Console.WriteLine("Time Elapsed: " + ts.ToString("ss") + " seconds of 60 seconds (1 minute)");
                    Console.Write('\r');
                    Console.SetCursorPosition(characterCol, characterRow);
                    Console.Write(cursor);
                    Console.SetCursorPosition(fruitCol, fruitRow);
                    Console.Write(fruit);


                    // Capture user input
                    ConsoleKeyInfo cki = Console.ReadKey(false);

                    //Move fruit if 10 seconds elapsed
                    if (Convert.ToInt32(timepassed.Elapsed.TotalSeconds) == shiftfruit)
                    {
                        shiftfruit += 10;
                        fruitCol = rand.Next(cols);
                        fruitRow = rand.Next(rows);
                        Console.SetCursorPosition(characterCol, characterRow);
                    }    


                    // Restart game if R is pressed
                    if (cki.Key == ConsoleKey.R)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.CursorVisible = true;
                        timepassed.Stop();
                        break;
                    }

                    //End game if 60 seconds elapse
                    if (Convert.ToInt32(timepassed.Elapsed.TotalSeconds) >= 60)
                    {
                        timepassed.Stop();
                        Console.Clear();
                        Console.WriteLine("GAME OVER");
                        Console.WriteLine($"Total Score: {score}");
                        Console.WriteLine("Press Q and Enter to end game or any other key and Enter to play again.");
                        string choice = Console.ReadLine();
                        if (choice == "q")
                        { return; }
                        else { break; }
                    }


                    // Change character position based on key
                    // Uses UpdatePosition()
                    string key = cki.Key.ToString();
                    int colChange = 0;
                    int rowChange = 0;
                    Game.UpdatePosition(key, out colChange, out rowChange);
                    characterCol += colChange;
                    characterRow += rowChange;

                    // Update character symbol
                    // Uses UpdateCursor()
                    cursor = Game.UpdateCursor(key);

                    // Keep character in bounds
                    // Uses KeepInBounds()
                    characterCol = Game.KeepInBounds(characterCol, cols);
                    characterRow = Game.KeepInBounds(characterRow, rows);

                    // Update score and fruit if player scored
                    // Uses DidScore()
                    if (Game.DidScore(characterCol, characterRow, fruitCol, fruitRow))
                    {
                        Console.Beep();
                        score++;
                        fruitCol = rand.Next(cols);
                        fruitRow = rand.Next(rows);
                        shiftfruit += 5; 
                    }

                }
            }
            

           

            
        }
    }
}
