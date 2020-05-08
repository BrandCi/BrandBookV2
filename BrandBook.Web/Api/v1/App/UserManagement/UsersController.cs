using AutoMapper;
using BrandBook.Core;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Dto.App.UserManagement;
using BrandBook.Web.Framework.Controllers.ApiControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BrandBook.Web.Api.v1.App.UserManagement
{
    [RoutePrefix("api/v1/users")]
    public class UsersController : AppApiControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Route("")]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var allUsers = await _unitOfWork.AppUserRepository.GetAllAsync();

            return Mapper.Map<IEnumerable<AppUser>, IEnumerable<UserDto>>(allUsers);

        }

        [Route("getUserNameById/{userId}")]
        public async Task<IHttpActionResult> GetUserNameById(int userId)
        {
            if (userId == 0) return BadRequest();

            var user = await _unitOfWork.AppUserRepository.FindByIdAsync(userId);

            return Ok(user.UserName);
        }




    }
}