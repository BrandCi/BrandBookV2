using System;
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

        public async Task<bool> SendEmailAsync(string receiver, string message, string subject = "")
        {
            bool isSent = false;


            return isSent;
        }

    }
}
