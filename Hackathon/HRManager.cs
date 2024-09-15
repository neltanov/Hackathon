namespace Nsu.HackathonProblem;

public class HrManager
{
    public HrManager()
    {
        var teamBuildingStrategy = new TeamBuildingStrategy();
        TeamBuildingStrategy = teamBuildingStrategy;
    }

    public TeamBuildingStrategy TeamBuildingStrategy { get; }
}