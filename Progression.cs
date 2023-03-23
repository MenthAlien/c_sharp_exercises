using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progression
{
    class Progression
    {
        static void Main(string[] args)
        {
            double[] numbers;
            
            Console.WriteLine("Enter sequence of numbers:");
            var lineNumbers = Console.ReadLine();
            var numberStringArray = lineNumbers.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            numbers = new double[numberStringArray.Length];

            for (int i = 0; i < numberStringArray.Length; i++)
            {
                numbers[i] = double.Parse(numberStringArray[i]);
            }
            if(isArithmetic(out double difference, numbers))
            {
                Console.WriteLine($"The sequence is an arithmetic progression. The common difference is {difference}.");
            }
            else
            {
                Console.WriteLine("The sequence is not an arithmetic progression.");
            }

            if(isGeometric(out double ratio, numbers))
            {
                Console.WriteLine($"The sequence is a geometric progression. The common ratio is {ratio}.");
            }
            else
            {
                Console.WriteLine("The sequence is not a geometric progression.");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Check if the sequence is arithmetic progression.
        /// </summary>
        /// <param name="difference">The common difference between neighboring elements of sequence.</param>
        /// <param name="numbers">The sequence of numbers.</param>
        /// <returns></returns>
        private static bool isArithmetic(out double difference, double[] numbers)
        {
            difference = numbers[1] - numbers[0];
            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] - numbers[i - 1] != difference)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Check if the sequence is geometric progression.
        /// </summary>
        /// <param name="ratio">The common ratio between neighboring elements of sequence.</param>
        /// <param name="numbers">The sequence of numbers.</param>
        /// <returns></returns>
        private static bool isGeometric(out double ratio, double[] numbers)
        {

            if (numbers[0] != 0)
            {
                ratio = numbers[1] / numbers[0];
            }
            else                                            // in case all elements in progression is 0
            {
                ratio = double.NaN;
                return false;
            }
            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i - 1] == 0 || numbers[i] / numbers[i - 1] != ratio)
                    return false;
            }
            return true;

        }
    }
}
