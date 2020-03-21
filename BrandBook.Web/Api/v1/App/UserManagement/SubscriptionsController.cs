﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BrandBook.Core;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Dto.App.UserManagement;
using BrandBook.Core.Services.Subscriptions;
using BrandBook.Web.Framework.Controllers.ApiControllers;
using Microsoft.AspNet.Identity;

namespace BrandBook.Web.Api.v1.App.UserManagement
{
    [RoutePrefix("api/v1/subscriptions")]
    public class SubscriptionsController : AppApiControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(
            IUnitOfWork unitOfWork, 
            ISubscriptionService subscriptionService)
        {
            _unitOfWork = unitOfWork;
            _subscriptionService = subscriptionService;
        }


        [Route("{userId}")]
        public IHttpActionResult GetByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return BadRequest();

            int userCompanyId = _unitOfWork.AppUserRepository.GetCompanyIdByUserId(userId);
            int existingBrands = _unitOfWork.BrandRepository.CountBrandsByCompany(userCompanyId);

            List<Subscription> subscriptions = _unitOfWork.SubscriptionRepository.GetAllUserSubscriptions(userId);

            var result = new List<SubscriptionDto>();

            foreach (var subscription in subscriptions)
            {
                SubscriptionPlan subscriptionPlan = _unitOfWork.SubscriptionPlanRepository.FindById(subscription.SubscriptionPlanId);
                
                var item = new SubscriptionDto
                {
                    Id = subscription.Id,
                    Key = subscription.Key,
                    StartDateTime = subscription.StartDateTime.ToString("dd.MM.yyyy hh:mm"),
                    EndDateTime = _subscriptionService.GetSubscriptionEndDate(subscription).ToString("dd.MM.yyyy hh:mm"),
                    IsPaid = subscription.IsPaid,
                    IsActive = subscription.IsActive,
                    SubscriptionPlanName = subscriptionPlan.Name,
                    PossibleAmountOfBrands = subscriptionPlan.AmountOfBrands,
                    PricePerMonth = subscriptionPlan.PricePerMonth,
                    CurrentAmountOfBrands = existingBrands,
                };
                
                result.Add(item);
            }

            return Ok(result);
        }

    }
}
