using Microsoft.Extensions.Hosting;

namespace FeelingsAnalyzer2.Services;

public class FeelingServiceRunner : BackgroundService
{
	private readonly FeelingService _feelingService;

	public FeelingServiceRunner(FeelingService feelingService)
	{
		_feelingService = feelingService;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			Console.Write("How are you feeling? ");
			string userResponse = Console.ReadLine() ?? String.Empty;

			string response = _feelingService.ProcessFeeling(userResponse);

			Console.WriteLine(response);

			await Task.Delay(500, stoppingToken); // Delay for 500 milliseconds before asking again
		}
	}
}