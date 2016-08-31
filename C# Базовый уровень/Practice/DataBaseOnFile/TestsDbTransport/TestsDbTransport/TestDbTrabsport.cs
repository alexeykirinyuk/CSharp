using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseOnFile;

namespace TestsDbTransport
{
    [TestClass]
    public class TestDbTransport
    {
        private DbTransport _dataBase = DbTransport.Instance;

        [TestInitialize]
        public void Initialize()
        {
            _dataBase.Clear();
        }

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
            
            _dataBase.Add(addingCar);

            Assert.AreEqual(1, _dataBase.Count);
            Assert.AreSame(addingCar, _dataBase[0]);
        }

        [TestMethod]
        public void GenerateId()
        {
            var camel = Generator.GenerateRandomCamel();
            var car = Generator.GenerateRandomCar();

            _dataBase.Add(car);
            _dataBase.Add(camel);

            Assert.AreEqual(car.TransportId, 0);
            Assert.AreEqual(camel.TransportId, 1);

            _dataBase.Remove(car);

            Assert.AreEqual(camel, _dataBase[1]);
        }

        [TestMethod]
        public void AddCamel()
        {
            var addingCamel = Generator.GenerateRandomCamel();
            
            _dataBase.Add(addingCamel);

            Assert.AreEqual(1, _dataBase.Count);
            Assert.AreSame(addingCamel, _dataBase[0]);
        }

        [TestMethod]
        public void RemoveAt()
        {
            _dataBase.Add(Generator.GenerateRandomCamel());

            Assert.AreEqual(1, _dataBase.Count);

            _dataBase.RemoveAt(0);
            Assert.AreEqual(0, _dataBase.Count);
        }

        [TestMethod]
        public void Remove()
        {
            var addingCar = Generator.GenerateRandomCar();
            _dataBase.Add(addingCar);

            _dataBase.Remove(addingCar);

            Assert.AreEqual(0, _dataBase.Count);
        }

        [TestMethod]
        public void DataStorage()
        {
            _dataBase.Add(Generator.GenerateRandomCar());
            _dataBase.Add(Generator.GenerateRandomCamel());

            Assert.AreEqual(2, _dataBase.Count);

            _dataBase.Save();
            _dataBase.Clear();

            Assert.AreEqual(0, _dataBase.Count);

            _dataBase.Load();

            Assert.AreEqual(2, _dataBase.Count);
        }

        [TestMethod]
        public void AddThousand()
        {
            var counter = 0;
            for (var i = 0; i < 500; i++)
            {
                var car = Generator.GenerateRandomCar();
                var camel = Generator.GenerateRandomCamel();

                DbTransport.Instance.Add(car);
                DbTransport.Instance.Add(camel);

                Assert.AreSame(car, _dataBase[counter++]);
                Assert.AreSame(camel, _dataBase[counter++]);
            }

            Assert.AreEqual(1000, DbTransport.Instance.Count);
        }


    }
}
