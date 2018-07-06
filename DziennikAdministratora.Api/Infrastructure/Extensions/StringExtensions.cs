namespace DziennikAdministratora.Api.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool Empty(this string s)
        {
            if(s == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}