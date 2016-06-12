using System;
using System.Threading;
using System.Collections.Generic;

namespace Multithreading
{
	public class MainClass
	{
		private static List<string> list;
		private static object blockObj = new object();

		public static void Main(string[] args)
		{
			const int N = 50;
			list = new List<string>();

            for (var i = 0; i < N; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(AddList));
                var str = "string num " + i;
                thread.Start(str);
			}

			Thread.Sleep(100);
			for(var i = 0; i < N; i++)
			{
				var thread = new Thread(new ParameterizedThreadStart(WriteConsole));
				thread.Start(i);
			}
            Console.ReadLine();
        }

		private static void AddList(object i)
		{
			lock(blockObj)
			{
				list.Add((string) i);
			}
		}

		private static void WriteConsole(object index)
		{
			lock(blockObj)
			{
                int i = (int)index;
				Console.WriteLine(list[i]);
            }
		}
	}
}