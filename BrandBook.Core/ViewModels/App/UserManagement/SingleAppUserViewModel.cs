﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.ViewModels.App.UserManagement
{
    public class SingleAppUserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
