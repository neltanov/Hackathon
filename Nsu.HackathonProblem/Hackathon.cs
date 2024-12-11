using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.TeamBuildingStrategy;

namespace Nsu.HackathonProblem
{
    public class Hackathon(List<Employee> teamLeads, List<Employee> juniors, List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists)
    {
        public double Start()
        {
            var hrManager = new HrManager(new StableMatchingsTeamBuildingStrategy());
            var teams = hrManager.BuildTeams(teamLeads, juniors, teamLeadsWishlists,
                juniorsWishlists);
            
            return HrDirector.CalculateHarmonicMean(teams.ToList(), teamLeadsWishlists, juniorsWishlists);
        }
    }
}