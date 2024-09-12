using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem;

public class TeamBuildingStrategy : ITeamBuildingStrategy
{
    public IEnumerable<Team> BuildTeams(IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors, IEnumerable<Wishlist> teamLeadsWishlists,
        IEnumerable<Wishlist> juniorsWishlists)
    {
        var teamLeadById = teamLeads.ToDictionary(e => e.Id);
        var juniorById = juniors.ToDictionary(e => e.Id);

        var teamLeadPreferences = teamLeadsWishlists.ToDictionary(w => w.EmployeeId, w => new Queue<int>(w.DesiredEmployees));
        var juniorPreferences = juniorsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);

        // Храним текущие офферы джуниоров (джуниор -> тимлид)
        var currentOffers = new Dictionary<int, int>();

        // Храним, к каким джуниорам тимлиды уже дали оффер
        var proposals = new Dictionary<int, HashSet<int>>();
        foreach (var lead in teamLeads)
        {
            proposals[lead.Id] = new HashSet<int>();
        }

        // Тимлиды, которые еще не нашли джуна
        var freeTeamLeads = new Queue<int>(teamLeads.Select(e => e.Id));

        while (freeTeamLeads.Count > 0)
        {
            var leadId = freeTeamLeads.Dequeue();
            if (!teamLeadPreferences.TryGetValue(leadId, out var preferences) || preferences.Count == 0)
            {
                continue; // Если у тимлида закончились кандидаты, он остается без команды
            }

            var juniorId = preferences.Dequeue();
            if (proposals[leadId].Contains(juniorId))
            {
                continue; // Тимлид уже дал оффер этому джуниору
            }

            proposals[leadId].Add(juniorId);

            if (!currentOffers.ContainsKey(juniorId))
            {
                // Джуниор пока не в команде — даем оффер
                currentOffers[juniorId] = leadId;
            }
            else
            {
                // Джуниор уже в команде — сравним текущего тимлида с новым кандидатом
                var currentLeadId = currentOffers[juniorId];
                var juniorPreferenceList = juniorPreferences[juniorId];

                // Джуниор предпочитает нового тимлида, если он стоит выше в его списке предпочтений
                if (Array.IndexOf(juniorPreferenceList, leadId) < Array.IndexOf(juniorPreferenceList, currentLeadId))
                {
                    // Джуниор выбирает нового тимлида — текущий тимлид снова становится "свободным"
                    currentOffers[juniorId] = leadId;
                    freeTeamLeads.Enqueue(currentLeadId);
                }
                else
                {
                    // Джуниор оставляет текущего тимлида, новый тимлид остается свободным
                    freeTeamLeads.Enqueue(leadId);
                }
            }
        }

        // Формируем окончательные команды
        return currentOffers.Select(pair => new Team(teamLeadById[pair.Value], juniorById[pair.Key])).ToList();

    }
}