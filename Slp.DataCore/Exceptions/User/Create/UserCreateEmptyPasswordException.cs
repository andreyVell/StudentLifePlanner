namespace Slp.DataCore.Exceptions.User.Create
{
    public class UserCreateEmptyPasswordException:Exception
    {
        public UserCreateEmptyPasswordException():base("Enter password") { }
    }
}
