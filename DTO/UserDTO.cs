using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystemAPI.Models
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string PasswordConfirm { get; set; }

        public List<int> RoleIds { get; set; }

        public List<string> Roles { get; set; } = new List<string>();  // e.g. ["Admin"] or ["Doctor", "Patient"]
    }
}