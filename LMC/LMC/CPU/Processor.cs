namespace LMC
{
	public class Processor
	{
		public ControlUnit CU { get; private set; }
		public ArithmeticLogicUnit ALU { get; private set; }
		public Registers Registers { get; private set; }

		public Processor()
		{
			CU = new ControlUnit();
			ALU = new ArithmeticLogicUnit();
			Registers = new Registers();
		}

		public void Execute(RandomAccessMemory RAM)
		{
			CU.BeginFDE(this, RAM);
		}

		public string GetRegisters()
		{
			return $"PC: {Registers.PC}, MAR: {Registers.MAR}, MDR: {Registers.MDR}, ACC: {Registers.ACC}, CIR: {Registers.CIR}";
		}
	}
}
