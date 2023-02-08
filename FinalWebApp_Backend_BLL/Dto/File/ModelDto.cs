using Microsoft.AspNetCore.Http;
namespace FinalWebApp_Backend_BLL.Dto.File
{
    public class ModelDto
    {
        public string? FileName { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
