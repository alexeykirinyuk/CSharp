using System;

namespace TestCustomJsonSerializer
{
    class ClassWithAttribute
    {
        public string PropertySerialize { get; set; }

        [NonSerialized]
        public int FieldNonSerialize;
    }
}
