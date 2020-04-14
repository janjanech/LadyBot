using System.Threading.Tasks;

namespace LadyBot.Program
{
	public interface ILadyBotCharacter
	{
		void Reset();
		Task MoveForward();
		Task RotateLeft();
		Task RotateRight();
		Task Rotate(int degrees);
	}
}