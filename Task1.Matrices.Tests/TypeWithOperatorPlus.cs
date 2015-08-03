using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrices.Tests
{
    public class TypeWithOperatorPlus
    {
        public int Number { get; set; }

        public TypeWithOperatorPlus(int number)
        {
            Number = number;
        }

        public static TypeWithOperatorPlus operator +(TypeWithOperatorPlus lhs, TypeWithOperatorPlus rhs)
        {
            return new TypeWithOperatorPlus(lhs.Number + rhs.Number);
        }
    }
}
