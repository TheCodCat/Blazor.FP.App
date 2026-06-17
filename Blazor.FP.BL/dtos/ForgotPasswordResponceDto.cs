using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.dtos
{
    public class ForgotPasswordResponceDto
    {
        public int RequestId { get; set; }
        public bool Status { get; set; }
        public string Login { get; set; }
        public string Message { get; set; }
        public TimeSpan Timeout { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OtpCode { get; set; }
    }
}
