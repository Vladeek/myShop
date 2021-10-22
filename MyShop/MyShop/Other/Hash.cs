using System;
using System.Security.Cryptography;
using System.Text;

namespace CourseProject.Other
{
    public static class HashHelper
    {
        private static readonly MD5 Md5 = MD5.Create();
        public static string GetMd5Hash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }

            var hash = Md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}