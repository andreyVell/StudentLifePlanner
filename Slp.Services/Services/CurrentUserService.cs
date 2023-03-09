using AutoMapper;
using Microsoft.AspNetCore.Http;
using Slp.DataCore.Entities;
using Slp.DataCore.Exceptions.User;
using Slp.DataCore.Exceptions.User.Create;
using Slp.DataProvider;
using Slp.Services.Models;
using Slp.Services.Models.User;
using Slp.Services.Services.Interfaces;
using System.Security.Claims;

namespace Slp.Services.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetUserModel> GetCurrentUserAsync()
        {
            var user = await _unitOfWork.Users.GetFirstWhereAsync(e=>e.Id == GetCurrentUserId());
            if (user == null)
            {
                throw new UserDoesNotExistException();
            }
            return _mapper.Map<GetUserModel>(user!);
        }

        public async Task<Guid> EditCurrentUserAsync(EditUserModel user)
        {
            //проверить валидность полей
            ModelValidator.ValidateModel(user);
            //обновить то что в базе
            var bdUser = await _unitOfWork.Users.GetFirstWhereAsync(e=>e.Id == user.Id);
            if (bdUser == null)
            {
                throw new UserDoesNotExistException();
            }
            bdUser.AvatarUrl = user.AvatarUrl;
            bdUser.Email = user.Email;
            bdUser.FirstName = user.FirstName;
            bdUser.LastName = user.LastName;
            bdUser.SecondName = user.SecondName;
            var result = await _unitOfWork.Users.UpdateAsync(bdUser);
            return result.Id;

        }

        public Guid GetCurrentUserId()
        {
            Guid result = Guid.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = Guid.Parse(_httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
            return result;
        }
    }
}
