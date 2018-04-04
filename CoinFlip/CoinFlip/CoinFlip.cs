using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace CoinFlip
{
    class CoinFlip
    {
        static void Main(string[] args)
        {

            Random coinFace = new Random(); // Creates a random coin object

            int numToss, face, flip, h = 0, t = 0;
            string replay, ans, custAns, faceName, heads, tails, winner;

            Title = "Coin Flip"; // Makes the program title of the console window read as Coin Flip.

            printHeader();

            do
            {
                WriteLine("How many coins would you like to flip?");
                WriteLine("Enter a whole number, or 0 or Q to quit.");
                ans = ReadLine().ToUpper();

                if (ans == "Q" || ans == "0")
                {
                    exitConditions();
                    break;
                }
                else if (ans != Int32.Parse(ans))
                {
                    WriteLine("Please enter a whole number, or 0 or Q to quit.");
                    ans = ReadLine().ToUpper();
                }
                else
                    numToss = Int32.Parse(ans);

                WriteLine("What are you flipping a coin to decide?");
				// Gives the user the option to customize the coin face names
				// If no face name is chosen, uses default Heads or Tails
                Write("Heads: ");
                heads = ReadLine();
                if(heads == "")
                {
                    heads = "Heads";
                }
                Write("Tails: ");
                tails = ReadLine();
                if (tails == "")
                {
                    tails = "Tails";
                }

				// Loop for processing the user-defined number of coin flips
                for (flip = 1; flip <= numToss; flip++)
                {
                    face = coinFace.Next(1, 3);
                    // Displays the name of each coin face result along with the custom name
                    switch (face)
                    {
                        case 1:
                            faceName = "Heads";
                            if (heads == "Heads")
                            {
                                WriteLine(faceName);
                            }
                            else
                                WriteLine(faceName + " - " + heads);
                            h++;
                            break;
                        case 2:
                            faceName = "Tails";
                            if (tails == "Tails")
                            {
                                WriteLine(faceName);
                            }
                            else
                                WriteLine(faceName + " - " + tails);
                            t++;
                            break;
                    }
                }

				// Winning conditions
                if (h > t)
                {
                    winner = heads;
                    MessageBox.Show("And the winner is...\n\t" + winner, "Winner!");
                }
                if (h < t)
                {
                    winner = tails;
                    MessageBox.Show("And the winner is...\n\t" + winner, "Winner!");
                }
                if (h == t)
                {
                    winner = "Neither! It's a tie!";
                    MessageBox.Show("And the winner is...\n\t" + winner, "Winner!");
                }

                // Repeat conditions with a call for error handling
                Write("Play again? Y/N >>  ");
                replay = ReadLine().ToUpper();

                replay = handleInvalidEntry(replay);

                if (replay.ToUpper() == "N")
                {
                    exitConditions();
                    break;
                }

                // Reset variables
                h = 0;
                t = 0;

                Clear(); // Clears the console window to prevent clutter & scrolling
                printHeader();
            }
            while (replay.ToUpper() == "Y" && replay.ToUpper() != "N");
        }

        static void exitConditions() // Called when the program will close
        {
            WriteLine("Thanks for playing!\nPress any key to close the program.");
            ReadKey();
        }

		// Error handling for user entry
        static string handleInvalidEntry(string handler)
        {
            while (handler.ToUpper() != "Y" && handler.ToUpper() != "N")
            {
                WriteLine("Invalid entry. Please enter Y or N");
                handler = ReadLine().ToUpper();
            }
            return handler;
        }

		// Display of program header
        static void printHeader()
        {
            WriteLine("\t\tCoin Flip\n\t\t~~~~~~~~~\n\n");
        }

    }
}
