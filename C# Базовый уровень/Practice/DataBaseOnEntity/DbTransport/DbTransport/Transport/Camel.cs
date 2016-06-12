using System;
using System.Collections.Generic;

namespace DataBaseTransport
{
    public class Camel : Transport
    {
        public Gender Sex { get; set; }

        public int Weight { get; set; }

        public Humped NumberHumped { get; set; }

        public Camel(double price, int power, DateTime dateOfManufacture, List<string> equipment) : base(price, power, dateOfManufacture, equipment)
        {
        }

        public Camel()
        {
        }

        public enum Gender
        {
            MALE = 1,
            FEMALE = 2
        }

        public enum Humped
        {
            One = 1,
            Two = 2
        }
    }
}
