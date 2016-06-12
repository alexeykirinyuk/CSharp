using System;

namespace Singleton
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			// Init Life
			Life life = Life.Instance;

			life.WriteLine(life.GetHashCode().ToString());

			// If I want new life((((
			Life iWantNewLife = Life.Instance;

			life.WriteLine(iWantNewLife.GetHashCode().ToString());
		}
	}
}