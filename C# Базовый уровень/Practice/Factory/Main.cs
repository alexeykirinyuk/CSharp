using System;

namespace Factory
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var reader = File.GetReader(args[0]);
			var readerString = reader.Read();

			Console.WriteLine(readerString);
		}
	}
}