using System.Threading;
using System.Threading.Tasks;

namespace LadyBot.Program
{
	public interface ILadyBotCharacter
	{
		void Reset();
		Task MoveForward(CancellationToken ct);
		Task RotateLeft(CancellationToken ct);
		Task RotateRight(CancellationToken ct);
		Task Rotate(int degrees, CancellationToken ct);
	}
}