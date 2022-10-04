using System;

namespace JwtTokenSample
{
    public class TokenResponse
    {
        public SuccessToken Token { get; set; }
        public Error Error { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
    public class SuccessToken
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime? LastLoginDateTIme
        {
            get; set;
        }
    }
    public class Error
    {
        public string ErrorText { get; set; }
    }
}
