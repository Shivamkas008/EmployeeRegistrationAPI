using System.ComponentModel.DataAnnotations;

namespace EmployeeRegistrationAPI.Models
{
    public class Login
    {
        [Required]
        public String username { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
