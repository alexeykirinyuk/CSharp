using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Recurse
{
	public class MainClass
	{
		private static Dictionary<long?, long?> dictionary;

		public static void Main(string[] args)
		{
			var count = int.Parse(args[0]);

			dictionary = new Dictionary<long?, long?>();

			var stopWatch = new Stopwatch();
			stopWatch.Start();
			var res = Fib(count);
			stopWatch.Stop(); 

			TimeSpan ts = stopWatch.Elapsed;
        	
        	string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            	ts.Hours, ts.Minutes, ts.Seconds,
            	ts.Milliseconds / 10);
	        Console.WriteLine("RunTime {0}; Fib({1}) = {2}",elapsedTime, count, res);
		}

		public static long Fib(long n)
		{

			long? found;
			dictionary.TryGetValue(n, out found);
			if(null != found) return (long)found; 

			if(n > 2) 
			{
				long fibNumber = Fib(n - 1) + Fib(n - 2);
				Console.WriteLine(n + " : " +  fibNumber);
				dictionary.Add(n, fibNumber);
				return fibNumber;
			}
			else 
			{
				return 1;
			}
		}
	/*
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
		*/
	}
}