using System;
using System.Collections.Generic;
using System.Text;

namespace AboutCSharpLanguage.GenericTypeDemo
{

    public class GenericClassDemo<T> where T : class
    {

        public void SayHello(T tInstance)
        {
            Console.WriteLine(typeof(T).FullName);
            if (tInstance != null)
            {
                var hc = tInstance.GetHashCode();
            }
        }

        /// <summary>
        /// 可以对类的泛型参数,做更进一步的限制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tInstance"></param>
        public void SayHelloG<TT>(TT tInstance) where TT : IComparable<T>
        {
            Console.WriteLine(typeof(T).FullName);
            if (tInstance != null)
            {
                var hc = tInstance.GetHashCode();
            }
        }
    }
}
