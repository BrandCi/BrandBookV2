﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Services.Email
{
    public class EmailService
    {

        public async Task<bool> SendEmailAsync(string receiver, string msg, string subject = "")
        {
            bool isSent = false;

            try
            {
                var mailBody = msg;
                var message = new MailMessage();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return isSent;
        }

    }
}