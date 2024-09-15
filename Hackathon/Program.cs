using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem;

static class Program
{
    static void Main(string[] args)
    {
        var harmonicMean = 0d;
        try
        {
            var teamLeads = CsvParser.ParseCsv(args[0]);
            var juniors = CsvParser.ParseCsv(args[1]);
            var rounds = int.Parse(args[2]);
            for (int i = 0; i < rounds; i++)
            {
                harmonicMean += Hackathon.Start(teamLeads, juniors);
            }
            Console.WriteLine($"Average harmony of hackatons: {double.Round(harmonicMean / 1000, 3)}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}