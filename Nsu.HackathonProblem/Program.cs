using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Nsu.HackathonProblem;
using Nsu.HackathonProblem.Contracts;
using Nsu.HackathonProblem.TeamBuildingStrategy;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddHostedService<HackathonWorker>();
        services.AddTransient<Hackathon>(_ => new Hackathon());
        services.AddTransient<ITeamBuildingStrategy, StableMatchingsTeamBuildingStrategy>();
        services.AddTransient<HrManager>();
        services.AddTransient<HrDirector>();
    })
    .Build();

host.Run();
