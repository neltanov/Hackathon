using System.Runtime.InteropServices.Marshalling;
namespace Nsu.HackathonProblem;

public class HRManager
{
    public HRManager()
    {
        TeamBuildingStrategy teamBuildingStrategy = new TeamBuildingStrategy();
        TeamBuildingStrategy = teamBuildingStrategy;

    }

    public TeamBuildingStrategy TeamBuildingStrategy { get; set; }
}