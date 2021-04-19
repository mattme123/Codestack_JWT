using System;

namespace JWTClaimsDemo.Extentions.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType => "application/json";
        public CustomException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
