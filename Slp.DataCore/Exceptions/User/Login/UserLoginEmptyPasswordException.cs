namespace Slp.DataCore.Exceptions.User.Login
{
    public class UserLoginEmptyPasswordException:Exception
    {
        public UserLoginEmptyPasswordException():base("Enter password") { }
    }
}
