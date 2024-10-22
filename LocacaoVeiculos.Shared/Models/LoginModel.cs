using LocacaoVeiculos.Shared.CrossCutting.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoVeiculos.Shared.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Compare(string password)
        {
            return password == Hash.Make(Password);
        }
    }
}
