using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.dtos
{
    public class ForgotPasswordRequestDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
    }
}
