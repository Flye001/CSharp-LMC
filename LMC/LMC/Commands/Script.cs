using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMC
{
	public class Script
	{
		public List<Command> Commands { get; set; }

		public Script()
		{
			Commands = new List<Command>();
		}
	}
}
