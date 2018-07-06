using System;
using System.Security.Cryptography;
using DziennikAdministratora.Api.Infrastructure.Extensions;

namespace DziennikAdministratora.Api.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;

        public Encrypter()
        {
            
        }

        public string GetHash(string value, string salt)
        {
            if(value.Empty())
            {
                throw new ArgumentException("Nie można wygenerowac z pustej wartości.");
            }
            if(salt.Empty())
            {
                throw new ArgumentException("NIe można wygenerowa z pustej wartości.");
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public string GetSalt(string value)
        {
            if(value.Empty())
            {
                throw new ArgumentException("Nie można wygenerowac z pustej wartości");
            }

            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length*sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}