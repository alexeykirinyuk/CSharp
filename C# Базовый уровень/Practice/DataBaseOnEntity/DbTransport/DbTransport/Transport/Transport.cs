using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseTransport
{
    public abstract class Transport
    {
        [Key]
        public int TransportID { get; set; }

        public double Price { get; set; }

        public int Power { get; set; }

        public DateTime? DateOfManufacture { get; set; }

        public List<string> Equipment { get; set; }

        public virtual List<Route> Routes { get; set; } 

        [ForeignKey("One")]
        public int OneId { get; set; }

        public virtual OneToOne One { get; set; }

        public Transport(double price, int horsePower, DateTime? dateOfManufacture, List<string> equipment)
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
            var builder = new StringBuilder(TransportID.ToString()).Append("\t");
            builder.Append(Price).Append("\t");
            builder.Append(Power).Append("\t");
            builder.Append(DateOfManufacture).Append("\t");
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            Transport transport = obj as Transport;
            if (transport == null) return false;

            bool result = true;
            result = Price == transport.Price;
            result = Power == transport.Power;
            result = DateOfManufacture == transport.DateOfManufacture;
            result = Equipment == transport.Equipment;
            result = Routes == transport.Routes;

            return result;
        }
    }
}
