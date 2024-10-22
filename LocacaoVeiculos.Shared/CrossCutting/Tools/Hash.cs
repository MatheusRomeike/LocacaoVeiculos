using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoVeiculos.Shared.CrossCutting.Tools
{
    public class Hash
    {
        public static string Make(string value) 
        {
            byte[] salt = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
