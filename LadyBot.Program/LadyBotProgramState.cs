using System;

namespace LadyBot.Program
{
	public class LadyBotProgramState
	{
		private int aCurrentIndex;

		public LadyBotProgramState()
		{
			this.aCurrentIndex = -1;
		}

		public bool IsCurrent(int commandIndex)
		{
			return this.aCurrentIndex == commandIndex;
		}

		public void SetCurrentIndex(int commandIndex)
		{
			this.aCurrentIndex = commandIndex;
			this.OnCurrentChanged?.Invoke();
		}

		public void Reset()
		{
			this.aCurrentIndex = -1;
			this.OnCurrentChanged?.Invoke();
		}

		public event Action OnCurrentChanged;
	}
}
