using System;

namespace Factory
{
	public abstract class God
	{
		public abstract Child CreateChild();
		public abstract Game CreateGame();
	}

	public class SonFactory : God
	{
		public override Child CreateChild()
		{
			Console.WriteLine("Create Son...");
			return new Son();
		}

		public override Game CreateGame()
		{
			Console.WriteLine("Create Gta...");
			return new Gta();
		}
	}

	public class DotherFactory : God
	{
		public override Child CreateChild()
		{
			Console.WriteLine("Create Dother...");
			return new Dother();
		}

		public override Game CreateGame()
		{
			Console.WriteLine("Create Barbie...");
			return new Barbie();
		}
	}

	public class Child {}
	public class Son : Child {}
	public class Dother : Child {}

	public class Game {}
	public class Gta : Game {}
	public class Barbie : Game {}
}