namespace LadyBot.Program
{
	public class LadyBotMap
	{
		public LadyBotMap()
		{
			this.Width = 10;
			this.Height = 10;

			this.InitialX = this.Width - 1;
			this.InitialY = this.Height - 1;

			this.InitialRotation = 0;

			this.KeyboardType = KeyboardType.Rotational;
		}

		public int Width { get; }
		public int Height { get; }

		public int InitialX { get; }
		public int InitialY { get; }

		public int InitialRotation { get; }

		public KeyboardType KeyboardType { get; }
	}
}
