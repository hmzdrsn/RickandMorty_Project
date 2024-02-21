using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class LoginResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime? AccessTokenExpireDate { get; set; }
        public string? State { get; set; }
    }
}
