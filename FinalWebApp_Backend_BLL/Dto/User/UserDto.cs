namespace FinalWebApp_Backend_BLL.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Sex { get; set; }

        public bool? ExcludeFromSearch { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Status { get; set; }

    }
}
