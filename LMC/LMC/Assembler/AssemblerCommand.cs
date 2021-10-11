using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMC.Assembler
{
	public class AssemblerCommand
	{
		public int Operand;
		public string Mnemonic;

		public AssemblerCommand() { }
		public AssemblerCommand(string mnemonic, int operand = 0)
		{
			Operand = operand;
			Mnemonic = mnemonic;
		}
	}
}
