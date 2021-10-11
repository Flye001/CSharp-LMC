using LMC.Assembler;

namespace LMC
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create new CPU and RAM object
			RandomAccessMemory myRam = new RandomAccessMemory();
			Processor myCPU = new Processor();

			// Create a script using machiene code
			Script multiplication = new Script();
			multiplication.Commands.Add(new Command(9, 01)); // INP
			multiplication.Commands.Add(new Command(3, 99)); // STA 99
			multiplication.Commands.Add(new Command(9, 01)); // INP
			multiplication.Commands.Add(new Command(3, 97)); // STA 97
			multiplication.Commands.Add(new Command(5, 98)); // LDA 98
			multiplication.Commands.Add(new Command(1, 99)); // ADD 99
			multiplication.Commands.Add(new Command(3, 98)); // STA 98
			multiplication.Commands.Add(new Command(5, 97)); // LDA 97
			multiplication.Commands.Add(new Command(2, 15)); // SUB 16
			multiplication.Commands.Add(new Command(3, 97)); // STA 97
			multiplication.Commands.Add(new Command(7, 12)); // BRZ 17
			multiplication.Commands.Add(new Command(8, 4)); // BRP 5
			multiplication.Commands.Add(new Command(5, 98)); // LDA
			multiplication.Commands.Add(new Command(9, 02)); // OUT
			multiplication.Commands.Add(new Command(0, 0)); // HLT
			multiplication.Commands.Add(new Command(0, 01)); // DAT

			// Create a script using Assemly language, making each command seperatly
			Script multiplication2 = new Script();
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("INP")));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("STA", 99)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("INP")));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("STA", 97)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("LDA", 98)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("ADD", 99)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("STA", 98)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("LDA", 97)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("SUB", 15)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("STA", 97)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("BRZ", 12)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("BRP", 4)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("LDA", 98)));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("OUT")));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("HLT")));
			multiplication2.Commands.Add(Assembler.Assembler.AssemblerCommandToCommand(new AssemblerCommand("DAT", 1)));

			// Create a script from a string containing Assembly lanugage (eg read from a file)
			string myText = @"INP
STA 99
INP
STA 97
LDA 98
ADD 99
STA 98
LDA 97
SUB 15
STA 97
BRZ 12
BRP 4
LDA 98
OUT
HLT
DAT 1";
			Script ScriptFromString = Assembler.Assembler.TextToScript(myText);

			// Load desired script into RAM
			myRam.LoadScriptIntoMemory(ScriptFromString);
			// Start the CPU FDE cycles
			myCPU.Execute(myRam);
		}
	}
}