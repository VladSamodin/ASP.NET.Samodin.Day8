using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrices
{
    
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int order) 
            : base()
        {
            if (order < 1)
            {
                throw new ArgumentOutOfRangeException("order");
            }
            
            this.order = order;
            items = new T[order][];
            for (int i = 0; i < order; i++)
            {
                items[i] = new T[order];
            }
        }

        public SquareMatrix(T[,] array)
            : base()
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty", "array");
            }
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Matrix is not square", "array");
            }

            order = array.GetLength(0);

            items = new T[order][];
            for (int i = 0; i < order; i++)
            {
                items[i] = new T[order];
            }

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    this[i, j] = array[i, j];
                }
            }
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= order)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                if (j < 0 || j >= order)
                {
                    throw new ArgumentOutOfRangeException("j");
                }
                return items[i][j];
            }
            set
            {
                if (i < 0 || i >= order)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                if (j < 0 || j >= order)
                {
                    throw new ArgumentOutOfRangeException("j");
                }
                T oldValue = items[i][j];
                items[i][j] = value;
                OnElementChanged(i, j, oldValue, value);
            }
        }
    }
}
