using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace TutoringAcademicSupport.LogIn
{
    public static class PasswordService
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.Bcrypt.EnhancedHashPassword(password,workfactor: 11);
        }

        public static bool VerifyPassword(string hashPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(providedPassword,hashPassword);
        }
    }
}