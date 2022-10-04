using JwtTokenSample.Extensions;
using JwtTokenSample.Helpers;
using System.Security.Claims;

namespace JwtTokenSample.Models
{
    public  class SessionUser
    {        
            public string Id { get; set; }          
            public string Username { get; set; }
            public string EmailId { get; set; }
            public string MobileNo { get; set; }
            public string ProfilePhoto { get; set; }
            public List<string> Roles { get; set; }
        
        public static SessionUser GetSessionUser()
        {
            var httpContext = HttpContextHandler.Current;
            if (httpContext.User == null)
            {
                return null;
            }
            

            return new SessionUser
            {
                Id = UserClaims.GetClaimByForContext(httpContext, "name"),
                Username = httpContext.User.FindFirstValue("name"),
                EmailId = UserClaims.GetClaimByForContext(httpContext, "email"),
                Roles = UserClaims.GetUserRoleByClaims(httpContext.User.Claims),
            
            };
      
        }
    }
}
