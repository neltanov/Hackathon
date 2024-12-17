using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nsu.HackathonProblem;

public class HackathonWorker(IServiceProvider serviceProvider) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("HackathonWorker started.");
        var sumOfHarmonicMean = 0d;
        for (var i = 0; i < 1000; i++)
        {
            var hackathon = serviceProvider.GetRequiredService<Hackathon>();
            sumOfHarmonicMean += hackathon.Start();
        }

        Console.WriteLine($"Average harmony of hackathons: {double.Round(sumOfHarmonicMean / 1000, 3)}");
        return Task.CompletedTask;
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("HackathonWorker stopped.");
        return Task.CompletedTask;
    }
}