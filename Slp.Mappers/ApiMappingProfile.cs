using AutoMapper;
using Slp.Services.Models.User;
using Slp.WebApi.Contracts.Controllers.Authentication;
using Slp.WebApi.Contracts.Controllers.Registration;

namespace Slp.Mappers
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            #region Contracts to Models

            CreateMap<CreateUserRequest, CreateUserModel>();
            CreateMap<LoginUserRequest, LoginUserModel>();

            #endregion
        }
    }
}
