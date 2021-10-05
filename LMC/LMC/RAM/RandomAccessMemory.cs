using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMC
{
	public class RandomAccessMemory
	{
		public List<int> Memory { get; set; }

		public RandomAccessMemory()
		{
			Memory = new List<int>(100);
			Memory.AddRange(Enumerable.Repeat(0, 100));
		}

		public void LoadScriptIntoMemory(Script script)
		{
			var count = 0;
			foreach(Command cmd in script.Commands)
			{
				//Console.WriteLine(cmd.Operand.ToString("00"));
				Memory[count] = int.Parse($"{cmd.Opcode}{cmd.Operand:00}");
			}
		}
	}
}
