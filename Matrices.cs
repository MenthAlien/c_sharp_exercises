using System;

namespace Matrices
{
    enum actions
    {
        number = 1,
        add,
        subtract,
        multiply
    }

    class Matrices
    {
        static void Main(string[] args)
        {
            int action;
            Console.WriteLine("What you want to do?\n1.Multiplication of matrix by number\n2.Matrix addition\n3.Matrix subtraction\n4.Matrix multiplication");
            do
            {
                try
                {
                    action = Convert.ToInt32(Console.ReadLine());
                    if (!Enum.IsDefined(typeof(actions), action))
                    {
                        Console.WriteLine("Incorrect input, please choose number from 1 to 4.");
                    }
                    else break;
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
            while (true);

            Console.WriteLine();
            switch (action)
            {
                case (int)actions.number:
                    MultiplyByNumber();
                    break;
                case (int)actions.add:
                    MatrixAddition();
                    break;
                case (int)actions.subtract:
                    MatrixSubtraction();
                    break;
                case (int)actions.multiply:
                    MatrixMultiplication();
                    break;
            }

            Console.ReadKey();
        }


        private static void MultiplyByNumber()
        {
            Random random = new Random();
            int num;
            int[,] matrix, resultMatrix;

            Console.Write("Enter a number for multiplication:");
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Enter a number.");
            }

            MatrixRank(out int rows, out int columns, "");

            int middleRow = rows / 2;
            string lineNum = num.ToString() + "  *  ";
            matrix = new int[rows, columns];
            resultMatrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string lineMatrix = "", lineResult = "";

                // initialize the matrix with random values
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(-9, 10);
                    lineMatrix += (matrix[i, j].ToString() + " ").PadLeft(3);
                    resultMatrix[i, j] = matrix[i, j] * num;
                    lineResult += (resultMatrix[i, j].ToString() + " ").PadLeft(num.ToString().Length + 3);
                }
                if (i == middleRow)
                {
                    Console.Write(lineNum.PadRight((lineNum.Length)) + "| " + lineMatrix + "|  =  | " + lineResult + "|");
                }
                else
                {
                    Console.Write("".PadRight((lineNum.Length)) + "| " + lineMatrix + "|     | " + lineResult + "|");
                }
                Console.WriteLine();
            }
        }
        private static void MatrixAddition()
        {
            Random random = new Random();
            MatrixRank(out int rows, out int columns, "");
            int[,] matrix1, matrix2, resultMatrix;
            matrix1 = new int[rows, columns];
            matrix2 = new int[rows, columns];
            resultMatrix = new int[rows, columns];
            int middleRow = rows / 2;

            for (int i = 0; i < rows; i++)
            {
                string lineMatrix1 = "", lineMatrix2 = "", lineResult = "";
                for (int j = 0; j < columns; j++)
                {
                    matrix1[i, j] = random.Next(-9, 10);
                    matrix2[i, j] = random.Next(-9, 10);
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    lineMatrix1 += (matrix1[i, j].ToString() + " ").PadLeft(3);
                    lineMatrix2 += (matrix2[i, j].ToString() + " ").PadLeft(3);
                    lineResult += (resultMatrix[i, j].ToString() + " ").PadLeft(4);
                }
                if (i == middleRow)
                {
                    Console.Write("| " + lineMatrix1 + "|  +  | " + lineMatrix2 + "|  =  | " + lineResult + "|");
                }
                else
                {
                    Console.Write("| " + lineMatrix1 + "|     | " + lineMatrix2 + "|     | " + lineResult + "|");
                }
                Console.WriteLine();
            }
        }
        private static void MatrixSubtraction()
        {
            Random random = new Random();
            MatrixRank(out int rows, out int columns, "");
            int[,] matrix1, matrix2, resultMatrix;
            matrix1 = new int[rows, columns];
            matrix2 = new int[rows, columns];
            resultMatrix = new int[rows, columns];
            int middleRow = rows / 2;

            for (int i = 0; i < rows; i++)
            {
                string lineMatrix1 = "", lineMatrix2 = "", lineResult = "";
                for (int j = 0; j < columns; j++)
                {
                    matrix1[i, j] = random.Next(-9, 10);
                    matrix2[i, j] = random.Next(-9, 10);
                    resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    lineMatrix1 += (matrix1[i, j].ToString() + " ").PadLeft(3);
                    lineMatrix2 += (matrix2[i, j].ToString() + " ").PadLeft(3);
                    lineResult += (resultMatrix[i, j].ToString() + " ").PadLeft(4);
                }
                if (i == middleRow)
                {
                    Console.Write("| " + lineMatrix1 + "|  -  | " + lineMatrix2 + "|  =  | " + lineResult + "|");
                }
                else
                {
                    Console.Write("| " + lineMatrix1 + "|     | " + lineMatrix2 + "|     | " + lineResult + "|");
                }
                Console.WriteLine();
            }
        }
        private static void MatrixMultiplication()
        {
            Random random = new Random();
            int rows1, rows2, columns1, columns2;

            do
            {
                MatrixRank(out rows1, out columns1, "1st ");
                MatrixRank(out rows2, out columns2, "2nd ");
                if (rows2 != columns1)
                {
                    Console.WriteLine("These matrices can\'t be multiplied. Columns of the 1st matrix should match with rows of the 2nd matrix. Try again!");
                }
                else break;
            }
            while (true);

            int[,] matrix1, matrix2, resultMatrix;
            matrix1 = new int[rows1, columns1];
            matrix2 = new int[rows2, columns2];
            resultMatrix = new int[rows1, columns2];
            var max = Math.Max(rows1, rows2);
            
            string[] lineMatrix1 = new string[max + 1], lineMatrix2 = new string[max + 1], lineResult = new string[max + 1];
            int emptyRows = Math.Abs(rows1 - rows2) / 2;

            //align matrices for printing
            for (int i = 0; i < max; i++)
            {
                lineMatrix1[i] = "".PadLeft(3*columns1);
                lineMatrix2[i] = "".PadLeft(3*columns2);
                lineResult[i] = "".PadLeft(5*columns2);
            }
            
            // initialization of matrices
            // first matrix
            for (int i = 0; i < rows1; i++)
            {
                int tempEmptyRows;
                if (rows1 == max) tempEmptyRows = 0;
                else tempEmptyRows = emptyRows;
                lineMatrix1[i + tempEmptyRows] = "";

                for (int k = 0; k < columns1; k++)
                {
                    matrix1[i, k] = random.Next(-9, 10);
                    lineMatrix1[i + tempEmptyRows] += (matrix1[i, k].ToString() + " ").PadLeft(3);
                }
            }

            // second matrix
            for (int k = 0; k < rows2; k++)
            {
                int tempEmptyRows;
                if (rows2 == max) tempEmptyRows = 0;
                else tempEmptyRows = emptyRows;
                lineMatrix2[k + tempEmptyRows] = "";

                for (int j = 0; j < columns2; j++)
                {
                    matrix2[k, j] = random.Next(-9, 10);
                    lineMatrix2[k + tempEmptyRows] += (matrix2[k, j].ToString() + " ").PadLeft(3);

                }
            }

            // multiplication
            for (int i = 0; i < rows1; i++)
            {
                int tempEmptyRows;
                if (rows1 == max) tempEmptyRows = 0;
                else tempEmptyRows = emptyRows;
                lineResult[i + tempEmptyRows] = "";

                for (int j = 0; j < columns2; j++)
                {
                    for (int k = 0; k < columns1; k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }

                    lineResult[i + tempEmptyRows] += (resultMatrix[i, j].ToString() + " ").PadLeft(5);

                }

            }

            // print
            for (int i = 0; i < Math.Max(rows1, rows2); i++)
            {
                if (i == emptyRows)
                {
                    Console.Write($"| {lineMatrix1[i]}|  *  | {lineMatrix2[i]}|  =  | {lineResult[i]}|");
                }
                else
                {
                    Console.Write($"| {lineMatrix1[i]}|     | {lineMatrix2[i]}|     | {lineResult[i]}|");
                }
                Console.WriteLine();
            }
        }

        private static void MatrixRank(out int rows, out int columns, string no)
        {
            Console.Write($"Enter number of rows of {no}matrix:");
            while (!int.TryParse(Console.ReadLine(), out rows) || rows == 0)
            {
                Console.WriteLine("Enter a valid number.");
            }
            Console.Write($"Enter number of columns of {no}matrix:");
            while (!int.TryParse(Console.ReadLine(), out columns) || columns == 0)
            {
                Console.WriteLine("Enter a valid number.");
            }
        }
    }
}
