namespace MudBlazorDemoServer.Data
{
    public class FootballTeamsService
    {
        public Task<List<FootballTeam>> Get()
        {
            return Task.FromResult(footballTeams);
        }

        public void AddFootballTeam(FootballTeam model)
        {
            footballTeams.Add(model);
        }

        public bool Delete(string name)
        {
            var item = footballTeams.FirstOrDefault(x => x.Name == name);
            var result = footballTeams.Remove(item);
            return result;
        }

        private static readonly List<FootballTeam> footballTeams = new()
        {
            new FootballTeam("Fenerbahçe", "Şükrü Saraçoğlu", new DateTime(1907, 1, 1), "İstanbul", 10, 20_000_000, "#FFEB3B,#0277BD"),
            new FootballTeam("Galatasaray", "TTArena", new DateTime(1905, 1, 1), "İstanbul", 5, 22_000_000, "#FFEB3B,#FF5722"),
            new FootballTeam("Beşiktaş", "Vodafone Arena", new DateTime(1903, 1, 1), "İstanbul", 4, 15_000_000, "#FFFFFF,#000000")
        };
    }
}
