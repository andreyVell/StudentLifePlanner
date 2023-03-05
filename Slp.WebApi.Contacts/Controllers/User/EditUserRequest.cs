namespace Slp.WebApi.Contracts.Controllers.User
{
    public class EditUserRequest
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }
    }
}
