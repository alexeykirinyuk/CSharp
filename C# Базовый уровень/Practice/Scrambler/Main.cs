using System;

namespace Scrambler
{
	public class MainClass
	{

		public static void Main(string[] args)
		{
			var scrambler = new Scrambler("Привет, мой пароль от кары 2724");

			string strBeforeEncrypt = scrambler.Data;

			scrambler.Encrypt();
			string strEncrypt = scrambler.Data;

			scrambler.Deipher();
			string stcDeipher = scrambler.Data;

			Console.WriteLine("strBeforeEncrypt = " + strBeforeEncrypt);
			Console.WriteLine("strEncrypt = " + strEncrypt);
			Console.WriteLine("stcDeipher = " + stcDeipher);

			Console.ReadLine();
		}
	}
}