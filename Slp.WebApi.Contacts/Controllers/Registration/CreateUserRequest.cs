namespace Slp.WebApi.Contracts.Controllers.Registration
{
    public class CreateUserRequest
    {
        public string? FirstName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
