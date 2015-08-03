using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrices
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int order) 
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
                items[i] = new T[1];
            }
        }

        public DiagonalMatrix(T[,] array)
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
            if (!IsDiagonalMatrix(array))
            {
                throw new ArgumentException("Matrix is not diagonal", "array");
            }

            order = array.GetLength(0);

            items = new T[order][];
            for (int i = 0; i < order; i++)
            {
                items[i] = new T[1];
            }

            for (int i = 0; i < order; i++)
            {
                items[i][0] = array[i, i];
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
                if (j != i)
                {
                    return default(T);
                }
                return items[i][0];
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
                if (j != i && !object.Equals(value, default(T)))
                {
                    throw new MemberAccessException("");
                }
                T oldValue = items[i][0];
                items[i][0] = value;
                OnElementChanged(i, j, oldValue, value);
            }
        }

        private bool IsDiagonalMatrix(T[,] array)
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
                    if (!object.Equals(array[i, j], default(T))
                     || !object.Equals(array[j, i], default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
