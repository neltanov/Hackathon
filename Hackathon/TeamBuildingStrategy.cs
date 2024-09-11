using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem;

public class TeamBuildingStrategy : ITeamBuildingStrategy
{
    public IEnumerable<Team> BuildTeams(IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors, IEnumerable<Wishlist> teamLeadsWishlists,
        IEnumerable<Wishlist> juniorsWishlists)
    {
        var teams = new List<Team>
        {
            new Team(new Employee(1, "John"), new Employee(2, "Jane")),
            new Team(new Employee(3, "Joshua"), new Employee(5, "Alex"))
        };
        return teams;
    }
}