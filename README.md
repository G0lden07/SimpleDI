# Dependency Injection

## Essential Question 
How can using Dependency Injection (DI) in computer programming today help us handle bigger and more complex projects tomorrow, and what skills does it teach us for working on large software projects in the future?

## Introduction

Imagine you are a student in a classroom, and you need different tools for various subjects like math, science, and art. Without Dependency Injection, you'd have to carry all your supplies with you all the time, even if you're not using them. It's like carrying your math book, science kit, and art supplies, no matter what lesson is happening.

Now, think of Dependency Injection as having a helpful friend who knows exactly what tools you need for each class. Instead of lugging around everything, your friend hands you the specific tools you need when the teacher says it's time for math, science, or art. This way, you only have what you need when you need it. In programming, Dependency Injection works similarly – it brings in only the necessary tools or dependencies when a specific part of the code requires them, making the code more organized and efficient.

## Simple Example

```csharp

using Microsoft.Extensions.DependencyInjection;
using System;

// Sentiment analyzer service
public class SentimentAnalyzerService
{
    public string Analyze(string input)
    {
        // Simplicity: always return "happy"
        return "happy";
    }
}

// Feeling service with dependency on SentimentAnalyzerService
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
            string userResponse = Console.ReadLine();

            // Process user input using the feeling service
            string response = feelingService.ProcessFeeling(userResponse);

            // Display the processed response
            Console.WriteLine(response);
        }
    }
}

```
