using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrices
{
    public static class MatrixExtensions
    {
        public static SquareMatrix<T> Add<T>(this Matrix<T> lhs, Matrix<T> rhs)
        {
            return new SquareMatrix<T>(GetArraySum(lhs, rhs));
        }

        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            return new SymmetricMatrix<T>(GetArraySum(lhs, rhs));
        }

        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            return new SymmetricMatrix<T>(GetArraySum(lhs, rhs));
        }

        public static SymmetricMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            return new SymmetricMatrix<T>(GetArraySum(lhs, rhs));
        }

        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            return new DiagonalMatrix<T>(GetArraySum(lhs, rhs));
        }

        private static T[,] GetArraySum<T>(Matrix<T> lhs, Matrix<T> rhs)
        {
            if (lhs.Order != rhs.Order)
            {
                throw new ArithmeticException("Matrices have different order");
            }

            T[,] result = new T[lhs.Order, lhs.Order];
            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    result[i, j] = Addition(lhs[i, j], rhs[i, j]);
                }
            }
            return result;
        }
        
        private static T Addition<T>(T lhs, T rhs)
        {
            dynamic a = lhs;
            dynamic b = rhs;
            T result;
            try
            {
                result = a + b;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new ArithmeticException("Operands do not have a method to add");
            }
            return result;
        }
    }
}
