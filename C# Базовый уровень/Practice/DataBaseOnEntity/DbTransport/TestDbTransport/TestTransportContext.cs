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
        public void Add()
        {
            Clear();
            int addingCarId = AddCar(); 

            using (var dbTransport = new TransportContext())
            {
                Transport trans = dbTransport.Transports
                    .Where(a => a.TransportID == addingCarId)
                    .First();
                Assert.IsNotNull(trans);
            }
        }

        [TestMethod]
        public void Remove()
        {
            Clear();
            int id = AddCar();

            using (var dbTransport = new TransportContext())
            {
                Assert.AreEqual(dbTransport.Transports.Count(), 1);

                var transport = dbTransport.Transports
                    .Include("Routes")
                    .Include("Two")
                    .Where(a => id == a.TransportID)
                    .First();

                Assert.IsNotNull(dbTransport.Transports
                    .Where(a => id == a.TransportID)
                    .First());
                
                dbTransport.Transports.Remove(transport);
                dbTransport.SaveChanges();

                Assert.AreEqual(dbTransport.Transports.Count(), 0);
            }
        }

        [TestMethod]
        public void Edit()
        {
            int id = AddCar();

            var dbTransport = new TransportContext();

            var transport = (Car) dbTransport.Transports
                .Where(t => id == t.TransportID)
                .First();

            Assert.AreEqual(transport.Mark, "Taota");

            transport.Mark = "Pedik";
            dbTransport.SaveChanges();

            var editedCar = (Car) dbTransport.Transports
                .Where(t => id == t.TransportID)
                .FirstOrDefault();

            Assert.AreEqual(editedCar.Mark, "Pedik");
        }

        [TestMethod]
        public void Clear()
        {
            var dbTransport = new TransportContext();

            foreach (var transport in dbTransport.Transports.Include("One").Include("Routes"))
            {
                dbTransport.Transports.Remove(transport);
            }
            dbTransport.SaveChanges();

            Assert.AreEqual(dbTransport.Transports.Count(), 0);
        }
        
        [TestMethod]
        public void OneToMany()
        {
            Clear();
            int id = AddCar();
            var dbTransport = new TransportContext();
            Car car = (Car) dbTransport.Transports
                .Where(t => id == t.TransportID)
                .First();

            Assert.IsNotNull(car.Routes);
            Assert.IsNotNull(car.Routes[0]);
            Assert.AreEqual(car.Routes[0].Begin, "Караганда");
            Assert.AreEqual(car.Routes[0].End, "Новосибирск");
        }
        

        [TestMethod]
        public void OneToOne()
        {
            Clear();
            int id = AddCar();
            var dbTransport = new TransportContext();
            Transport transport = dbTransport.Transports
                .Where(t => id == t.TransportID)
                .First();

            Assert.IsNotNull(transport.One);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void Lazy()
        {
            Clear();
            for(int i = 0; i < 10; i++)
            {
                AddCar();
            }

            Transport transport;

            using (var dbTransport = new TransportContext())
            {
                transport = dbTransport.Transports.First();
            }

            var routes = transport.Routes;
        }

        [TestMethod]
        public void Include()
        {
            Clear();
            AddCar();

            Transport transport;

            using (var dbTransport = new TransportContext())
            {
                transport = dbTransport.Transports
                    .Include("Routes")
                    .Include("One")
                    .First();
            }

            var routes = transport.Routes;
            var one = transport.One;

            Assert.IsNotNull(routes);
            Assert.IsNotNull(one);
        }

        private int AddCar()
        {
            var dbTransport = new TransportContext();
            Car addingCar = new Car(100, 100, new DateTime(1995, 11, 05), new List<string> { "Hello", "Test" })
            {
                Color = Color.BLUE,
                Mark = "Taota",
                StateLicensePlate = "MV 234343 MC",
                Routes = new List<Route>()
                {
                    new Route("Новосибирск", "Караганда")
                },
                One = new OneToOne()
            };
            dbTransport.Transports.Add(addingCar);
            dbTransport.SaveChanges();

            return addingCar.TransportID;
        }
    }
}
