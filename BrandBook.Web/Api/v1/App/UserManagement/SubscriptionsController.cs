using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BrandBook.Core;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Dto.App.UserManagement;
using BrandBook.Web.Framework.Controllers.ApiControllers;

namespace BrandBook.Web.Api.v1.App.UserManagement
{
    [RoutePrefix("api/v1/subscriptions")]
    public class SubscriptionsController : AppApiControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
