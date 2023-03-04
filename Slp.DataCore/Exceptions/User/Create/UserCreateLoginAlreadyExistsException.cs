namespace Slp.DataCore.Exceptions.User.Create
{
    public class UserCreateLoginAlreadyExistsException:Exception
    {
        public UserCreateLoginAlreadyExistsException():base("A user login already exists") { }
    }
}
