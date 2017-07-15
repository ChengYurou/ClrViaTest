using Xunit;
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace BanKai.Progress.LinqRelated
{
    public class AverageForList
    {
        [Fact]
        public void should_calculate_average()
        {
            const string listString = "1->3->5->98->67->456";
            const int expect = 105;

            Assert.Equal(expect, CalculateAverage(listString));
        }

        static int CalculateAverage(string listString)
        {
            string[] stringArray = Regex.Split(listString, "->");
            int arrryLenth = stringArray.Length;
            var numberArray = new int[arrryLenth];

            for(int index = 0; index < arrryLenth; index++)
            {
                numberArray[index] = int.Parse(stringArray[index]);
            }

            return numberArray.Sum(i => i)/numberArray.Length;
            //throw new System.NotImplementedException();
        }
    }
}