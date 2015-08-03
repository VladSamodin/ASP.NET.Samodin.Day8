using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrices
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int i { get; private set; }
        public int j { get; private set; }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }
        public ElementChangedEventArgs(int i, int j, T oldValue, T newValue)
            : base()
        {
            this.i = i;
            this.j = j;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    } 

    public abstract class Matrix<T>
    {
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        protected T[][] items;
        protected int order;

        public int Order
        {
            get
            {
                return order;
            }
        }

        public Matrix()
        {
            ElementChanged += delegate { };
        }

        protected virtual void OnElementChanged(int i, int j, T oldValue, T newValue)
        {
            ElementChanged(this, new ElementChangedEventArgs<T>(i, j, oldValue, newValue));
        }

        public abstract T this[int i, int j]
        {
            get;
            set;
        }

        public T[,] ToArray()
        {
            T[,] result = new T[order, order];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    result[i, j] = this[i, j];
                }
            }
            return result;
        }
    }
}
