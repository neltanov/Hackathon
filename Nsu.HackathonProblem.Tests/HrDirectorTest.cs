using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem.Tests;

public class HrDirectorTest
{
    [Test]
    public void SameNumbersTest()
    {
        const int someNumber = 10;
        var harmony = HarmonicMeanCalculator.HarmonicMean([someNumber, someNumber, someNumber, someNumber]);
        Assert.That(harmony, Is.EqualTo(someNumber));
    }

    [Test]
    public void ConcreteExampleTest()
    {
        var harmony = HarmonicMeanCalculator.HarmonicMean([2, 6]);
        Assert.That(harmony, Is.EqualTo(3));
    }

    [Test]
    public void HarmonicMeanOfTeamsTest()
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
        var teams = new List<Team>
        {
            new(teamLeads[0], juniors[0]),
            new(teamLeads[1], juniors[1]),
            new(teamLeads[2], juniors[2])
        };
        var harmony = HrDirector.CalculateHarmonicMean(teams, teamLeadsWishlists, juniorsWishlists);
        const float expectedHarmony = 1.6364f;
        Assert.That(Math.Round(harmony, 4), Is.EqualTo(Math.Round(expectedHarmony, 4)));
    }
}