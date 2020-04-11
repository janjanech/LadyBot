using System;
using System.Collections;
using System.Collections.Generic;

namespace LadyBot.Program
{
	public class LadyBotProgram : IEnumerable<LadyBotCommand>
	{
		private readonly List<LadyBotCommand> aCommands;

		public LadyBotProgram()
		{
			this.aCommands = new List<LadyBotCommand>();
		}

		public void AddCommand(LadyBotCommand ladyBotCommand)
		{
			this.aCommands.Add(ladyBotCommand);
		}

		public IEnumerator<LadyBotCommand> GetEnumerator()
		{
			return this.aCommands.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
