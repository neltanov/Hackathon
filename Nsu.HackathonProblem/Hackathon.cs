using Nsu.HackathonProblem.TeamBuildingStrategy.Contracts;

namespace Nsu.HackathonProblem
{
    public static class Hackathon
    {
        public static double Start(List<Employee> teamLeads, List<Employee> juniors)
        {
            var teamLeadsWishlists = RandomGenerateWishlist(teamLeads, juniors);
            var juniorsWishlists = RandomGenerateWishlist(juniors, teamLeads);

            var hrManager = new HrManager();

            var teams = hrManager.TeamBuildingStrategy.BuildTeams(teamLeads, juniors, teamLeadsWishlists,
                juniorsWishlists);

            return HrDirector.CalculateHarmonicMean(teams, teamLeadsWishlists, juniorsWishlists);
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