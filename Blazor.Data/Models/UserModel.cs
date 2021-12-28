namespace Blazor.Data.Models
{
    public class UserModel
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; }

        public UserModel Clone()
        {
            return new UserModel
            {
                Email = Email,
                Username = Username,
                Bio = Bio,
                Image = Image
            };
        }
    }
}
