namespace TestCustomJsonSerializer
{
    class ClassWitClassProperty
    {
        public InnerClass Property1 { get; set; }
        
        public int Property2 { get; set; }

        public class InnerClass
        {
            public int field1;
            public int field2;

            public InnerClass(int field1, int field2)
            {
                this.field1 = field1;
                this.field2 = field2;
            }
        }
    }
}
