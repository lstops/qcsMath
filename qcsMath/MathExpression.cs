using qcsMath.Functions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace qcsMath
{
    public class MathExpression
    {
        public static void Main()
        {
            var mfr = new MathFunctionResolver();
            mfr.RegisterMathMethods<SimpleMath>();
            var del = mfr.GetMethodDelegate("add");
            var res = (decimal)del.DynamicInvoke((decimal)1, (decimal)1);
            return;
        }

        public MathExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Paramater must not be just whitespaces, null or empty.", nameof(expression));
            }
        }

        public async Task<MathResult> Evaluate(CancellationToken ctok)
        {
            throw new NotImplementedException();
        }
    }
}
