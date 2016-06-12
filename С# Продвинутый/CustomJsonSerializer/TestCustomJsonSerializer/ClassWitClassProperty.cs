using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCustomJsonSerializer
{
    class ClassWitClassProperty
    {
        public InnerClass Property1 { get; set; }
        
        public int Property2 { get; set; }

        public class InnerClass
        {
            public int _field1;
            public int _field2;

            public InnerClass(int field1, int field2)
            {
                _field1 = field1;
                _field2 = field2;
            }
        }
    }
}
