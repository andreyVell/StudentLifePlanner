namespace Slp.DataCore.Exceptions.User.Login
{
    public class UserLoginIncorrectDataException:Exception
    {
        public UserLoginIncorrectDataException():base("The login or password is incorrect") { }
    }
}
