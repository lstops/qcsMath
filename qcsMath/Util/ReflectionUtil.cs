using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace qcsMath.Util
{
    static class ReflectionUtil
    {
        internal static Delegate CreateDelegate(this MethodInfo method, object target)
        {
            Func<Type[], Type> funcType;
            var isAction = method.ReturnType == typeof(void);
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType);

            if (isAction)
            {
                funcType = Expression.GetActionType;
            }
            else
            {
                funcType = Expression.GetFuncType;
                parameterTypes = parameterTypes.Append(method.ReturnType);
            }

            if (method.IsStatic)
            {
                return Delegate.CreateDelegate(funcType(parameterTypes.ToArray()), method);
            }

            return Delegate.CreateDelegate(funcType(parameterTypes.ToArray()), target, method.Name);
        }
    }
}
