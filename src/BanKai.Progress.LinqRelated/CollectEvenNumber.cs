using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BanKai.Progress.LinqRelated
{
    public class CollectEvenNumber
    {
        [Fact]
        public void should_collect_all_even_number()
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] expected = { 2, 4 };

            IEnumerable<int> result = CollectAllEvenNumbers(source);

            Assert.Equal(expected, result);
        }


        static IEnumerable<int> CollectAllEvenNumbers(int[] source)
        {
            var result = source.Where(item => item % 2 == 0);
            return result;
        }

        //static IEnumerable<int> CollectAllEvenNumbers(int[] source)
        //{
        //    var result = new List<int> { };

        //    for (int item = 0; item < source.Length; item++)
        //    {
        //        if (source[item] % 2 == 0)
        //            result.Add(source[item]);
        //    }

        //    return result;
        //}

        //static IEnumerable<int> CollectAllEvenNumbers(int[] source)
        //{

        //    var result = new List<int> { };

        //    foreach (int item in source)
        //    {
        //        if (item % 2 == 0)
        //            result.Add(item);
        //    }

        //    return result;
        //}
    }
}