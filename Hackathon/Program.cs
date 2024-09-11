using Nsu.HackathonProblem.Contracts;

namespace Nsu.HackathonProblem;

static class Program
{
    static void Main(string[] args)
    {
        Hackathon hackathon = new Hackathon();
        
        List<Employee> teamLeads = new List<Employee>();
        teamLeads.Add(new Employee(1, "John Doe"));
        teamLeads.Add(new Employee(2, "Alex Jones"));
        List<Employee> juniors = new List<Employee>();
        juniors.Add(new Employee(3, "Jack Halen"));
        juniors.Add(new Employee(4, "Eman Kennel"));
        
        hackathon.Start(teamLeads, juniors);
        // for (int i = 0; i < 1000; i++)
        // {
            // посчитать уровень гармоничности
        // }
        Console.WriteLine("Hackathon starting...");
    }
}