using JwtTokenSample.Entity;
using MediatR;
using System;

namespace JwtTokenSample.Jwt
{

    public class JwtTokenCommand : IRequest<TokenResponse>
    {

        public JwtTokenCommand(UserInfo userInfo)
        {
            this.UserInfo = userInfo;
        }

        public UserInfo UserInfo { get; }
      
    }
}
