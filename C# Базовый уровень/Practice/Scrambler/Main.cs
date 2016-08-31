using System;

namespace Scrambler
{
	public class MainClass
	{

		public static void Main(string[] args)
		{
			var scrambler = new Scrambler("Привет, мой пароль от кары 2724", 10, 3);

			var beforeEncrypt = scrambler.Data;

			scrambler.Encrypt();
			var encrypted = scrambler.Data;

			scrambler.Deipher();
			var deiphered = scrambler.Data;

			Console.WriteLine("String before encrypt = " + beforeEncrypt);
			Console.WriteLine("String encrypted = " + encrypted);
			Console.WriteLine("String deiphered = " + deiphered);
		}
	}
}