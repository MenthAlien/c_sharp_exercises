using System;


namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows;
			int[][] pascalTriangle;
			string line = "";
			var windowWidth = Console.WindowWidth;
            Console.WriteLine("Enter number of rows (1-25):");
			do
			{
				try
				{
					rows = Convert.ToInt32(Console.ReadLine());
                    if (rows > 26)
                    {
						Console.WriteLine("\nPlease enter the number from 1 to 25.");
					}
					else
                    {
						break;
                    }
				}
				catch (System.FormatException)
				{
					Console.WriteLine("\nThis is not a number. Try again!");
				}
				catch (System.OverflowException)
				{
					Console.WriteLine("\nThe number is too big. Try again!");
				}
			}
			while (true);

			pascalTriangle = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
				pascalTriangle[row] = new int[row+1];
				pascalTriangle[row][0] = 1;							// the first element is always 1
				line += Convert.ToString(pascalTriangle[row][0]); 
				for (int elem = 1; elem < row+1; elem++)
                {
                    if (row == elem)								// for the last element
                    {
						pascalTriangle[row][elem] = 1;
						line += " " + Convert.ToString(pascalTriangle[row][elem]).PadLeft(5);
					}
					else											// for other elements
                    {
						pascalTriangle[row][elem] = pascalTriangle[row-1][elem] + pascalTriangle[row-1][elem-1];
						line += " " + Convert.ToString(pascalTriangle[row][elem]).PadLeft(5);
					}
                }
				
				if (line.Length < windowWidth) line = line.PadLeft((windowWidth - line.Length) / 2 + line.Length, ' ');
				Console.WriteLine(line);
				Console.WriteLine();
				line = "";
			}
			Console.ReadKey();
		}
    }
}
