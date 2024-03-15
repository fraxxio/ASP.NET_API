namespace CineRadarAI.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "User";
        public string[] LikedMovies { get; set; } = [];
    }
}