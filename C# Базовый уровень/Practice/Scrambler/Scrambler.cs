using System;
using System.Text;

namespace Scrambler
{
	public class Scrambler
	{
		public string Data { get; private set; }

		private int _numForXor;

		private int _numForMinus;  

		public Scrambler(string data)
		{
			this.Data = data;

			Random rand = new Random();
			_numForXor = rand.Next(1, 20);
			_numForMinus = rand.Next(1, 10);
		}

		public void Encrypt()
		{
			var stringBuilder = new StringBuilder();

			foreach(var ch in Data)
			{
				char encryptedChar = (char) (((int)ch ^ _numForXor) - _numForMinus);
				stringBuilder.Append(encryptedChar);
			}

			Data = stringBuilder.ToString();
		} 

		public void Deipher()
		{
			var stringBuilder = new StringBuilder();

			foreach(var ch in Data)
			{
				char encryptedChar = (char) (((int)ch + _numForMinus) ^ _numForXor);
				stringBuilder.Append(encryptedChar);
			}

			Data = stringBuilder.ToString();
		}		
	}
}