using System;
using System.Collections.Generic;
using System.Text;

namespace Amajuso.Domain.Utils
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public long Seconds { get; set; }
    }
}
