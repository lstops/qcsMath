using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace qcsMath.Functions
{
    sealed class SimpleMath : BaseMathClass
    {
        [MathFunction("add")]
        internal decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
