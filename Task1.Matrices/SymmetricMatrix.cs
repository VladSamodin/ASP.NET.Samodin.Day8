using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrices
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        public SymmetricMatrix(int order) 
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
                items[i] = new T[i + 1];
            }
        }

        public SymmetricMatrix(T[,] array)
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
            if (!IsMatrixSymmetric(array))
            {
                throw new ArgumentException("Matrix is not symmetric", "array");
            }

            order = array.GetLength(0);

            items = new T[order][];
            for (int i = 0; i < order; i++)
            {
                items[i] = new T[i + 1];
            }

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j <= i; j++)
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
                if (j > i)
                {
                    Swap(ref i, ref j);
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
                if (j > i)
                {
                    Swap(ref i, ref j);
                }
                T oldValue = items[i][j];
                items[i][j] = value;
                OnElementChanged(i, j, oldValue, value);
                OnElementChanged(j, i, oldValue, value);
            }
        }

        private bool IsMatrixSymmetric(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Matrix is not square", "array");
            }
            int order = array.GetLength(0);
            for (int i = 0; i < order; i++)
            {
                for (int j = i + 1; j < order; j++)
                {
                    if (!object.Equals(array[i, j], (array[j, i])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}
