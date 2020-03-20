﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Dto.App.UserManagement
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string SubscriptionPlanName { get; set; }
        public double PricePerMonth { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int PossibleAmountOfBrands { get; set; }
        public int CurrentAmountOfBrands { get; set; }

        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }

    }
}
