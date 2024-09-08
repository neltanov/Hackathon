using System.Runtime.InteropServices.Marshalling;
namespace HackathonApp;

public class HRManager
{
    public TeamBuildingStrategy TeamBuildingStrategy { get; set; }
    public HRManager(string strategyName)
    {
        // define team building strategy
    }

    public DreamTeamList FormTeams(List<TeamLead> juniorPreferences, List<Junior> teamLeadPreferences)
    {
        DreamTeamList dreamTeamList = null;
        // form dream team list
        return dreamTeamList;
    }
}

public class DreamTeamList
{
    public List<Tuple<Junior, TeamLead>> dreamTeamList { get; set; }
}

public class TeamBuildingStrategy
{
    
}