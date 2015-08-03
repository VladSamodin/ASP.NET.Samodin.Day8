using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Matrices.Tests
{
    [TestClass]
    public class SquareMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Order0_ArgumentOutOfRangeException()
        {
            new SquareMatrix<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullReferenceArray_ArgumentNullException()
        {
            new SquareMatrix<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyArray_ArgumentException()
        {
            new SquareMatrix<int>(new int[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NotSquareArray_ArgumentException()
        {
            new SquareMatrix<int>(new int[2, 3]);
        }

        [TestMethod]
        public void ToArray_NoArguments_SourceArray()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {3, 4}
                };
            SquareMatrix<int> matrix = new SquareMatrix<int>(sourceArray);
            int[,] actual = matrix.ToArray();
            bool areEqual = true;
            for (int i = 0; i < sourceArray.GetLength(0); i++)
                for (int j = 0; j < sourceArray.GetLength(1); j++)
                    areEqual &= sourceArray[i, j] == actual[i, j];
            Assert.IsTrue(areEqual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_iLess0_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {3, 4}
                };
            SquareMatrix<int> matrix = new SquareMatrix<int>(sourceArray);
            int a = matrix[-1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_iMoreOrder_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {3, 4}
                };
            SquareMatrix<int> matrix = new SquareMatrix<int>(sourceArray);
            int a = matrix[3, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_jLess0_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {3, 4}
                };
            SquareMatrix<int> matrix = new SquareMatrix<int>(sourceArray);
            int a = matrix[0, -1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_jMoreOrder_ArgumentOutOfRangeException()
        {
            int[,] sourceArray = new int[2, 2] 
                {
                    {1, 2},
                    {3, 4}
                };
            SquareMatrix<int> matrix = new SquareMatrix<int>(sourceArray);
            int a = matrix[0, 3];
        }

    }
}
