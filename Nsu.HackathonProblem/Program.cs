using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem;

static class Program
{
    static void Main(string[] args)
    {
        var sumOfHarmonicMean = 0d;
        try
        {
            var teamLeads = CsvParser.ParseCsv(args[0]);
            var juniors = CsvParser.ParseCsv(args[1]);
            var rounds = int.Parse(args[2]);
            for (int i = 0; i < rounds; i++)
            {
                var teamLeadsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(teamLeads, juniors);
                var juniorsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(juniors, teamLeads);
                var hackathon = new Hackathon(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
                sumOfHarmonicMean += hackathon.Start();
            }

            Console.WriteLine($"Average harmony of hackathons: {double.Round(sumOfHarmonicMean / rounds, 3)}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}