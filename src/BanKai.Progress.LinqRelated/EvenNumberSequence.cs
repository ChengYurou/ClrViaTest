using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class EvenNumberSequence
    {
        [Fact]
        public void should_get_even_integer_sequence_increment()
        {
            int[] expected = { 2, 4, 6, 8, 10 };
            IEnumerable<int> result = GetEvenSequence(1, 10);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_get_even_integer_sequence_decrement()
        {
            int[] expected = { 10, 8, 6, 4, 2 };
            IEnumerable<int> result = GetEvenSequence(10, 1);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_get_single_even_number_if_start_and_end_are_same_even_number()
        {
            int[] expected = { 10 };
            IEnumerable<int> result = GetEvenSequence(10, 10);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_get_nothing_if_start_and_end_are_same_odd_number()
        {
            int[] expected = { };
            IEnumerable<int> result = GetEvenSequence(5, 5);

            Assert.Equal(expected, result);
        }

        //static IEnumerable<int> GetEvenSequence(int start, int end)
        //{
        //    var numberList = new List<int> { };

        //    if (end >= start)
        //    {
        //        for (int num = start; num <= end; num++)
        //        {
        //            numberList.Add(num);
        //        }
        //    }
        //    else
        //    {
        //        for (int num = start; num >= end; num--)
        //        {
        //            numberList.Add(num);
        //        }
        //    }

        //    var result = from number in numberList
        //                 where number % 2 == 0
        //                 select number;

        //    return result;
        //}

        static IEnumerable<int> GetEvenSequence(int start, int end)
        {
            var numberList = end >= start
                ? Enumerable.Range(start, end - start + 1).ToList()
                : Enumerable.Range(end, start - end + 1).Reverse().ToList();

            var result = from number in numberList
                         where number % 2 == 0
                         select number;

            return result;
        }
    }
}