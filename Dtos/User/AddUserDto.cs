namespace CineRadarAI.Api.Dtos.User
{
    public class AddUserDto
    {
        public string Name { get; set; } = "User";
        public string[] LikedMovies { get; set; } = [];
    }
}