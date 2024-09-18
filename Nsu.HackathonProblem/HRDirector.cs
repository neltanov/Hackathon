using Nsu.HackathonProblem.TeamBuildingStrategy.Contracts;

namespace Nsu.HackathonProblem
{

    public static class HrDirector
    {
        private static IEnumerable<int> SatisfactionIndexCalculation(IEnumerable<Team> teams,
            IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
        {
            var juniorPreferences = juniorsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);
            var teamLeadPreferences = teamLeadsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);

            var teamList = teams.ToList();
            var satisfactionIndex = new List<int>();
            foreach (var team in teamList)
            {
                var teamLeadIndex = Array.IndexOf(juniorPreferences[team.Junior.Id], team.TeamLead.Id);
                satisfactionIndex.Add(juniorPreferences.Count - teamLeadIndex);
                var juniorIndex = Array.IndexOf(teamLeadPreferences[team.TeamLead.Id], team.Junior.Id);
                satisfactionIndex.Add(teamLeadPreferences.Count - juniorIndex);
            }

            return satisfactionIndex;
        }

        private static double HarmonicMean(IEnumerable<int> numbers)
        {
            var numberArray = numbers.ToArray();
            return numberArray.Length / numberArray.Sum(n => 1.0 / n);
        }

        public static double CalculateHarmonicMean(IEnumerable<Team> teams,
            IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
        {
            var satisfactionIndices = SatisfactionIndexCalculation(teams,
                teamLeadsWishlists, juniorsWishlists);
            return HarmonicMean(satisfactionIndices);
        }

    }
}