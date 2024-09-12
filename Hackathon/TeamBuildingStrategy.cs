using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem;

public class TeamBuildingStrategy : ITeamBuildingStrategy
{
    public IEnumerable<Team> BuildTeams(IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors, IEnumerable<Wishlist> teamLeadsWishlists,
        IEnumerable<Wishlist> juniorsWishlists)
    {
        var teamLeadById = teamLeads.ToDictionary(e => e.Id);
        var juniorById = juniors.ToDictionary(e => e.Id);

        // Преобразуем списки предпочтений в словари для быстрого доступа
        var teamLeadPreferences = teamLeadsWishlists.ToDictionary(w => w.EmployeeId, w => new Queue<int>(w.DesiredEmployees));
        var juniorPreferences = juniorsWishlists.ToDictionary(w => w.EmployeeId, w => w.DesiredEmployees);

        // Храним текущие "помолвки" джуниоров (джуниор -> тимлид)
        var currentEngagements = new Dictionary<int, int>();

        // Храним, к каким джуниорам тимлиды уже сделали предложения
        var proposals = new Dictionary<int, HashSet<int>>();
        foreach (var lead in teamLeads)
        {
            proposals[lead.Id] = new HashSet<int>();
        }

        // Тимлиды, которые еще не нашли команду
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
                continue; // Тимлид уже делал предложение этому джуниору
            }

            proposals[leadId].Add(juniorId);

            if (!currentEngagements.ContainsKey(juniorId))
            {
                // Джуниор пока не в команде — заключаем "помолвку"
                currentEngagements[juniorId] = leadId;
            }
            else
            {
                // Джуниор уже в команде — сравним текущего тимлида с новым кандидатом
                var currentLeadId = currentEngagements[juniorId];
                var juniorPreferenceList = juniorPreferences[juniorId];

                // Джуниор предпочитает нового тимлида, если он стоит выше в его списке предпочтений
                if (Array.IndexOf(juniorPreferenceList, leadId) < Array.IndexOf(juniorPreferenceList, currentLeadId))
                {
                    // Джуниор выбирает нового тимлида — текущий тимлид снова становится "свободным"
                    currentEngagements[juniorId] = leadId;
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
        return currentEngagements.Select(pair => new Team(teamLeadById[pair.Value], juniorById[pair.Key])).ToList();

    }
}