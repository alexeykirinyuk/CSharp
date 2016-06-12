using System;

namespace Singleton
{
	public class Life
	{
		private static Life life;
		private static object blockObject = new object();

		public static Life Instance
		{
			get
			{
				if(life == null)
				{
					lock(blockObject)
					{
						if(life == null)
						{
							life = new Life();
						}
					}
				}

				return life;
			}
		}

		private Life() {}

		

		public void WriteLine(string str)
		{
			Console.WriteLine("Life class: " + str);
		}
	}
}