using Nsu.HackathonProblem.TeamBuildingStrategy.Contracts;

namespace Nsu.HackathonProblem.TeamBuildingStrategy.Utils;

public static class CsvParser
{
    public static List<Employee> ParseCsv(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        
        var employees = lines
            .Skip(1)
            .Select(line =>
            {
                var parts = line.Split(';');
                var id = int.Parse(parts[0]);
                var name = parts[1];
                return new Employee(id, name);
            })
            .ToList();
        
        return employees;
    }
}