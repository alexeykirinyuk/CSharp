using System;
using System.Text;

namespace Scrambler
{
	public class Scrambler
	{
		public string Data { get; private set; }

		private int _numberForXor;

		private int _numberForMinus;  

		public Scrambler(string data, int numberForXor, int numberForMinus)
		{
			this.Data = data;
			this._numberForXor = numberForXor;
			this._numberForMinus = numberForMinus;
		}

		public void Encrypt()
		{
			var stringBuilder = new StringBuilder();

			foreach(var oneChar in Data)
			{
				var encryptedChar = (char) (((int)oneChar ^ _numberForXor) - _numberForMinus);
				stringBuilder.Append(encryptedChar);
			}

			Data = stringBuilder.ToString();
		} 

		public void Deipher()
		{
			var stringBuilder = new StringBuilder();

			foreach(var oneChar in Data)
			{
				var encryptedChar = (char) (((int)oneChar + _numberForMinus) ^ _numberForXor);
				stringBuilder.Append(encryptedChar);
			}

			Data = stringBuilder.ToString();
		}		
	}
}