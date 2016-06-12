using System;

namespace Adapter
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			var person = new Person();

			Girl girl = new Girl();
			bool haveSex = person.Sex(girl);
			if(!haveSex)
			{
				Arm arm = new Arm();
				ArmSexAdapter adapter = new ArmSexAdapter(arm);
				person.Sex(adapter);
			}
		}
	}

}