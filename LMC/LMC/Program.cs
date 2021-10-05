using System;

namespace LMC
{
	class Program
	{
		static void Main(string[] args)
		{
			Processor myCPU = new Processor();
			Command myCommand = new Command();
			myCommand.Opcode = 7;
			myCommand.Operand = 02;
			Script myScript = new Script();
			myScript.Commands.Add(myCommand);
			myCPU.RunCode(myScript);
		}
	}
}