using System;
using CustomJsonSerializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCustomJsonSerializer
{
    [TestClass]
    public class TestCustomConvert
    {
        [TestMethod]
        public void ConvertExampleClass()
        {
            ExampleClass car = new ExampleClass(54, "field2value") { Property1 = "hell", Property2 = 1, Property3 = 43.3 };
            string str = CustomConvert.Convert(car);
            string ser = "{\"Property1\"=\"hell\",\"Property2\"=1,\"Property3\"=43,3,\"_field1\"=54}";
            Assert.AreEqual(str, ser);
        }

        [TestMethod]
        public void ConvertClassWithAttributes()
        {
            var obj = new ClassWithAttribute(1, "_field2value") { Property1 = "prop1value" };
            string json = CustomConvert.Convert(obj);

            string ser = "{\"Property1\"=\"prop1value\",\"_field2\"=\"_field2value\"}";
            Assert.AreEqual(json, ser);
        }

        [TestMethod]
        public void ConvertClassWithRefProperty()
        {
            var obj = new ClassWitClassProperty()
            { Property1 = new ClassWitClassProperty.InnerClass(1, 2), Property2 = 43 };
            string json = CustomConvert.Convert(obj);
            string ser = "{\"Property1\"={\"_field1\"=1,\"_field2\"=2},\"Property2\"=43}";
            Assert.AreEqual(json, ser);
        }

        [TestMethod]
        public void ConvertClassWithClassField()
        {
            var obj = new ClassWithClassField
            {
                field1 = new ClassWithClassField.InnerClass() { Property1 = "prop1value", Property2 = 434 },
                field2 = new ClassWithClassField.InnerClass() { Property1 = "prop1value", Property2 = 434 },
                field3 = 32423,
                Prop1 = 12
            };
            string json = CustomConvert.Convert(obj);
            string ser = "{\"Prop1\"=12,\"field1\"={\"Property1\"=\"prop1value\",\"Property2\"=434},\"field2\"={\"Property1\"=\"prop1value\",\"Property2\"=434}," +
                "\"field3\"=32423}";
            Assert.AreEqual(json, ser);

        }
    }
}
