using System;
using System.Linq;


namespace FinancialReport
{
    class Program
    {

        static void Main(string[] args)
        {
            int worstVal = 3;                   // need to print month numbers with 3 worst profits, in case min profit coincides with profit in another month, print all
            int months = 12;                    // number of months in the report
            int positiveProfit = 0;             // number of months with positive profit (>0)
            int[] income = new int[months];     // array with all income by month
            int[] expenses = new int[months];   // array with all expenses by month
            int[] profit = new int[months];     // array with all profit by month
           
            Random random = new Random();

            // arrays initialization with random values
            for (int i = 0; i < months; i++)
            {
                income[i] = random.Next(10, 31) * 10000;
                expenses[i] = random.Next(5, 21) * 10000;
                profit[i] = income[i] - expenses[i];

                // counting months with positive profit
                if (profit[i] > 0)
                {
                    positiveProfit++;
                }
            }
            // print header
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"Month", -10}{"Income", -15}{"Expenses", -15}{"Profit", -15}");
            Console.ResetColor();

            // print values
            for (int i = 0; i < months; i++)
            {
                Console.WriteLine($"{i+1, -10}{income[i], -15}{expenses[i], -15}{profit[i], -15}");
            }

            //print months numbers with the worst profit
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Worst profit was in the following months: ");
            for (int i = 0; i < worstVal; i++)
            {
                int index;
                int currentWorstProfit;
                do
                {
                    index = Array.IndexOf(profit, profit.Min());
                    currentWorstProfit = profit[index];
                    profit[index] = int.MaxValue;
                    Console.Write($"{index + 1} ");
                }
                while (profit[Array.IndexOf(profit, profit.Min())] == currentWorstProfit);
            }

            // print number of months with positive profit
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nPositive profit was in {positiveProfit} months.");
            Console.ReadKey();
        }
    }
}
