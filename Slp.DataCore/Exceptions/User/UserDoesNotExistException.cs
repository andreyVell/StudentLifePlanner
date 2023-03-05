namespace Slp.DataCore.Exceptions.User
{
    public class UserDoesNotExistException:Exception
    {
        public UserDoesNotExistException():base("The user does not exist") { }
    }
}
