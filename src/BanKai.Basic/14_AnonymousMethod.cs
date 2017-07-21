using System;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConvertToLambdaExpression

    public class AnonymousMethod
    {
        [Fact]
        public void should_write_anonymous_inplace()
        {
            Func<int, int> doubleTransform = delegate(int x)  //匿名函数 delegate(patameters){implementtationCode}
            {
                return x * 2;
            };

            int transformResult = doubleTransform(2);

            // change variable value to fix test.
            const int expectedResult = 4;

            Assert.Equal(expectedResult, transformResult);
        }

        [Fact]
        public void should_write_anonymous_method_in_a_more_simple_way()
        {
            Func<int, int> doubleTransform = x => x * 2;  
            //lambda表达式，func是委托，编译器知道将方法赋值给委托，故delegate可省略
            //从委托声明中得知了委托参数类型为int，故int可省略
            //只有一个委托参数，（）省略，块里面只有一条语句{}省略

            int transformResult = doubleTransform(2);

            // change variable value to fix test.
            const int expectedResult = 4;

            Assert.Equal(expectedResult, transformResult);
        }
    }

    // ReSharper restore ConvertToLambdaExpression
}