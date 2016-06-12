using System;
using System.Collections.Generic;

namespace DataBaseOnFile
{
    public class Car : Transport
    {
        public string Mark { get; set; }

        public string StateLicensePlate { get; set; }

        public Color Color { get; set; }        
        
        public Car(double price, int power, DateTime dateOfManufacture, List<string> equipment) : base(price, power, dateOfManufacture, equipment)
        {
        }
        
        public Car()
        {
        }
        
    }
}
