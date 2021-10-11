namespace LMC
{
	public class Command
	{
		public int Operand;
		public int Opcode;

		public Command() { }
		public Command(int opcode, int operand)
		{
			Operand = operand;
			Opcode = opcode;
		}
		public override string ToString()
		{
			return $"{Opcode}{Operand:00}";
		}
	}
}
