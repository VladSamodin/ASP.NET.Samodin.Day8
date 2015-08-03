using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Matrices.Tests
{
    [TestClass]
    public class DiagonalMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Order0_ArgumentOutOfRangeException()
        {
            new DiagonalMatrix<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullReferenceArray_ArgumentNullException()
        {
            new DiagonalMatrix<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyArray_ArgumentException()
        {
            new DiagonalMatrix<int>(new int[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NotSquareArray_ArgumentException()
        {
            new DiagonalMatrix<int>(new int[2, 3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NotDiagonalArray_ArgumentException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {2, 4}
                };
            new DiagonalMatrix<int>(sourceArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_iLess0_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 0},
                    {0, 4}
                };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(sourceArray);
            int a = matrix[-1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_iMoreOrder_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 0},
                    {0, 4}
                };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(sourceArray);
            int a = matrix[3, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_jLess0_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 0},
                    {0, 4}
                };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(sourceArray);
            int a = matrix[0, -1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_jMoreOrder_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 0},
                    {0, 4}
                };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(sourceArray);
            int a = matrix[0, 3];
        }

        [TestMethod]
        [ExpectedException(typeof(MemberAccessException))]
        public void Indexer_SetNotDiagonalElementNotDefaultValue_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 0},
                    {0, 4}
                };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(sourceArray);
            matrix[0, 1] = 1;
        }

        [TestMethod]
        public void Indexer_SetNotDiagonalElementDefaultValue_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 0},
                    {0, 4}
                };
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(sourceArray);
            matrix[0, 1] = 0;
        }
    }
}
