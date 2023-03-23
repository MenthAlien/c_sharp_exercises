using System;

namespace AckermannFunction
{
    class AckermannFunction
    {
        static void Main(string[] args)
        {
            Print(Ackermann(2, 5));
            Print(Ackermann(1, 2));

            Console.ReadKey();
        }
        private static void Print(int result)
        {
            if (result != 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid args.");
            }
        }
        private static int Ackermann(int n, int m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if (m == 0)
            {
                return Ackermann(n - 1, 1);
            }
            else if (n > 0 && m > 0)
            {
                return Ackermann(n - 1, Ackermann(n, m - 1));
            }
            else
            {
                return 0;
            }
        }

    }

    
}
