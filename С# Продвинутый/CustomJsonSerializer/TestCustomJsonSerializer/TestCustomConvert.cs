using CustomJsonSerializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCustomJsonSerializer
{
    [TestClass]
    public class TestCustomConvert
    {
        [TestMethod]
        public void ConvertExampleClass()
        {
            ClassExample @object = new ClassExample(54, "field2value")
            {
                PropertyString = "hell",
                PropertyInt = 1,
                PropertyDouble = 43.3,
                PropertyFloat = 12.2f,
                PropertyBool = true,
                PropertyNull = null
            };

            var customJson = CustomConverter.Convert(@object);
            var handJson = "{\"PropertyString\"=\"hell\",\"PropertyInt\"=1,\"PropertyDouble\"=43.3," + 
                "\"PropertyFloat\"=12.2,\"PropertyBool\"=true,\"PropertyNull\"=null" +
                ",\"fieldInt\"=54}";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertClassWithAttributes()
        {
            var @object = new ClassWithAttribute()
            {
                PropertySerialize = "prop1value",
                FieldNonSerialize = 5
            };

            var customJson = CustomConverter.Convert(@object);
            var handJson = "{\"PropertySerialize\"=\"prop1value\"}";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertClassWithRefProperty()
        {
            var @object = new ClassWitClassProperty()
            {
                Property1 = new ClassWitClassProperty.InnerClass(1, 2),
                Property2 = 43
            };

            var customJson = CustomConverter.Convert(@object);
            var handJson = "{\"Property1\"={\"field1\"=1,\"field2\"=2},\"Property2\"=43}";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertClassWithObjectField()
        {
            var @object = new ClassWithClassField()
            {
                PropertyInnerClass = new ClassWithClassField.InnerClass()
                {
                    Property1 = "prop1value",
                    Property2 = 434
                }
            };

            var customJson = CustomConverter.Convert(@object);
            var handJson = "{\"PropertyInnerClass\"={\"Property1\"=\"prop1value\",\"Property2\"=434}}";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertArray()
        {
            var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var customJson = CustomConverter.Convert(intArray);
            var handJson = "[1,2,3,4,5,6,7,8,9,10]";
            Assert.AreEqual(handJson, customJson);

            var stringArray = new string[] { "hello", "my", "name", "is" };
            customJson = CustomConverter.Convert(stringArray);
            handJson = "[\"hello\",\"my\",\"name\",\"is\"]";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertInt()
        {
            var customJson = CustomConverter.Convert(5);
            Assert.AreEqual("5", customJson);
        }

        [TestMethod]
        public void ConvertStructure()
        {
            var @struct = new StructType()
            {
                A = 5,
                B = 3
            };

            var customJson = CustomConverter.Convert(@struct);
            var handJson = "{\"A\"=5,\"B\"=3}";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertDateDime()
        {
            var dateTime = DateTime.Parse("1.02.2015 11:02:20");
            var customJson = CustomConverter.Convert(dateTime);
            var handJson = "2015-02-01T05:02:20Z";
            Assert.AreEqual(handJson, customJson);
        }

        [TestMethod]
        public void ConvertPropertyWithException()
        {
            var @object = new ClassWithPropertyException()
            {
                PropertyString = "hell"
            };

            var customJson = CustomConverter.Convert(@object);
            var handJson = "{\"PropertyString\"=\"hell\"}";
            Assert.AreEqual(handJson, customJson);
        }

        struct StructType
        {
            public int A;
            public int B;
        }
    }
}
