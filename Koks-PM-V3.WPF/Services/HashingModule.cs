using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Services
{
    public static class HashingModule
    {
        public static string HashPassword(string password)
        {
            string HashedPassword;
            SHA512 hash = SHA512.Create();
            var PasswordBytes = Encoding.Default.GetBytes(password);
            HashedPassword = Convert.ToHexString(hash.ComputeHash(PasswordBytes));
            return HashedPassword;
        }
    }
}
