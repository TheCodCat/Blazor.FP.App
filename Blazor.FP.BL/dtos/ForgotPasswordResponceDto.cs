using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.dtos
{
    public class ForgotPasswordResponceDto
    {
        public int Id { get; set; }
        public string OTPCode { get; set; } = string.Empty;
        public TimeSpan Offset { get; set; }
        public DateTime Created_in { get; set; }
        public int RequestId { get; set; }
    }
}
