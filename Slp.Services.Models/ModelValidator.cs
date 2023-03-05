using Slp.DataCore.Exceptions.User.Create;
using Slp.DataCore.Exceptions.User.Edit;
using Slp.DataCore.Exceptions.User.Login;
using Slp.Services.Models.DailyTask;
using Slp.Services.Models.User;
using System.Runtime.InteropServices;

namespace Slp.Services.Models
{
    public class ModelValidator
    {
        /// <summary>
        /// Validate all object fields. Can throw an appropriate exception if the field is not valid.
        /// </summary>
        /// <param name="createUserModel">Object to validate</param>
        public static void ValidateModel(CreateUserModel createUserModel)
        {
            if (createUserModel == null)
            {
                throw new UserCreateEmptyUserDataException();
            }
            if (string.IsNullOrEmpty(createUserModel.FirstName))
            {
                throw new UserCreateEmptyFirstnameException();
            }
            if (string.IsNullOrEmpty(createUserModel.Login))
            {
                throw new UserCreateEmptyLoginException();
            }
            if (string.IsNullOrEmpty(createUserModel.Password))
            {
                throw new UserCreateEmptyPasswordException();
            }
        }
        /// <summary>
        /// Validate all object fields. Can throw an appropriate exception if the field is not valid.
        /// </summary>
        /// <param name="loginUserModel">Object to validate</param>
        public static void ValidateModel(LoginUserModel loginUserModel)
        {
            if (loginUserModel == null)
            {
                throw new UserLoginEmptyUserDataException();
            }
            if (string.IsNullOrEmpty(loginUserModel.Login))
            {
                throw new UserLoginEmptyLoginException();
            }
            if (string.IsNullOrEmpty(loginUserModel.Password))
            {
                throw new UserLoginEmptyPasswordException();
            }
        }
        /// <summary>
        /// Validate all object fields. Can throw an appropriate exception if the field is not valid.
        /// </summary>
        /// <param name="editUserModel">Object to validate</param>
        public static void ValidateModel(EditUserModel editUserModel)
        {
            if (editUserModel == null)
            {
                throw new UserEditEmptyUserDataException();
            }
            if (editUserModel.Id == Guid.Empty)
            {
                throw new UserEditEmptyIdException();
            }
            if (string.IsNullOrEmpty(editUserModel.FirstName))
            {
                throw new UserEditFirstnameEmptyException();
            }
        }        
    }
}
