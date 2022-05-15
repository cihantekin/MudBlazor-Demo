using System.ComponentModel.DataAnnotations;

namespace MudBlazorDemoServer.Data
{
    public class FootballTeam
    {
        public FootballTeam()
        {

        }
        public FootballTeam(string name, string stadium, DateTime? foundationYear, string city, int rating, int supporterCount, string colors)
        {
            Name = name;
            Stadium = stadium;
            FoundationYear = foundationYear;
            City = city;
            Rating = rating;
            SupporterCount = supporterCount;
            Colors = colors;
        }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public DateTime? FoundationYear { get; set; }
        public string City { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Value should be between {1} and {2}")]
        public int Rating { get; set; }
        public int SupporterCount { get; set; }
        public string Colors { get; set; }
    }
}
