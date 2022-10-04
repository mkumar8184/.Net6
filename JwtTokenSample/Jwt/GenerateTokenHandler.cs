
using MediatR;
namespace JwtTokenSample.Jwt
{

    public class GenerateTokenHandler : BaseJwtTokenHandler,
       IRequestHandler<JwtTokenCommand, TokenResponse>
    {
        public GenerateTokenHandler(IConfiguration configuration)
            : base(configuration)
        {
        }
        public async Task<TokenResponse> Handle(JwtTokenCommand request,
           CancellationToken cancellationToken)
           => await this.GetAuthToken(request, cancellationToken);
    }

}

