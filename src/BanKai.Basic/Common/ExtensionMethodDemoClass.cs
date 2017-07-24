using System;
using System.Collections.Generic;

namespace BanKai.Basic.Common
{
    // ReSharper disable LoopCanBeConvertedToQuery

    internal static class ExtensionMethodDemoClass
    {
        public static string OhGodItLooksAsIfIWasAMemberOfString(   //string 类的extension method,扩展方法：静态类的静态方法
            this string reference)
        {
            return reference;
        }

        public static IEnumerable<TResult> MySelect<TResult, TInput>(
            this IEnumerable<TInput> collection,                 //IEnumerable<Int>.Myselect
            Func<TInput, TResult> transformer)
        {
            foreach (TInput input in collection)  //Int32
            {
                yield return transformer(input);
            }
        }
    }

    // ReSharper restore LoopCanBeConvertedToQuery
}