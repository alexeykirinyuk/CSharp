using System;

namespace Factory
{
	public interface Reader
	{
		string Read();
	}

	public static class File
	{
		public static Reader GetReader(string path)
		{
			var pathSplited = path.Split('.');
			var format = pathSplited[pathSpleted.Length - 1];
			Reader resultReader;

			switch(format)
			{
				case "rtf":
					resultReader = new RtfReader();
					break;
				case "docx":
					resultReader = new MicrosoftWordReader();
					break;
				default:
					resultReader = new TxtReader();
					break;
			}

			return resultReader;
		}
	} 

	public class RtfReader : Reader
	{
		public string Read() 
		{
			return "RtfReader Read...";
		}
	}

	public class TxtReader : Reader
	{
		public string Read()
		{
			return "TxtReader Read...";
		}
	}

	public class MicrosoftWordReader : Reader
	{
		public string Read()
		{
			return "MicrosoftWordReader Read...";
		}
	}
}
