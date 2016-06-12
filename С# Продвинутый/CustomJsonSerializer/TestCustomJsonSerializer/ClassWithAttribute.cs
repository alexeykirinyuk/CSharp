using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCustomJsonSerializer
{
    class ClassWithAttribute
    {
        public string Property1 { get; set; }

        [NonSerialized]public int _field1;

        public string _field2;

        public ClassWithAttribute(int field1, string field2)
        {
            _field1 = field1;
            _field2 = field2;
        }
    }
}
