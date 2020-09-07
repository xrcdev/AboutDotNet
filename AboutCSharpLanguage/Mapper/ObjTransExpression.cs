using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AboutCSharpLanguage
{
    /// <summary>
    /// 通用In类字段copy到Out类方法
    /// </summary>
    /// <typeparam name="TIn">源实体</typeparam>
    /// <typeparam name="TOut">目标实体</typeparam>
    public static class ObjTransExpression<TIn, TOut>
    {
        /// <summary>
        /// 委托
        /// </summary>
        private static readonly Func<TIn, TOut> cache = GetFunc();
        /// <summary>
        /// 转换方法
        /// </summary>
        /// <returns>目标实体</returns>
        private static Func<TIn, TOut> GetFunc()
        {
            Type typeOut = typeof(TOut);
            Type typeIn = typeof(TIn);

            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");

            foreach (var oProp in typeOut.GetProperties())
            {
                if (!oProp.CanWrite) continue;

                var InProperties = typeIn.GetProperties();
                if (InProperties.Any(p => p.Name == oProp.Name))
                {
                    MemberExpression inProperty = Expression.Property(parameterExpression, typeIn.GetProperty(oProp.Name));
                    if (inProperty.Type == oProp.PropertyType)
                    {
                        MemberBinding memberBinding = Expression.Bind(oProp, inProperty);
                        memberBindingList.Add(memberBinding);
                    }
                }
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeOut), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });
            return lambda.Compile();
        }

        /// <summary>
        /// 转换
        /// 调用转换委托
        /// </summary>
        /// <param name="tIn">源实体</param>
        /// <returns>目标实体</returns>
        public static TOut Trans(TIn tIn)
        {
            return cache(tIn);
        }

        
    }



    public class ObjTransExpression2<TIn>
    {
        static Dictionary<Type, Type> ht = new Dictionary<Type, Type>();
        /// <summary> 
        /// 转换方法
        /// </summary>
        /// <returns>目标实体</returns>
        public static TOut GetObj<TOut>(TIn tt)
        {
            Type typeOut = typeof(TOut);
            Type typeIn = typeof(TIn);

            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");

            foreach (var oProp in typeOut.GetProperties())
            {
                if (!oProp.CanWrite) continue;

                var InProperties = typeIn.GetProperties();
                if (InProperties.Any(p => p.Name == oProp.Name))
                {
                    MemberExpression inProperty = Expression.Property(parameterExpression, typeIn.GetProperty(oProp.Name));
                    if (inProperty.Type == oProp.PropertyType)
                    {
                        MemberBinding memberBinding = Expression.Bind(oProp, inProperty);
                        memberBindingList.Add(memberBinding);
                    }
                }
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeOut), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });
            var func = lambda.Compile();
            return func(tt);
        }
    }
}
