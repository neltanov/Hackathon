using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem.Tests;

public class WishlistTests
{
    [Test]
    public void WishlistSizeTest()
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
        var teamLeadsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(teamLeads, juniors);
        var juniorsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(juniors, teamLeads);
        Assert.That(teamLeadsWishlists.Count, Is.EqualTo(juniors.Count));
        Assert.That(juniorsWishlists.Count, Is.EqualTo(teamLeads.Count));
    }

    [Test]
    public void WishlistEmployeeTest()
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
        var teamLeadsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(teamLeads, juniors);
        var juniorsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(juniors, teamLeads);
        for (var i = 0; i < teamLeads.Count; i++)
        {
            for (var j = 0; j < teamLeads.Count; j++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(teamLeadsWishlists[j].DesiredEmployees.ToList(), Does.Contain(juniors[i].Id));
                    Assert.That(juniorsWishlists[j].DesiredEmployees.ToList(), Does.Contain(teamLeads[i].Id));
                });
            }
        }
    }
}