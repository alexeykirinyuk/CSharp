using System;
using System.Diagnostics;

namespace Recurse
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			var count = int.Parse(args[0]);

			var sw = new Stopwatch();
			sw.Start();
			var res = Fib(count);
			sw.Stop(); 

			TimeSpan ts = sw.Elapsed;
        	
        	string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            	ts.Hours, ts.Minutes, ts.Seconds,
            	ts.Milliseconds / 10);
	        Console.WriteLine("RunTime {0}; Fib({1}) = {2}",elapsedTime, count, res);
		}

		public static long Fib(long n)
		{
			if(n > 1) 
			{
				return IterFib(1, 1, n - 2);
			}
			else 
			{
				return n;
			}
		}

		private static long IterFib(long prev, long current, long n)
		{
			Console.WriteLine("prev = " + prev + "; current = " + current + "; n = " + n);
			if(n == 0) 
			{
				return current;
			}
			else
			{ 
				return IterFib(current, prev + current, n - 1);
			}
		}
	}
}