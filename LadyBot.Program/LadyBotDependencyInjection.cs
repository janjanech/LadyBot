using Microsoft.Extensions.DependencyInjection;

namespace LadyBot.Program
{
	public static class LadyBotDependencyInjection
	{
		public static void AddLadyBot(this IServiceCollection services)
		{
			services.AddSingleton<LadyBotProgram>();
			services.AddSingleton<LadyBotProgramState>();
			services.AddSingleton<LadyBotMap>();
			services.AddSingleton<LadyBotController>();
		}
	}
}
