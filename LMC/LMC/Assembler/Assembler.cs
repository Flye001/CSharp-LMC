using System;
using System.IO;

namespace LMC.Assembler
{
	public class Assembler
	{
		public static Script TextToScript(string rawCode)
		{
			Script returnScript = new Script();
			foreach (string linebase in rawCode.Split('\n'))
			{
				string line = linebase.Trim();
				AssemblerCommand currentCMD = new AssemblerCommand();
				//Console.WriteLine($"-{line}-");
				if (line.Contains(" "))
				{
					string[] split = line.Split(" ");
					currentCMD.Mnemonic = split[0];
					currentCMD.Operand = int.Parse(split[1]);
				}
				else currentCMD.Mnemonic = line;
				Command convertedCMD = AssemblerCommandToCommand(currentCMD);
				returnScript.Commands.Add(convertedCMD);
			} 
			return returnScript;
		}
		public static Command AssemblerCommandToCommand(AssemblerCommand cmd)
		{
			Command ReturnCommand = new Command();

			switch(cmd.Mnemonic)
			{
				case "HLT":
					ReturnCommand.Opcode = 0;
					break;
				case "ADD":
					ReturnCommand.Opcode = 1;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "SUB":
					ReturnCommand.Opcode = 2;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "STA":
					ReturnCommand.Opcode = 3;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "LDA":
					ReturnCommand.Opcode = 5;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "BRA":
					ReturnCommand.Opcode = 6;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "BRZ":
					ReturnCommand.Opcode = 7;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "BRP":
					ReturnCommand.Opcode = 8;
					ReturnCommand.Operand = cmd.Operand;
					break;
				case "INP":
					ReturnCommand.Opcode = 9;
					ReturnCommand.Operand = 1;
					break;
				case "OUT":
					ReturnCommand.Opcode = 9;
					ReturnCommand.Operand = 2;
					break;
				case "DAT":
					ReturnCommand.Opcode = 0;
					ReturnCommand.Operand = cmd.Operand;
					break;
				default:
					//Console.WriteLine($"Invalid Command: -{cmd.Mnemonic}-");
					throw new Exception("Invalid Command");
			}

			return ReturnCommand;
		}
	}
}
