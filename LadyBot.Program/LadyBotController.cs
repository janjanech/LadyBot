using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LadyBot.Program
{
	public class LadyBotController
	{
		private readonly LadyBotProgramState aProgramState;
		private readonly LadyBotProgram aProgram;
		private ILadyBotCharacter aCharacter;
		private CancellationTokenSource aCancellation;

		public LadyBotController(LadyBotProgramState programState, LadyBotProgram program)
		{
			this.aProgramState = programState;
			this.aProgram = program;
			this.aCancellation = null;
		}

		public void AssignCharacter(ILadyBotCharacter character)
		{
			this.aCharacter = character;
		}

		public void StopProgram()
		{
			this.aCancellation?.Cancel();
		}

		public async Task RunProgramAsync()
		{
			this.aCancellation = new CancellationTokenSource();

			var ct = this.aCancellation.Token;

			this.aCharacter.Reset();

			try
			{
				foreach (var (idx, command) in this.aProgram.Select((x, idx) => (idx, x)))
				{
					ct.ThrowIfCancellationRequested();
					this.aProgramState.SetCurrentIndex(idx);

					switch (command)
					{
						case LadyBotCommand.MoveForward:
							await this.aCharacter.MoveForward(ct);
							break;
						case LadyBotCommand.RotateLeft:
							await this.aCharacter.RotateLeft(ct);
							break;
						case LadyBotCommand.RotateRight:
							await this.aCharacter.RotateRight(ct);
							break;
						case LadyBotCommand.MoveLeft:
							await this.aCharacter.Rotate(Rotation.Left, ct);
							await this.aCharacter.MoveForward(ct);
							break;
						case LadyBotCommand.MoveRight:
							await this.aCharacter.Rotate(Rotation.Right, ct);
							await this.aCharacter.MoveForward(ct);
							break;
						case LadyBotCommand.MoveUp:
							await this.aCharacter.Rotate(Rotation.Up, ct);
							await this.aCharacter.MoveForward(ct);
							break;
						case LadyBotCommand.MoveDown:
							await this.aCharacter.Rotate(Rotation.Down, ct);
							await this.aCharacter.MoveForward(ct);
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}
			catch (BumpedException)
			{
			}
			catch (TaskCanceledException)
			{
				this.aCharacter.Reset();
			}

			this.aProgramState.Reset();
			this.aCancellation = null;
		}
	}
}
