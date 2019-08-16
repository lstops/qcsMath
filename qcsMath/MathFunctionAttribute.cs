using System;

namespace qcsMath
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    internal sealed class MathFunctionAttribute : Attribute
    {
        public string Name { get; }

        public MathFunctionAttribute(string name)
        {
            this.Name = name;
        }
    }
}
