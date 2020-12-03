using System;
using System.Collections.Generic;

namespace BrandCi.Core.ViewModels.Auth.Process
{
    public class ReCaptchaResponseViewModel
    {
        public bool Success { get; set; }

        public IEnumerable<string> ErrorCodes { get; set; }
        public DateTime ChallengeTime { get; set; }

        public string HostName { get; set; }
        public double Score { get; set; }
        public string Action { get; set; }


    }
}
