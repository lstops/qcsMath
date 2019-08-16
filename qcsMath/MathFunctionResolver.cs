using qcsMath.Functions;
using qcsMath.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace qcsMath
{
    class MathFunctionResolver
    {
        private readonly Dictionary<string, Delegate> mathMethods;
        private readonly List<BaseMathClass> instanceList;
        public MathFunctionResolver()
        {
            mathMethods = new Dictionary<string, Delegate>();
            instanceList = new List<BaseMathClass>();
        }

        internal void RegisterMathMethods<T>() where T : BaseMathClass
        {
            var instance = Activator.CreateInstance<T>();
            instanceList.Add(instance);

            var methods = typeof(T).GetRuntimeMethods();
            foreach (var m in methods.Where(x => x.GetCustomAttributes(false).Any(y => y.GetType() == typeof(MathFunctionAttribute))))
            {
                var del = ReflectionUtil.CreateDelegate(m, instance);
                var attrib = m.GetCustomAttributes(false).First(x => x.GetType() == typeof(MathFunctionAttribute)) as MathFunctionAttribute;
                mathMethods.Add(attrib.Name, del);
            }
        }

        internal Delegate GetMethodDelegate(string name)
        {
            return mathMethods[name];
        }
    }
}
