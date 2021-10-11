using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMC
{
	public class ControlUnit
	{
		private Processor CPU { get; set; }
		private RandomAccessMemory RAM { get; set; }
		public void BeginFDE(Processor cpu, RandomAccessMemory ram)
		{
			CPU = cpu;
			RAM = ram;
			Console.WriteLine("Beginning FDE Cycle...");
			Console.WriteLine(CPU.GetRegisters());
			int count = 1;
			bool stop = false;
			while (!stop)
			{
				Console.WriteLine($"\nCycle {count}:");
				Fetch();
				Console.WriteLine(CPU.GetRegisters());
				stop = Decode();
				Console.WriteLine(CPU.GetRegisters());
				if (stop) break;
				stop = Execute();
				Console.WriteLine(CPU.GetRegisters());
				count++;
				//Console.ReadKey();
				//Console.Clear();
			}
			
		}

		private void Fetch()
		{
			Console.WriteLine($"\nFetching instruction from memory location {CPU.Registers.PC}");
			CPU.Registers.MAR = CPU.Registers.PC;
			CPU.Registers.MDR = RAM.Memory[CPU.Registers.MAR];
			CPU.Registers.PC++;
			return;
		}

		private bool Decode()
		{
			Console.WriteLine($"\nDecoding {CPU.Registers.MDR}..");
			string command = CPU.Registers.MDR.ToString();
			int opcode = int.Parse(command[0].ToString());
			int operand = 0;
			try
			{
				operand = int.Parse(command[1].ToString() + command[2].ToString());
				//Console.WriteLine(operand);
			}
			catch { }

			if (opcode >= 0 && opcode <= 9 && opcode != 4)
			{
				Console.WriteLine("Command is valid.");
				CPU.Registers.CIR = opcode;
				CPU.Registers.MAR = operand;
				return false;
			}

			else
			{
				Console.WriteLine("Command is not valid.");
				return true;
			}		
			
		}

		private bool Execute()
		{
			Console.WriteLine($"\nExecuting opcode '{CPU.Registers.CIR}' with operand '{CPU.Registers.MAR:00}'");
			Console.Write("Command: ");
			switch (CPU.Registers.CIR)
			{
				case 0:
					Console.WriteLine("End");
					return true;
				case 1:
					Console.WriteLine("Add");
					CPU.Registers.ACC += RAM.Memory[CPU.Registers.MAR];
					return false;
				case 2:
					Console.WriteLine("Subtract");
					CPU.Registers.ACC -= RAM.Memory[CPU.Registers.MAR];
					return false;
				case 3:
					Console.WriteLine("Store");
					RAM.Memory[CPU.Registers.MAR] = CPU.Registers.ACC;
					return false;
				case 5:
					Console.WriteLine("Load");
					CPU.Registers.ACC = RAM.Memory[CPU.Registers.MAR];
					return false;
				case 6:
					Console.WriteLine("Branch Always");
					CPU.Registers.PC = CPU.Registers.MAR;
					return false;
				case 7:
					Console.WriteLine("Branch if zero");
					if (CPU.Registers.ACC == 0) CPU.Registers.PC = CPU.Registers.MAR;
					return false;
				case 8:
					Console.WriteLine("Branch if zero or positive");
					if (CPU.Registers.ACC >= 0) CPU.Registers.PC = CPU.Registers.MAR;
					return false;
				case 9:
					if (CPU.Registers.MAR == 1)
					{
						Console.WriteLine("Input");
						Console.Write("Please Enter Input: ");
						CPU.Registers.ACC = int.Parse(Console.ReadLine());
						return false;
					}
					else if (CPU.Registers.MAR == 2)
					{
						Console.WriteLine("Output");
						Console.WriteLine($"Output: {CPU.Registers.ACC}");
						return false;
					}
					else return true;
				default:
					Console.WriteLine("No matching command!");
					return true;
			}
			return true;
		}
	}
}
