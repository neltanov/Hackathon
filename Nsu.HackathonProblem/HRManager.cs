using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem
{
    public class HrManager(ITeamBuildingStrategy teamBuildingStrategy)
    {
        public IEnumerable<Team> BuildTeams(List<Employee> teamLeads, List<Employee> juniors, List<Wishlist> teamLeadsWishlists,
            List<Wishlist> juniorsWishlists)
        {
            var teams = teamBuildingStrategy.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
            return teams;
        }
    }
}