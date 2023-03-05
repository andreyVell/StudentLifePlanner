using AutoMapper;
using Slp.DataCore.Entities;
using Slp.Services.Models.DailyTask;
using Slp.Services.Models.User;
using Slp.WebApi.Contracts.Controllers.Authentication;
using Slp.WebApi.Contracts.Controllers.DailyTask;
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
            CreateMap<EditUserRequest, EditUserModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.Id) ?
                                    Guid.Empty :
                                    (CanParseToGuid(a.Id) ?
                                        ParseToGuid(a.Id) :
                                        Guid.Empty)));

            CreateMap<CreateDailyTaskRequest, CreateDailyTaskModel>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.Name) ?
                                    "Daily task without name" :
                                    a.Name))
                .ForMember(
                    dest => dest.IsCompleted,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.IsCompleted) ?
                                    "false" :
                                    (CanParseToBool(a.IsCompleted) ?
                                        ParseToBool(a.IsCompleted).ToString() :
                                        "false")))
                .ForMember(
                    dest => dest.DeadLineDate,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.DeadLineDate) ?
                                    new DateTime(0) :
                                    (CanParseToDateTime(a.DeadLineDate) ?
                                        ParseToDateTime(a.DeadLineDate) :
                                        new DateTime(0))));

            CreateMap<EditDailyTaskRequest, EditDailyTaskModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.Id) ?
                                    Guid.Empty :
                                    (CanParseToGuid(a.Id) ?
                                        ParseToGuid(a.Id) :
                                        Guid.Empty)))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.Name) ?
                                    "Daily task without name" :
                                    a.Name))
                .ForMember(
                    dest => dest.IsCompleted,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.IsCompleted) ?
                                    "false" :
                                    (CanParseToBool(a.IsCompleted) ?
                                        ParseToBool(a.IsCompleted).ToString() :
                                        "false")))
                .ForMember(
                    dest => dest.DeadLineDate,
                    opt => opt.
                            MapFrom(a =>
                                string.IsNullOrEmpty(a.DeadLineDate) ?
                                    new DateTime(0) :
                                    (CanParseToDateTime(a.DeadLineDate) ?
                                        ParseToDateTime(a.DeadLineDate) :
                                        new DateTime(0))));

            #endregion

            #region Contracts to Entities



            #endregion

            #region Entities to Contracts



            #endregion

            #region Entities to Models

            CreateMap<User, GetUserModel>();
            CreateMap<DailyTask, GetDailyTaskModel>();

            #endregion

            #region Models to Entities

            CreateMap<GetUserModel, User>();
            CreateMap<EditUserModel, User>();

            #endregion

            #region Models to Contracts

            CreateMap<GetUserModel, GetUserResponse>();
            CreateMap<GetDailyTaskModel, GetDailyTaskResponse>();

            #endregion
        }

        private bool CanParseToGuid(string value)
        {
            Guid guid;
            return Guid.TryParse(value, out guid);
        }
        private Guid ParseToGuid(string value)
        {
            return Guid.Parse(value);
        }

        private bool CanParseToBool(string value)
        {
            bool check;
            return Boolean.TryParse(value, out check);
        }

        private bool ParseToBool(string value)
        {
            return Boolean.Parse(value);
        }

        private bool CanParseToDateTime(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }

        private DateTime ParseToDateTime(string value)
        {
            return DateTime.Parse(value);
        }

    }
}
