using Moq;
using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.TeamBuildingStrategy;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem.Tests;

public class HrManagerTest
{
    [Test]
    public void TeamsCountTest()
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
        var hrManager = new HrManager(new StableMatchingsTeamBuildingStrategy());
        var teams = hrManager.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists).ToList();
        Assert.That(teams, Has.Count.EqualTo(teamLeads.Count));
    }
    
    [Test]
    public void StrategyCalledOnceTest()
    {
        var teamLeads = new List<Employee>
        {
            new Employee(101, "John"),
            new Employee(202, "Jane"),
            new Employee(303, "Doe")
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
        
        var mockService = new Mock<ITeamBuildingStrategy>();
        var hrManager = new HrManager(mockService.Object);

        hrManager.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
        
        mockService.Verify(s => s.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists), 
            Times.Once);
    }
    
    [Test]
    public void CorrectDistributionTest()
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
        var hrManager = new HrManager(new StableMatchingsTeamBuildingStrategy());
        var teams = hrManager.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists).ToList();
        var expectedTeams = new List<Team>
        {
            new(teamLeads[0], juniors[0]),
            new(teamLeads[1], juniors[1]),
            new(teamLeads[2], juniors[2])
        };
        Assert.That(teams, Is.EqualTo(expectedTeams));
    }
}