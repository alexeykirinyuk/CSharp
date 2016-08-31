using System;
using System.Linq;
using System.Text;

namespace ScramblerLib
{
    public class Scrambler
    {
        public string Data { get; private set; }
        
        public Scrambler(string data)
        {
            this.Data = data;
        }

        public void Encrypt()
        {
            var stringBuilder = new StringBuilder();

            var random = new Random();
            var numberForXor = random.Next();
            var numberForMinus = random.Next();

            foreach (var oneChar in Data)
            {
                var encryptedChar = (char)(((int)oneChar ^ numberForXor) - numberForMinus);
                stringBuilder.Append(encryptedChar);
            }

            stringBuilder.Append(':').Append(numberForXor).Append(':').Append(numberForMinus);
            Data = stringBuilder.ToString();
        }

        public void Deipher()
        {
            var stringBuilder = new StringBuilder();

            var dataParams = Data.Split(':');
            var numberForMinus = int.Parse(dataParams[dataParams.Length - 1]);
            var numberForXor = int.Parse(dataParams[dataParams.Length - 2]);

            Data = string.Join("", dataParams.Take(dataParams.Length - 2));

            foreach (var oneChar in Data)
            {
                var encryptedChar = (char)(((int)oneChar + numberForMinus) ^ numberForXor);
                stringBuilder.Append(encryptedChar);
            }
            Data = stringBuilder.ToString();
        }
    }
}