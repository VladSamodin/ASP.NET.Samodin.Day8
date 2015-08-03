using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Matrices.Tests
{
    [TestClass]
    public class SymmetricMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Order0_ArgumentOutOfRangeException()
        {
            new SymmetricMatrix<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullReferenceArray_ArgumentNullException()
        {
            new SymmetricMatrix<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyArray_ArgumentException()
        {
            new SymmetricMatrix<int>(new int[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NotSquareArray_ArgumentException()
        {
            new SymmetricMatrix<int>(new int[2, 3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NotSymmetricArray_ArgumentException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {3, 4}
                };
            new SymmetricMatrix<int>(sourceArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_iLess0_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {2, 4}
                };
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(sourceArray);
            int a = matrix[-1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_iMoreOrder_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {2, 4}
                };
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(sourceArray);
            int a = matrix[3, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_jLess0_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {2, 4}
                };
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(sourceArray);
            int a = matrix[0, -1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_jMoreOrder_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {2, 4}
                };
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(sourceArray);
            int a = matrix[0, 3];
        }

        [TestMethod]
        public void Indexer_SetNotDiagonalValue_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {2, 4}
                };
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(sourceArray);
            matrix[1, 0] = -1;
            Assert.IsTrue(matrix[0, 1] == matrix[1, 0]);
        }
    }
}
