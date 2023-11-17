using Microsoft.Extensions.Configuration;

namespace FeelingsAnalyzer2.Services;

public class SentimentAnalyzerService
{
	private readonly IConfiguration _configuration;

	public SentimentAnalyzerService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string Analyze(string input)
	{
		// Simplicity: always return "happy"
		return "happy";
	}
}