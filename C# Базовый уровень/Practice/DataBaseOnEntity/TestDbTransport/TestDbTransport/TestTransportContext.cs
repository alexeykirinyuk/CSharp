using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseTransport;
using System.Collections.Generic;
using System.Linq;

namespace TestDbTransport
{
    [TestClass]
    public class TestTransportContext
    {
        [TestMethod]
        public void TestAdd()
        {
            Car addingCar;
            Clear();
            using (var dbTransport = new TransportContext())
            {
                
                addingCar = new Car(100, 100, new DateTime(1995, 11, 05), new List<string> { "Hello", "Test" })
                {
                    Color = Color.BLUE,
                    Mark = "Taota",
                    StateLicensePlate = "MV 234343 MC"
                };
                dbTransport.Transports.Add(addingCar);
                dbTransport.SaveChanges();
            }
        }

        private static void Clear()
        {
            var dbTransport = new TransportContext();

            foreach(var transport in dbTransport.Transports)
            {
                dbTransport.Transports.Remove(transport);
            }
            dbTransport.SaveChanges();
        }
    }
}
