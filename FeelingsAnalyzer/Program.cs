using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
	static void Main()
	{
		// Setup DI container
		var serviceProvider = new ServiceCollection()
			.AddTransient<SentimentAnalyzerService>()
			.AddTransient<FeelingService>()
			.BuildServiceProvider();

		// Main program loop
		while (true)
		{
			// Resolve services from the DI container
			var feelingService = serviceProvider.GetRequiredService<FeelingService>();

			// Prompt user
			Console.Write("How are you feeling? ");
			string userResponse = Console.ReadLine() ?? string.Empty;

			// Process user input using the feeling service
			string response = feelingService.ProcessFeeling(userResponse);

			// Display the processed response
			Console.WriteLine(response);
		}
	}
}