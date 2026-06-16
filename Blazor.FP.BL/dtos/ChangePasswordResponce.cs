using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.FP.BL.dtos
{
    public class ChangePasswordResponce
    {
        public int RequestId { get; set; }
        public string Login { get; set; }
        public bool Result { get; set; } 
    }
}
