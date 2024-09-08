namespace HackathonApp;

public class TeamLead(List<Junior> preferences, string fullName)
{
    public int Id { get; set; }
    public string FullName { get; set; } = fullName;
    public List<Junior> Preferences { get; set; } = preferences;
}