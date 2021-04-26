using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Responses
{
    public class CustomerRegisterRes
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public bool Success => Id != "";
    }
}
