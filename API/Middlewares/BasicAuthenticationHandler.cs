using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public BasicAuthenticationOptions()
        {
        }
    }

    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
        ) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authorizationHeader = Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
                return FailingAuthentication();
            else if (authorizationHeader != "Bearer 908123u9132r187js1a289a8")
                return FailingAuthentication();

            // create a ClaimsPrincipal from your header
            var claims = new[]
            {
                new Claim("token", authorizationHeader)
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));
            var ticket = new AuthenticationTicket(claimsPrincipal,
                new AuthenticationProperties { 
                    IsPersistent = false 
                },
                Scheme.Name
            );

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        private Task<AuthenticateResult> FailingAuthentication() 
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return Task.FromResult(AuthenticateResult.Fail("You are not allowed to see this."));
        }
    }
}
