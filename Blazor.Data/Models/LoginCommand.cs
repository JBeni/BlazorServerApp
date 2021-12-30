namespace Blazor.Data.Models
{
    public class LoginCommand
    {
        [Required(ErrorMessage = "Email Address is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
