using System.ComponentModel.DataAnnotations;

namespace NetCoreAngular.Server.Models.ViewModels
{
    public class AuthAPI
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
