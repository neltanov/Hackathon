using Nsu.HackathonProblem.TeamBuildingStrategy;

namespace Nsu.HackathonProblem
{
    public class HrManager
    {
        public HrManager()
        {
            var teamBuildingStrategy = new TeamBuildingStrategy.TeamBuildingStrategy();
            TeamBuildingStrategy = teamBuildingStrategy;
        }

        public TeamBuildingStrategy.TeamBuildingStrategy TeamBuildingStrategy { get; }
    }
}