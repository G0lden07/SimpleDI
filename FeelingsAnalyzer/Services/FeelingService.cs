public class FeelingService
{
	private readonly SentimentAnalyzerService _analyzerService;

	// Constructor injection
	public FeelingService(SentimentAnalyzerService analyzerService)
	{
		_analyzerService = analyzerService;
	}

	public string ProcessFeeling(string input)
	{
		// Use the sentiment analyzer service
		string sentiment = _analyzerService.Analyze(input);

		// Return the analyzed sentiment
		return $"You sound {sentiment}";
	}
}