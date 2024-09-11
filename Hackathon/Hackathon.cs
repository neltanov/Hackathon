using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem;
public class Hackathon
{
    public void Start(List<Employee> teamLeads, List<Employee> juniors)
    {
        List<Wishlist> teamLeadsWishlists = RandomGenerateWishlist(teamLeads, juniors);
        List<Wishlist> juniorsWishlists = RandomGenerateWishlist(juniors, teamLeads);
        
        HRManager hrManager = new HRManager();
        
        var teams = hrManager.TeamBuildingStrategy.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
        
    }
    
    private static List<Wishlist> RandomGenerateWishlist(List<Employee> group, List<Employee> desiredGroup)
    {
        Random random = new Random();
        List<Wishlist> wishlists = new List<Wishlist>();

        foreach (var employee in group)
        {
            int[] desiredEmployees = desiredGroup
                .OrderBy(e => random.Next()) 
                .Select(e => e.Id)
                .ToArray();
            
            wishlists.Add(new Wishlist(employee.Id, desiredEmployees));
        }

        return wishlists;
    }
}