using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCustomJsonSerializer
{
    class ExampleClass
    {
        public int _field1;
        private string _field2;

        public string Property1 { get; set; }

        public int Property2 { get; set; }

        public double Property3 { get; set; }

        
        public ExampleClass(int field1, string field2)
        {
            this._field1 = field1;
            this._field2 = field2;
        }
    }
}
