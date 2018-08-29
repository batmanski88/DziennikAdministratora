using System;
using DziennikAdministratora.Api.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace DziennikAdministratora.Api.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid TokenId, JwtModel jwt)
            => cache.Set(GetJwtKey(TokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtModel GetJwt(this IMemoryCache cache, Guid TokenId)
            => cache.Get<JwtModel>(GetJwtKey(TokenId));

        public static string GetJwtKey(Guid TokenId)
            => $"jwt- { TokenId }";
    }
}