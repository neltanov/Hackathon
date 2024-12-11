namespace Nsu.HackathonProblem.Utils;

public static class HarmonicMeanCalculator
{
    public static double HarmonicMean(List<int> numbers)
    {
        var numberArray = numbers.ToArray();
        return numberArray.Length / numberArray.Sum(n => 1.0 / n);
    }
}