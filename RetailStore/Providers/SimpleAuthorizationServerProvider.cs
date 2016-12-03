using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RetailStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using RetailStore.DataAccess;

namespace RetailStore.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository _repo = new AuthRepository())
            {
                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            using (EFUnitOfWork _repo = new EFUnitOfWork(new RetailContext()))
            {
                var applicationUser = _repo.Users.Find(u => u.UserName == context.UserName).SingleOrDefault();
                if(applicationUser != null)
                    identity.AddClaim(new Claim("appUserId", applicationUser.UserID.ToString()));
            }

                context.Validated(identity);

        }
    }
}