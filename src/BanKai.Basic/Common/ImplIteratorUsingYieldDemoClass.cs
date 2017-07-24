using System.Collections.Generic;

namespace BanKai.Basic.Common
{
#pragma warning disable 162
    // ReSharper disable HeuristicUnreachableCode
    // ReSharper disable LoopCanBeConvertedToQuery

    internal class ImplIteratorUsingYieldDemoClass
    {
        public IEnumerable<int> GetOneToTen()  //返回泛型可枚举类型的迭代器
        {
            for (int i = 1; i <= 10; ++i)
            {
                yield return i;  //yield return 执行序列中返回的下一项
            }
        }

        public IEnumerable<int> GetOneToThreeWithMultipleYields()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public IEnumerable<int> GetOnToThreeButBreakingAtTwo()
        {
            yield return 1;
            yield return 2;
            yield break;         //yield break指定序列中没有更多项
            yield return 3;
        }

        public IEnumerable<int> GetEvenNumber(IEnumerable<int> getOneToTen)
        {
            foreach (int numberInCollection in getOneToTen)
            {
                if (numberInCollection % 2 == 0)
                {
                    yield return numberInCollection;
                }
            }
        }
    }

    // ReSharper restore LoopCanBeConvertedToQuery
    // ReSharper restore HeuristicUnreachableCode
#pragma warning restore 162
}