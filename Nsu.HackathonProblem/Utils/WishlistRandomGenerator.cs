using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem.Utils;

public static class WishlistRandomGenerator
{
    public static List<Wishlist> RandomGenerateWishlist(List<Employee> group, List<Employee> desiredGroup)
    {
        var random = new Random();
        var wishlists = new List<Wishlist>();

        foreach (var employee in group)
        {
            var desiredEmployees = desiredGroup
                .OrderBy(e => random.Next())
                .Select(e => e.Id)
                .ToArray();

            wishlists.Add(new Wishlist(employee.Id, desiredEmployees));
        }

        return wishlists;
    }
}