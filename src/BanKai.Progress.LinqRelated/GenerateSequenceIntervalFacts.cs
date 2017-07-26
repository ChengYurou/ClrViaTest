using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class GenerateSequenceIntervalFacts
    {
        [Fact]
        public void stop_generating_sequence_if_result_is_less_than_zero()
        {
            int[] expected = { 7, 4, 1, -2 };

            Assert.Equal(expected, GenerateSequenceInterval(7, 3));
        }

        static IEnumerable<int> GenerateSequenceInterval(int start, int interval)
        {
            var result = new List<int> {start };

            while (start > 0)
            {
                result.Add(start - interval);
                start -= interval;
            }

            return result;
        }
    }
}