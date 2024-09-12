using System.Linq.Expressions;
using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.Utils;

namespace Nsu.HackathonProblem;

static class Program
{
    static void Main(string[] args)
    {
        try
        {
            Hackathon hackathon = new Hackathon();
        
            List<Employee> teamLeads = CsvParser.ParseCsv(args[0]);
            List<Employee> juniors = CsvParser.ParseCsv(args[1]);
        
            hackathon.Start(teamLeads, juniors);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}