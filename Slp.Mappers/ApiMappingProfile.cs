using AutoMapper;
using Slp.DataCore.Entities;
using Slp.Services.Models.User;
using Slp.WebApi.Contracts.Controllers.Authentication;
using Slp.WebApi.Contracts.Controllers.Registration;
using Slp.WebApi.Contracts.Controllers.User;

namespace Slp.Mappers
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            #region Contracts to Models

            CreateMap<CreateUserRequest, CreateUserModel>();
            CreateMap<LoginUserRequest, LoginUserModel>();
            Guid guid = Guid.Empty;
            CreateMap<EditUserRequest, EditUserModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.Id) ?
                                    Guid.Empty :
                                    (Guid.TryParse(a.Id, out guid) ?
                                        guid :
                                        Guid.Empty)));

            #endregion

            #region Contracts to Entities



            #endregion

            #region Entities to Contracts



            #endregion

            #region Entities to Models

            CreateMap<User, GetUserModel>();

            #endregion

            #region Models to Entities

            CreateMap<GetUserModel, User>();
            CreateMap<EditUserModel, User>();

            #endregion

            #region Models to Contracts

            CreateMap<GetUserModel, GetUserResponse>();

            #endregion
        }
    }
}
