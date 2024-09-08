namespace HackathonApp;

public class Junior(List<TeamLead> preferences, string fullName)
{
    public int Id { get; set; }
    public string FullName { get; set; } = fullName;
    public List<TeamLead> Preferences { get; set; } = preferences;
}
