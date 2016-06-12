using System;

namespace Adapter
{
	public class Person
	{
		public bool Sex(Sex sexObject)
		{
			bool haveSex = sexObject.GetSex();
			Console.WriteLine("Sex with " + sexObject.ToString() + " = " + haveSex);
			return haveSex;
		}
	}

	public interface Sex
	{
		bool GetSex();
	}

	public class Girl : Sex
	{
		public bool GetSex()
		{
			Random rand = new Random();
			return rand.Next(0, 1000) == 2;
		}

		public override string ToString()
		{
			return "Girl";
		}
	}

	public class Arm
	{
		public bool Masturbation()
		{
			return true;
		}

		public override string ToString()
		{
			return "Arm";
		}
	}

	public class ArmSexAdapter : Sex
	{
		private Arm arm;

		public ArmSexAdapter(Arm arm)
		{
			this.arm = arm;
		}

		public bool GetSex()
		{
			return arm.Masturbation();
		}

		public override string ToString()
		{
			return arm.ToString();
		}
	}


}