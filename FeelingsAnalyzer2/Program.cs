using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using FeelingsAnalyzer2.Services;

class Program
{
	static async Task Main()
	{
		var host = Host.CreateDefaultBuilder()
			.ConfigureAppConfiguration((hostContext, configBuilder) =>
			{
				configBuilder.AddUserSecrets(Assembly.GetExecutingAssembly())
							 .AddEnvironmentVariables();
			})
			.ConfigureServices((hostContext, services) =>
			{
				// Setup DI container
				services.AddTransient<SentimentAnalyzerService>();
				services.AddTransient<FeelingService>();
				services.AddHostedService<FeelingServiceRunner>();
			})
			.Build();

		using var serviceScope = host.Services.CreateScope();

		await host.RunAsync();


	}
}
