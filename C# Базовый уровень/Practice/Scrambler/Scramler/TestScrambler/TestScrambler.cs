using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScramblerLib;

namespace TestScrambler
{
    [TestClass]
    public class TestScrambler
    {
        [TestMethod]
        public void Encrypt()
        {
            const string dataString = "Привет";

            var scrambler = new Scrambler(dataString);
            
            scrambler.Encrypt();

            var afterEncrypt = scrambler.Data;

            Assert.AreNotEqual(afterEncrypt, dataString);

            scrambler = new Scrambler(afterEncrypt);
            scrambler.Deipher();

            Assert.AreEqual(scrambler.Data, dataString);
        }
    }
}
