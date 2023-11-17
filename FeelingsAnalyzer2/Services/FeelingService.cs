namespace FeelingsAnalyzer2.Services;

public class FeelingService
{
	private readonly SentimentAnalyzerService _analyzerService;

	public FeelingService(SentimentAnalyzerService analyzerService)
	{
		_analyzerService = analyzerService;
	}

	public string ProcessFeeling(string input)
	{
		string sentiment = _analyzerService.Analyze(input);
		return $"You sound {sentiment}";
	}
}