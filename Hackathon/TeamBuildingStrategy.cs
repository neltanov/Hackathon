using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem;

public class TeamBuildingStrategy : ITeamBuildingStrategy
{
    public IEnumerable<Team> BuildTeams(IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors, 
        IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
    {
        var teamLeadById = teamLeads.ToDictionary(e => e.Id);
        var juniorById = juniors.ToDictionary(e => e.Id);

        var teamLeadPreferences = teamLeadsWishlists.ToDictionary(w => w.EmployeeId, w => new Queue<int>(w.DesiredEmployees));
        var juniorPreferences = juniorsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);

        var currentOffers = new Dictionary<int, int>();

        var proposals = new Dictionary<int, HashSet<int>>();
        foreach (var lead in teamLeads)
        {
            proposals[lead.Id] = new HashSet<int>();
        }

        var freeTeamLeads = new Queue<int>(teamLeads.Select(e => e.Id));

        while (freeTeamLeads.Count > 0)
        {
            var leadId = freeTeamLeads.Dequeue();
            if (!teamLeadPreferences.TryGetValue(leadId, out var preferences) || preferences.Count == 0)
            {
                continue;
            }

            var juniorId = preferences.Dequeue();
            if (proposals[leadId].Contains(juniorId))
            {
                continue;
            }

            proposals[leadId].Add(juniorId);

            if (!currentOffers.ContainsKey(juniorId))
            {
                currentOffers[juniorId] = leadId;
            }
            else
            {
                var currentLeadId = currentOffers[juniorId];
                var juniorPreferenceList = juniorPreferences[juniorId];

                if (Array.IndexOf(juniorPreferenceList, leadId) < Array.IndexOf(juniorPreferenceList, currentLeadId))
                {
                    currentOffers[juniorId] = leadId;
                    freeTeamLeads.Enqueue(currentLeadId);
                }
                else
                {
                    freeTeamLeads.Enqueue(leadId);
                }
            }
        }

        // Формируем окончательные команды
        return currentOffers.Select(pair => new Team(teamLeadById[pair.Value], juniorById[pair.Key])).ToList();

    }
}