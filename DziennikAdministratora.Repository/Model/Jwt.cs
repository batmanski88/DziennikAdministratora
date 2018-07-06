using System;

namespace DziennikAdministratora.Repository.Model
{
    public class Jwt
    {
        public Guid JwtId {get; protected set;}
        public Guid UserId {get; protected set;}
        public string Token {get; protected set;}
        public long ExpiryMinutes {get; protected set;}

        protected Jwt()
        {

        }

        public Jwt(Guid jwtId, Guid userId, string token, long expiryMinutes)
        {
            JwtId = jwtId;
            UserId = userId;
            Token = token;
            ExpiryMinutes = expiryMinutes;
        }
    }
}