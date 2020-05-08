﻿using AutoMapper;
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


        [Route("getUserDetailsById/{userId}")]
        public async Task<IHttpActionResult> GetUserDetailsById(int userId)
        {
            if (userId == 0) return BadRequest();

            var dateFormat = "dd.MM.yyyy hh:mm";
            var user = await _unitOfWork.AppUserRepository.FindByIdAsync(userId);

            var result = new UserDetailDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IsActive = Convert.ToInt32(user.IsActive),

                CreationDate = user.CreationDate.ToString(dateFormat),
                LastLoginDate = user.LastLogin.ToString(dateFormat),
                LastModifiedDate = user.LastModified.ToString(dateFormat),

                IsEmailConfirmed = Convert.ToInt32(user.EmailConfirmed),
                TwoFactorEnabled = Convert.ToInt32(user.TwoFactorEnabled),
                LockoutEnabled = Convert.ToInt32(user.LockoutEnabled),
                PrivacyPolicyAccepted = Convert.ToInt32(user.PrivacyPolicyAccepted),
                IsDarkmodeEnabled = Convert.ToInt32(user.IsDarkmodeEnabled)
            };


            return Ok(result);
        }




    }
}