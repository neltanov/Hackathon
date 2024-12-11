using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem.Tests;

public class HackathonTests
{
    [Test]
    public void HarmonicMeanTest()
    {
        var teamLeads = new List<Employee>
        {
            new(101, "John"),
            new(202, "Jane"),
            new(303, "Doe")
        };
        var juniors = new List<Employee>
        {
            new(111, "John"),
            new(222, "Jane"),
            new(333, "Doe")
        };
        var teamLeadsWishlists = new List<Wishlist>
        {
            new(101, [111, 222, 333]),
            new(202, [111, 222, 333]),
            new(303, [111, 222, 333]),
        };
        var juniorsWishlists = new List<Wishlist>
        {
            new(111, [101, 202, 303]),
            new(222, [101, 202, 303]),
            new(333, [101, 202, 303]),
        };
        var hackathon = new Hackathon(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
        var harmony = hackathon.Start();
        const float expectedHarmony = 1.6364f;
        Assert.That(Math.Round(harmony, 4), Is.EqualTo(Math.Round(expectedHarmony, 4)));
    }
}