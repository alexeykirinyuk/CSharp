using System;

namespace Factory
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			God goodGod = new SonFactory();
			
			Console.WriteLine("Man God:");
			goodGod.CreateChild();
			goodGod.CreateGame();

			Console.WriteLine("Woman God: ");

			God badGod = new DotherFactory();
			badGod.CreateChild();
			badGod.CreateGame();
		}
	}
}