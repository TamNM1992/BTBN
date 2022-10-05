using System.ComponentModel.DataAnnotations;

namespace BaoTangBn.Data.Models
{
    public class AuthenticateRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}