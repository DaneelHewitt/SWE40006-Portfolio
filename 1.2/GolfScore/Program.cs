
using System;

namespace GolfScorecard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Golf Scorecard";

            int[] pars =
            {
                4, 4, 3, 5, 4, 4, 3, 5, 4,
                4, 4, 3, 5, 4, 4, 3, 5, 4
            };

            int[] scores = new int[18];

            Console.WriteLine("========================================");
            Console.WriteLine("           GOLF SCORECARD");
            Console.WriteLine("========================================");
            Console.WriteLine();

            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine() ?? "Player";

            Console.WriteLine();
            Console.WriteLine($"Welcome, {playerName}!");
            Console.WriteLine("Enter your score for each hole.");
            Console.WriteLine();

            for (int i = 0; i < 18; i++)
            {
                while (true)
                {
                    Console.Write($"Hole {i + 1} (Par {pars[i]}): ");

                    if (int.TryParse(Console.ReadLine(), out int score) &&
                        score >= 1 && score <= 20)
                    {
                        scores[i] = score;
                        break;
                    }

                    Console.WriteLine("Please enter a score between 1 and 20.");
                }
            }

            int frontNine = 0;
            int backNine = 0;
            int totalScore = 0;
            int totalPar = 0;

            for (int i = 0; i < 18; i++)
            {
                totalScore += scores[i];
                totalPar += pars[i];

                if (i < 9)
                {
                    frontNine += scores[i];
                }
                else
                {
                    backNine += scores[i];
                }
            }

            int toPar = totalScore - totalPar;

            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("           GOLF SCORECARD");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine($"Player: {playerName}");
            Console.WriteLine();

            Console.WriteLine("{0,-8}{1,-8}{2,-10}{3,-10}",
                "Hole", "Par", "Score", "To Par");

            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < 18; i++)
            {
                int holeToPar = scores[i] - pars[i];

                string result;

                if (holeToPar == 0)
                {
                    result = "E";
                }
                else if (holeToPar > 0)
                {
                    result = "+" + holeToPar;
                }
                else
                {
                    result = holeToPar.ToString();
                }

                Console.WriteLine("{0,-8}{1,-8}{2,-10}{3,-10}",
                    i + 1,
                    pars[i],
                    scores[i],
                    result);
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"Front 9:  {frontNine}");
            Console.WriteLine($"Back 9:   {backNine}");
            Console.WriteLine($"Total:    {totalScore}");
            Console.WriteLine($"Par:      {totalPar}");

            string overallResult;

            if (toPar == 0)
            {
                overallResult = "E";
            }
            else if (toPar > 0)
            {
                overallResult = "+" + toPar;
            }
            else
            {
                overallResult = toPar.ToString();
            }

            Console.WriteLine($"To Par:   {overallResult}");

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("          ROUND COMPLETE");
            Console.WriteLine("========================================");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
