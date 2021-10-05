using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMC
{
	public class Processor
	{
		private ControlUnit CU { get; set; }
		private ArithmeticLogicUnit ALU { get; set; }
		private Registers Registers { get; set; }

		public Processor()
		{
			CU = new ControlUnit();
			ALU = new ArithmeticLogicUnit();
			Registers = new Registers();
		}

		public void RunCode(Script script)
		{

		}
	}
}
