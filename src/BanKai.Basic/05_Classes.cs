using BanKai.Basic.Common;
using BanKai.Basic.Extensions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable RedundantEmptyObjectOrCollectionInitializer
    // ReSharper disable UseObjectOrCollectionInitializer

    public class Classes
    {
        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_1()
        {
            var demoObject = new MethodOverloadDemoClass();

            string chosenOne = demoObject.Foo(1);  //传int类型，return "Foo(int)"

            // change variable value to correct one.
            const string expected = "Foo(int)";

            Assert.Equal(expected, chosenOne);
        }

        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_2()
        {
            var demoObject = new MethodOverloadDemoClass();

            string chosenOne = demoObject.Foo((object)1); //object 类型，return "Foo(object)"

            // change variable value to correct one.
            const string expected = "Foo(object)";

            Assert.Equal(expected, chosenOne);
        }

        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_3()
        {
            var demoObject = new MethodOverloadDemoClass();

            const short argument = 2;
            string chosenOne = demoObject.Foo(argument); //无short,编译器选择时，安全转为int

            // change variable value to correct one.
            const string expected = "Foo(int)";

            Assert.Equal(expected, chosenOne);
        }

        [Fact]
        public void should_call_other_instance_constructor_in_overload_constructor()
        {
            var demoClass = new ConstructorOverloadingDemoClass("arg"); //：this(),先执行无参构造函数

            string constructorCallSequence = demoClass.ConstructorCallSequence;

            // change variable value to correct one.
            const string expectedSequence = "Ctor()\r\nCtor(string)\r\n"; //AppendLine

            Assert.Equal(expectedSequence, constructorCallSequence);
        }

        [Fact]
        public void should_generate_parameterless_constructor_by_default()
        {
            var demoClass = new ImplicitConstructorClassDemo();  //编译器生成无参构造函数

            bool hasDefaultConstructor = demoClass.HasDefaultConstructor();

            // change variable value to correct one.
            const bool expected = true;

            Assert.Equal(expected, hasDefaultConstructor);
        }

        [Fact]
        public void should_not_generate_parameterless_constructor_if_parameterized_constructor_exists()
        {
            var demoClass = new ParameterizedConstructorClassDemo(1);  //有构造函数，不生成

            bool hasDefaultConstructor = demoClass.HasDefaultConstructor();  

            // change variable value to correct one.
            const bool expected = false;

            Assert.Equal(expected, hasDefaultConstructor);
        }

        [Fact]
        public void should_initailize_object_properties()
        {
            var demoClass = new ObjectInitializerDemoClass("property1")
            {
                // add property initialization logic here.
                Property1 = "property1.1",    //先执行构造函数，再为属性赋值，
                Property2 = "property2.1"
            };

            const string expectedProperty1 = "property1.1";
            const string expectedProperty2 = "property2.1";

            Assert.Equal(expectedProperty1, demoClass.Property1);
            Assert.Equal(expectedProperty2, demoClass.Property2);
        }

        [Fact]
        public void should_be_able_to_get_and_set_public_auto_properties()
        {
            var demoClass = new AutoPropertyDemoClass();

            demoClass.Name = "My Name";  //set

            // please change variable value to correct one.
            const string expected = "My Name";

            Assert.Equal(expected, demoClass.Name); //get
        }

        [Fact]
        public void should_execute_customized_logic_in_property()
        {
            var demoClass = new CustomizePropertyDemoClass();

            demoClass.Name = "My Name";  //set

            // please change variable value to correct one.
            const string expected = "Your Name Is My Name";

            Assert.Equal(expected, demoClass.Name);
        }

        [Fact]
        public void should_get_correct_value_of_indexer()
        {
            var demoClass = new IndexerDemoClass();  //参数列表不同的3个索引

            string indexerValue = demoClass[2];  //int

            // please change variable value to correct one.
            const string expected = "You are accessing indexer 2";

            Assert.Equal(expected, indexerValue);
        }

        [Fact]
        public void should_access_indexer_with_different_argument_type()
        {
            var demoClass = new IndexerDemoClass();

            string indexerValue = demoClass["stringArgument"];  //string

            // please change variable value to correct one.
            const string expected = "You are accessing indexer stringArgument";

            Assert.Equal(expected, indexerValue);
        }

        [Fact]
        public void should_be_able_to_access_multiple_indexer_arguments()
        {
            var demoClass = new IndexerDemoClass();

            string indexerValue = demoClass[1, "Hello"];  //int,string

            // please change variable value to correct one.
            const string expected = "You are accessing indexer with first argument 1 and second argument Hello";

            Assert.Equal(expected, indexerValue);
        }

        [Fact]
        public void should_do_static_initialization()
        {
            string staticFieldValue = StaticConstructorDemoClass.StaticField;  //先访问静态构造函数，再访问静态属性StaticField

            // please change variable value to correct one.
            const string expected = "You are so cute!";

            Assert.Equal(expected, staticFieldValue);
        }

        [Fact]
        public void should_be_able_to_dispose_object_when_out_of_scope()
        {
            var disposable = new DisposableDemoClass();  //分配资源  

            using (disposable)  //using语句，使用资源
            {
            }//调用DisposableDemoClass中Dispose方法，Dispose是不能抛异常的

            // please change variable value to correct one.
            const bool expected = true;

            Assert.Equal(expected, disposable.IsDisposed);
        }

        [Fact]
        public void should_be_able_to_declare_class_to_different_places()
        {
            var demoClass = new PartialClassDemoClass   //partial
            {
                Name = "Hall",
                Title = "Mr."
            };

            string name = demoClass.ToString();  //override ToString

            // please change variable value to correct one.
            const string expected = "Mr. Hall";

            Assert.Equal(expected, name);
        }
    }

    // ReSharper restore UseObjectOrCollectionInitializer
    // ReSharper restore RedundantEmptyObjectOrCollectionInitializer
}