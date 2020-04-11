using System;
using System.Collections;
using System.Collections.Generic;

namespace LadyBot.Program
{
	public class Program : IEnumerable<Command>
	{
		private readonly List<Command> aCommands;

		public Program()
		{
			this.aCommands = new List<Command>();
		}

		public void AddCommand(Command command)
		{
			this.aCommands.Add(command);
		}

		public IEnumerator<Command> GetEnumerator()
		{
			return this.aCommands.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
