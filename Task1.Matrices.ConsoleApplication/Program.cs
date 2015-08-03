using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Matrices;

namespace Task1.Matrices.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[2, 2] {{1, 2}, {3, 4}};
            Matrix<int> matrix = new SquareMatrix<int>(array);
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }
                Console.WriteLine();
            }

            int[] arraySumRows = new int[] { 3, 7 };
            matrix.ElementChanged +=
                (sender, e) =>
                {
                    arraySumRows[e.i] -= e.OldValue;
                    arraySumRows[e.i] += e.NewValue;
                    Console.WriteLine("Element {0}, {1} changed from {2} to {3}", e.i, e.j, e.OldValue, e.NewValue);
                    Console.WriteLine("New sum row {0} = {1}", e.i, arraySumRows[e.i]);
                };
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    matrix[i, j]++;
                }
            }
        }
    }
}
