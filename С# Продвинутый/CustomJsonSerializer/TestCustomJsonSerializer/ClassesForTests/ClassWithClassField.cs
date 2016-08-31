namespace TestCustomJsonSerializer
{
    class ClassWithClassField
    {
        public InnerClass PropertyInnerClass { get; set; }

        public class InnerClass
        {
            public string Property1 { get; set; }
            public float Property2 { get; set; }
        }

    }
}
