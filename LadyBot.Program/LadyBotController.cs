using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBot.Program
{
	public class LadyBotController
	{
		private readonly LadyBotProgramState aProgramState;
		private readonly LadyBotProgram aProgram;
		private ILadyBotCharacter aCharacter;

		public LadyBotController(LadyBotProgramState programState, LadyBotProgram program)
		{
			this.aProgramState = programState;
			this.aProgram = program;
		}

		public void AssignCharacter(ILadyBotCharacter character)
		{
			this.aCharacter = character;
		}

		public async Task RunProgramAsync()
		{
			this.aCharacter.Reset();

			try
			{
				foreach (var (idx, command) in this.aProgram.Select((x, idx) => (idx, x)))
				{
					this.aProgramState.SetCurrentIndex(idx);

					switch (command)
					{
						case LadyBotCommand.MoveForward:
							await this.aCharacter.MoveForward();
							break;
						case LadyBotCommand.RotateLeft:
							await this.aCharacter.RotateLeft();
							break;
						case LadyBotCommand.RotateRight:
							await this.aCharacter.RotateRight();
							break;
						case LadyBotCommand.MoveLeft:
							await this.aCharacter.Rotate(Rotation.Left);
							await this.aCharacter.MoveForward();
							break;
						case LadyBotCommand.MoveRight:
							await this.aCharacter.Rotate(Rotation.Right);
							await this.aCharacter.MoveForward();
							break;
						case LadyBotCommand.MoveUp:
							await this.aCharacter.Rotate(Rotation.Up);
							await this.aCharacter.MoveForward();
							break;
						case LadyBotCommand.MoveDown:
							await this.aCharacter.Rotate(Rotation.Down);
							await this.aCharacter.MoveForward();
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}
			catch (BumpedException)
			{
			}

			this.aProgramState.Reset();
		}
	}
}
