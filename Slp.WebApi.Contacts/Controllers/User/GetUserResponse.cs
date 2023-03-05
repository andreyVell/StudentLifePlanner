namespace Slp.WebApi.Contracts.Controllers.User
{
    public class GetUserResponse
    {        
        public Guid Id { get; set; }        
        public string FirstName { get; set; }        
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }  
    }
}
