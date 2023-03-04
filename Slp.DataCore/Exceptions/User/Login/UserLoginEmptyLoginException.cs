namespace Slp.DataCore.Exceptions.User.Login
{
    public class UserLoginEmptyLoginException:Exception
    {
        public UserLoginEmptyLoginException():base("Enter login") { }
    }
}
