namespace TestCustomJsonSerializer
{
    class ClassExample
    {
        public int fieldInt;
        private string _fieldString;

        public string PropertyString { get; set; }

        public int PropertyInt { get; set; }

        public double PropertyDouble { get; set; }

        public float PropertyFloat { get; set; }
        
        public bool PropertyBool { get; set; }

        public object PropertyNull { get; set; }

        public ClassExample(int fieldInt, string fieldString)
        {
            this.fieldInt = fieldInt;
            this._fieldString = fieldString;
        }
    }
}
