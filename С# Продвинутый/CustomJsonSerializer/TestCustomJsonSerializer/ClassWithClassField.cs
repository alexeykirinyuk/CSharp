using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCustomJsonSerializer
{
    class ClassWithClassField
    {
        public InnerClass field1;
        public InnerClass field2;

        public int Prop1 { get; set; }
        public int field3;

        public class InnerClass
        {
            public string Property1 { get; set; }
            public float Property2 { get; set; }
        }

    }
}
