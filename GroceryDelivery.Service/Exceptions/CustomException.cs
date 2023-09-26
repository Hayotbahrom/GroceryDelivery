using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.Service.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public CustomException(int code, string message) : base(message)
        {
            this.StatusCode = code;
        }
        
    }
}
