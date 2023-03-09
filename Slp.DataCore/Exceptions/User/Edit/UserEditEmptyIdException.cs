namespace Slp.DataCore.Exceptions.User.Edit
{
    public class UserEditEmptyIdException:Exception
    {
        public UserEditEmptyIdException():base("Id is required") { }
    }
}
