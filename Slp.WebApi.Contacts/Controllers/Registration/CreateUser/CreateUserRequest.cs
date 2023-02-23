namespace Slp.WebApi.Contracts.Controllers.Registration.CreateUser
{
    public class CreateUserRequest
    {
        public string? FirstName { get; set; }
        public string? Login {get; set; }
        public string? Password { get; set; }
    }
}
