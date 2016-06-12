using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseOnFile
{
    public abstract class Transport
    {
        private int horsePower;

        public long Transport_ID { get; set; }

        public double Price { get; set; }

        public int Power { get; set; }

        public DateTime? DateOfManufacture { get; set; }

        public List<string> Equipment { get; set; }

        public Transport(double price, int horsePower, DateTime dateOfManufacture, List<string> equipment)
        {
            this.Price = price;
            this.Power = horsePower;
            this.DateOfManufacture = dateOfManufacture;
            this.Equipment = equipment;
        }

        public Transport()
        {

        }

        public override string ToString()
        {
            var builder = new StringBuilder(Transport_ID.ToString()).Append("\t");
            builder.Append(Price).Append("\t");
            builder.Append(Power).Append("\t");
            builder.Append(DateOfManufacture).Append("\t");
            return builder.ToString();
        }
    }
}
