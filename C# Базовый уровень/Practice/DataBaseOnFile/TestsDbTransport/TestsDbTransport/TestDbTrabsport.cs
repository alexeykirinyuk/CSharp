using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseOnFile;
using System.Collections.Generic;
using System.Linq;

namespace TestsDbTransport
{
    [TestClass]
    public class TestDbTransport
    {
        [TestMethod]
        public void Instanse()
        {
            var dbTransportVer1 = DbTransport.Instance;
            var dbTransportVer2 = DbTransport.Instance;

            Assert.AreEqual(dbTransportVer1, dbTransportVer2); 
        }

        [TestMethod]
        public void AddCar()
        {
            var addingCar = Generator.GenerateRandomCar();

            var dbTransport = DbTransport.Instance;
            dbTransport.Clear();

            dbTransport.Add(addingCar);

            Assert.AreEqual(1, dbTransport.Count);
            Assert.AreSame(addingCar, dbTransport[0]);
        }
        
        [TestMethod]
        public void AddCamel()
        {
            var addingCamel = Generator.GenerateRandomCamel();

            var dbTransport = DbTransport.Instance;
            dbTransport.Clear();
            dbTransport.Add(addingCamel);

            Assert.AreEqual(1, dbTransport.Count);
            Assert.AreSame(addingCamel, dbTransport[0]);
        }

        [TestMethod]
        public void AddThousandCar()
        {
            AddThousand<Car>();
        }

        [TestMethod]
        public void AddThousandCamel()
        {
            AddThousand<Camel>();
        }
        
        [TestMethod]
        public void RemoveAt()
        {
            var dbTransport = DbTransport.Instance;
            dbTransport.Clear();
            dbTransport.Add(Generator.GenerateRandomCamel());

            Assert.AreEqual(1, dbTransport.Count);

            dbTransport.RemoveAt(0);
            Assert.AreEqual(0, dbTransport.Count);
        }

        [TestMethod]
        public void Remove()
        {
            var dbTransport = DbTransport.Instance;
            dbTransport.Clear();

            var addingCar = Generator.GenerateRandomCar();
            dbTransport.Add(addingCar);

            dbTransport.Remove(addingCar);

            Assert.AreEqual(0, dbTransport.Count);
        }

        [TestMethod]
        public void DataStorage()
        {
            var dbTransport = DbTransport.Instance;
            dbTransport.Clear();

            dbTransport.Add(Generator.GenerateRandomCar());
            dbTransport.Add(Generator.GenerateRandomCamel());

            Assert.AreEqual(2, dbTransport.Count);

            dbTransport.Save();
            dbTransport.Clear();

            Assert.AreEqual(0, dbTransport.Count);

            dbTransport.Load();

            Assert.AreEqual(2, dbTransport.Count);
        }

        [TestMethod]
        public void Insert()
        {
            var dbTransport = DbTransport.Instance;
            dbTransport.Clear();

            Transport[] addedTransports = new Transport[]
            {
                Generator.GenerateRandomCamel(),
                Generator.GenerateRandomCar(),
                Generator.GenerateRandomCar()
            };

            foreach(var transport in addedTransports)
            {
                dbTransport.Add(transport);
            }
            
            Assert.AreEqual(dbTransport.Count, 3);

            var car = Generator.GenerateRandomCar();
            dbTransport.Insert(1, car);

            for(int i = 0; i < 1; i++)
            {
                Assert.AreEqual(dbTransport[i], addedTransports[i]);
            }

            Assert.AreEqual(dbTransport[1], car);

            for(int i = 1; i < 3; i++)
            {
                Assert.AreEqual(dbTransport[i + 1], addedTransports[i]);
            }
        }

        private void AddThousand<T>() 
            where T : Transport, new()
        {
            DbTransport.Instance.Clear();

            var rand = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var carCamel = rand.Next(1, 3);
                Transport transport;
                switch(carCamel)
                {
                    case 1:
                        transport = Generator.GenerateRandomCar();
                        break;
                    case 2:
                        transport = Generator.GenerateRandomCamel();
                        break;
                }
                var addingTransport = Generator.GenerateRandomCamel();
                DbTransport.Instance.Add(addingTransport);

                Assert.AreSame(addingTransport, DbTransport.Instance[i]);
                Assert.AreEqual(i, DbTransport.Instance[i].Transport_ID);
            }

            Assert.AreEqual(1000, DbTransport.Instance.Count);
        }


    }
}
