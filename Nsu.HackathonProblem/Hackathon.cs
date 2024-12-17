using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.TeamBuildingStrategy;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem
{
    public class Hackathon
    {
        private const string TeamLeadsCsvFilePath = "EmployeeData/Teamleads20.csv";
        private const string JuniorsCsvFilePath = "EmployeeData/Juniors20.csv";
        private readonly List<Employee> _teamLeads;
        private readonly List<Employee> _juniors;
        private readonly List<Wishlist> _teamLeadsWishlists;
        private readonly List<Wishlist> _juniorsWishlists;
        
        public Hackathon()
        {
            
            _teamLeads = CsvParser.ParseCsv(TeamLeadsCsvFilePath);
            _juniors = CsvParser.ParseCsv(JuniorsCsvFilePath);
            _teamLeadsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(_teamLeads, _juniors);
            _juniorsWishlists = WishlistRandomGenerator.RandomGenerateWishlist(_juniors, _teamLeads);
        }
        public double Start()
        {
            var hrManager = new HrManager(new StableMatchingsTeamBuildingStrategy());
            var teams = hrManager.BuildTeams(_teamLeads, _juniors, _teamLeadsWishlists,
                _juniorsWishlists);
            
            return HrDirector.CalculateHarmonicMean(teams.ToList(), _teamLeadsWishlists, _juniorsWishlists);
        }
    }
}