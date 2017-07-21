using System;
using BanKai.Basic.Common;
using BanKai.Basic.Extensions;
using Xunit;

namespace BanKai.Basic
{
    public class GenericsRelated
    {
        [Fact]
        public void should_resolve_correct_type()
        {
            var genericObjectWithStringAsTypeArgument = new BasicGenericDemoClass<string>();  //类型实参：string

            Type valuePropertyType = genericObjectWithStringAsTypeArgument.GetPropertyType("Value"); //在genericObjectWithStringAsTypeArgument这个对象下"Value"的类型

            // correct the variable value to fix the test
            Type expectedValuePropertyType = typeof(string);

            Assert.Equal(expectedValuePropertyType, valuePropertyType);
        }

        [Fact]
        public void should_restrict_to_value_type_on_type_argument()
        {
            var demoObject = new ValueTypeRestrictedGenericDemoClass<int>();  //where:struct值类型可作为实参

            // correct the variable value to fix the test
            const int expectedInitialValue = 0; //default<T>

            Assert.Equal(expectedInitialValue, demoObject.Value);
        }

        [Fact]
        public void should_restrict_to_ref_type_on_type_argument()
        {
            var demoObject = new RefTypeRestrictedGenericDemoClass<string>(); //where:class引用类型可作为实参

            // correct the variable value to fix the test
            const string expectedInitialValue = null;

            Assert.Equal(expectedInitialValue, demoObject.Value);
        }

        [Fact]
        public void should_restrict_to_default_constructor_on_type_argument()
        {
            var demoObject = new DefaultCtorRestrictedGenericDemoClass<SayHelloByDefault>(); //where:new()构造函数约束（带公共无参构造函数的类型可作为实参）

            // correct the variable value to fix the test
            const string expectedStringValue = "Hello";
            //如果SayHelloByDefault类中未重写ToString方法， demoObject.Value.ToString()="BanKai.Basic.Common.SayHelloByDefault"
            Assert.Equal(expectedStringValue, demoObject.Value.ToString());
        }

        [Fact]
        public void should_restrict_to_interface_on_type_argument()
        {
            var demoObject = new InterfaceRestrictedGenericDemoClass<Duck>();  //Duck实现了ITalkable接口

            // correct the variable value to fix the test
            const string expectedStringValue = "Ga, ga, ...";

            Assert.Equal(expectedStringValue, demoObject.ToString());
        }

        [Fact]
        public void should_automatically_resolve_parameter_type()
        {
            string actualReturnValue = GenericMethodDemoClass.ResolvableGenericMethod(new Duck()); //方法参数和类型参数类型相同，方法参数的类型确定，类型参数可以省略

            // correct the variable value to fix the test
            const string expectedReturnValue = "ResolvableGenericMethod(T) called. T is Duck";

            Assert.Equal(expectedReturnValue, actualReturnValue);
        }

        [Fact]
        public void should_specify_type_if_type_argument_cannot_be_resovled()
        {
            string actualReturnValue = GenericMethodDemoClass.NotResolvableGenericMethod<string>();

            // correct the variable value to fix the test
            const string expectedReturnValue = "NotResolvableGenericMethod() called. T is String";

            Assert.Equal(expectedReturnValue, actualReturnValue);
        }

        [Fact]
        public void should_be_different_types_for_different_type_argument()
        {
            // correct the variable value to fix the test
            const bool areEqual = false;

            Assert.Equal(
                areEqual,
                typeof(BasicGenericDemoClass<int>) == typeof(BasicGenericDemoClass<string>));
        }

        [Fact]
        public void should_be_unique_for_different_closed_type()
        {
            GenericTypeStaticDataDemoClass<int>.Count++;
            GenericTypeStaticDataDemoClass<string>.Count = 5;
            GenericTypeStaticDataDemoClass<int>.Count = 2;

            // correct the variable values for the following 2 lines to fix the test
            const int expectedCountForIntClosedType = 2;
            const int expectedCountForStringClosedType = 5;

            Assert.Equal(expectedCountForIntClosedType, GenericTypeStaticDataDemoClass<int>.Count);
            Assert.Equal(expectedCountForStringClosedType, GenericTypeStaticDataDemoClass<string>.Count);
        }

        [Fact]
        public void should_declare_out_if_generic_type_is_covariant()
        {
            var covariantDemoObject = new CovariantContravariantDemoClass<string>("Hello");
            ICovariantGetDemo<object> covariantWithBaseTypeArgument = covariantDemoObject;  //ICovariantGetDemo：协变接口（string=>Object）
            object value = covariantWithBaseTypeArgument.Get();

            // correct the variable value to fix the test
            object expectedValue = "Hello";

            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void should_declare_in_if_generic_type_is_contravariant()
        {
            var contravariantDemoObject = new CovariantContravariantDemoClass<object>(null);
            IContravariantSetDemo<string> contravariantWithDerivedTypeArgument =
                contravariantDemoObject;                //IContravariantSetDemo:逆变object=>string
            contravariantWithDerivedTypeArgument.Put("Hello");

            // correct the variable value to fix the test
            object expectedValue = "Hello";

            Assert.Equal(expectedValue, contravariantDemoObject.Get());
        }
    }
}