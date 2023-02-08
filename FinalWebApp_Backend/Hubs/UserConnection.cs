using System.ComponentModel.DataAnnotations;

namespace FinalWebApp_Backend_WEB.Hubs
{
    public class UserConnection
    {
        [Required]
        public string? User { get; set; }

        [Required]
        public string? Room { get; set; }
    }

}
