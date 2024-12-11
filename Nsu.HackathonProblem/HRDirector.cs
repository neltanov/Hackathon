using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem
{

    public static class HrDirector
    {
        private static List<int> SatisfactionIndexCalculation(List<Team> teams,
            List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists)
        {
            var juniorPreferences = juniorsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);
            var teamLeadPreferences = teamLeadsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);

            var satisfactionIndex = new List<int>();
            foreach (var team in teams)
            {
                var teamLeadIndex = Array.IndexOf(juniorPreferences[team.Junior.Id], team.TeamLead.Id);
                satisfactionIndex.Add(juniorPreferences.Count - teamLeadIndex);
                var juniorIndex = Array.IndexOf(teamLeadPreferences[team.TeamLead.Id], team.Junior.Id);
                satisfactionIndex.Add(teamLeadPreferences.Count - juniorIndex);
            }

            return satisfactionIndex;
        }

        public static double CalculateHarmonicMean(List<Team> teams,
            List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists)
        {
            var satisfactionIndices = SatisfactionIndexCalculation(teams,
                teamLeadsWishlists, juniorsWishlists);
            return HarmonicMeanCalculator.HarmonicMean(satisfactionIndices);
        }

    }
}