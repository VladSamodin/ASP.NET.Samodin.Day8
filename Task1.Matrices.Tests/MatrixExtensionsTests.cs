using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Matrices.Tests
{
    [TestClass]
    public class MatrixExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Add_MatricesDifferentOreder_ArithmeticException()
        {
            SquareMatrix<int> lhs = new SquareMatrix<int>(1);
            SquareMatrix<int> rhs = new SquareMatrix<int>(2);
            lhs.Add(rhs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Add_MatricesTypeWithoutOperatorPlus_ArithmeticException()
        {
            TypeWithoutOperatorPlus[,] sourceArray = new TypeWithoutOperatorPlus[,]
            {
                {new TypeWithoutOperatorPlus(1), new TypeWithoutOperatorPlus(2)},
                {new TypeWithoutOperatorPlus(3), new TypeWithoutOperatorPlus(4)},
            };
            SquareMatrix<TypeWithoutOperatorPlus> lhs = new SquareMatrix<TypeWithoutOperatorPlus>(sourceArray);
            SquareMatrix<TypeWithoutOperatorPlus> rhs = new SquareMatrix<TypeWithoutOperatorPlus>(sourceArray);
            lhs.Add(rhs);
        }

        [TestMethod]
        public void Add_MatricesTypeWithOperatorPlus_DoubleSourceArray()
        {
            TypeWithOperatorPlus[,] sourceArray = new TypeWithOperatorPlus[,]
            {
                {new TypeWithOperatorPlus(1), new TypeWithOperatorPlus(2)},
                {new TypeWithOperatorPlus(3), new TypeWithOperatorPlus(4)},
            };
            SquareMatrix<TypeWithOperatorPlus> lhs = new SquareMatrix<TypeWithOperatorPlus>(sourceArray);
            SquareMatrix<TypeWithOperatorPlus> rhs = new SquareMatrix<TypeWithOperatorPlus>(sourceArray);
            lhs.Add(rhs);

            TypeWithOperatorPlus[,] actual = lhs.Add(rhs).ToArray();
            bool areDouble = true;
            for (int i = 0; i < sourceArray.GetLength(0); i++)
                for (int j = 0; j < sourceArray.GetLength(1); j++)
                    areDouble &= (sourceArray[i, j].Number * 2) == actual[i, j].Number;
            Assert.IsTrue(areDouble);
        }

        [TestMethod]
        public void Add_SymmetricMatrices_DoubleSourceArray()
        {
            int[,] sourceArray = new int[,]
            {
                {1, 5},
                {5, 4}
            };
            SymmetricMatrix<int> lhs = new SymmetricMatrix<int>(sourceArray);
            SymmetricMatrix<int> rhs = new SymmetricMatrix<int>(sourceArray);
            lhs.Add(rhs);

            int[,] actual = lhs.Add(rhs).ToArray();
            bool areDouble = true;
            for (int i = 0; i < sourceArray.GetLength(0); i++)
                for (int j = 0; j < sourceArray.GetLength(1); j++)
                    areDouble &= (sourceArray[i, j] * 2) == actual[i, j];
            Assert.IsTrue(areDouble);
        }

        [TestMethod]
        public void Add_DiagonalMatrices_DoubleSourceArray()
        {
            int[,] sourceArray = new int[,]
            {
                {1, 0},
                {0, 4}
            };
            DiagonalMatrix<int> lhs = new DiagonalMatrix<int>(sourceArray);
            DiagonalMatrix<int> rhs = new DiagonalMatrix<int>(sourceArray);
            lhs.Add(rhs);

            int[,] actual = lhs.Add(rhs).ToArray();
            bool areDouble = true;
            for (int i = 0; i < sourceArray.GetLength(0); i++)
                for (int j = 0; j < sourceArray.GetLength(1); j++)
                    areDouble &= (sourceArray[i, j] * 2) == actual[i, j];
            Assert.IsTrue(areDouble);
        }
    }
}
