using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem.Tests;

public class HackathonTests
{
    [Test]
    public void HarmonicMeanTest()
    {
        var teamLeads = new List<Employee>
        {
            new Employee(101, "John"),
            new Employee(202, "Jane"),
            new Employee(303, "Doe")
        };
        var juniors = new List<Employee>
        {
            new Employee(111, "John"),
            new Employee(222, "Jane"),
            new Employee(333, "Doe")
        };
        var teamLeadsWishlists = new List<Wishlist>
        {
            new Wishlist(101, [111, 222, 333]),
            new Wishlist(202, [111, 222, 333]),
            new Wishlist(303, [111, 222, 333]),
        };
        var juniorsWishlists = new List<Wishlist>
        {
            new Wishlist(111, [101, 202, 303]),
            new Wishlist(222, [101, 202, 303]),
            new Wishlist(333, [101, 202, 303]),
        };
        var hackathon = new Hackathon(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
        var harmony = hackathon.Start();
        const float expectedHarmony = 1.6364f;
        Assert.That(Math.Round(harmony, 4), Is.EqualTo(Math.Round(expectedHarmony, 4)));
    }
}