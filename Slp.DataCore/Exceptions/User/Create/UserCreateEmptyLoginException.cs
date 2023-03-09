namespace Slp.DataCore.Exceptions.User.Create
{
    public class UserCreateEmptyLoginException:Exception
    {
        public UserCreateEmptyLoginException() : base("Enter login") { }
    }
}
