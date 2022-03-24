using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcTrader.Application.Exceptions
{
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}
