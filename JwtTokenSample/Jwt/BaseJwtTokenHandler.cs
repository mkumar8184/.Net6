namespace JwtTokenSample.Jwt
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using JwtTokenSample.Entity;
    using Microsoft.IdentityModel.Tokens;
   

    public abstract class BaseJwtTokenHandler
    {
        private readonly IConfiguration _configuration;
        protected BaseJwtTokenHandler(IConfiguration configuration

           )
        {
            _configuration = configuration;

        }

        protected async Task<TokenResponse> GetAuthToken(JwtTokenCommand command, CancellationToken cancellationToken)
        {
            var tokenResponse = new TokenResponse();
            var success = new SuccessToken();
            var error = new Error();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["jwtSetting:secret"]);
            var user = command.UserInfo;
            var token = new JwtSecurityToken(
              expires: DateTime.UtcNow.AddDays(7),
              claims: GetUserClaims(user),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            success.Name = user.UserName;
            success.UserId =user.UserId;
            success.EmailId = user.EmailId;          
            success.ProfilePhoto = "";
            success.Token = new JwtSecurityTokenHandler().WriteToken(token);
            tokenResponse.Token = success;

            return await Task.FromResult(tokenResponse);
        }
      
        private List<Claim> GetUserClaims(UserInfo user)
        {
            var claimsdata = new List<Claim>
                  {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                    new Claim("email",user.EmailId.ToString()),
                    new Claim("companyId",user.CompanyId.ToString()),
                    new Claim("locationId",user.Location.ToString())
                   };

            var roles =string.IsNullOrEmpty(user.Roles)? new[] { "employee" }: user.Roles.Split(",") ;
            foreach (var role in roles)
            {
                claimsdata.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            return claimsdata;
        }
     
    }
}