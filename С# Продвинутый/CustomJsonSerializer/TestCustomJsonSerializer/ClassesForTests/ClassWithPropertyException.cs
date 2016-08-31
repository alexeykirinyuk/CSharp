using System;

namespace TestCustomJsonSerializer
{
    class ClassWithPropertyException
    {
        public string PropertyString { get; set; }

        public string PropertyWithException
        {
            get
            {
                throw new Exception();
            }

            set
            {
                throw new Exception();
            }
        }
    }
}
