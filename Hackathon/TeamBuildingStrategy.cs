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
        };
        foreach (var teamLead in teamLeads)
        {
            Console.WriteLine($"Team Lead: {teamLead}");
        }

        foreach (var junior in juniors)
        {
            Console.WriteLine($"Junior: {junior}");
        }
        return teams;
    }
}