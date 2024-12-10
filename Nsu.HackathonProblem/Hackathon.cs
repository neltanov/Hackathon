using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.TeamBuildingStrategy;

namespace Nsu.HackathonProblem
{
    public class Hackathon(List<Employee> teamLeads, List<Employee> juniors)
    {
        public double Start()
        {
            var teamLeadsWishlists = RandomGenerateWishlist(teamLeads, juniors);
            var juniorsWishlists = RandomGenerateWishlist(juniors, teamLeads);

            var hrManager = new HrManager(new StableMatchingsTeamBuildingStrategy());
            var teams = hrManager.BuildTeams(teamLeads, juniors, teamLeadsWishlists,
                juniorsWishlists);
            
            return HrDirector.CalculateHarmonicMean(teams.ToList(), teamLeadsWishlists, juniorsWishlists);
        }

        private static List<Wishlist> RandomGenerateWishlist(List<Employee> group, List<Employee> desiredGroup)
        {
            var random = new Random();
            var wishlists = new List<Wishlist>();

            foreach (var employee in group)
            {
                var desiredEmployees = desiredGroup
                    .OrderBy(e => random.Next())
                    .Select(e => e.Id)
                    .ToArray();

                wishlists.Add(new Wishlist(employee.Id, desiredEmployees));
            }

            return wishlists;
        }
    }
}