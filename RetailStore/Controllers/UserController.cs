using JsonPatch;
using Microsoft.AspNet.Identity;
using Retail.Repository.Interfaces;
using RetailStore.Domain;
using RetailStore.Infrastructure;
using RetailStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RetailStore.Controllers
{
    public class UserController : BaseController<User,int>
    {

        public UserController(IUnitOfWork UnitOfWork) : base(UnitOfWork.Users) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Users")]
        [Authorize]
        public override IHttpActionResult Get() {
            var result = this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u));
            return Ok(result);
        }

        [Route("Users/{id:guid}",Name="GetUser")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            var user = await this.AppUserManager.FindByIdAsync(id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();
        }

        [Route("users/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("Users")]
        public async Task<IHttpActionResult> Post([FromBody]UserModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var NewUser = new Domain.User
            {
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                UserName = createUserModel.Username,
                Active = true
            };
            UnitOfWork.Users.Add(NewUser);

            UnitOfWork.Complete();

            try
            {
                var user = new ApplicationUser()
                {
                    UserName = createUserModel.Username,
                    Email = createUserModel.Email
                };

                IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

                if (!addUserResult.Succeeded)
                {
                    UnitOfWork.Users.Remove(NewUser);
                    return GetErrorResult(addUserResult);
                }

                Uri locationHeader = new Uri(Url.Link("GetUser", new { id = user.Id }));
                return Created(locationHeader, TheModelFactory.Create(user));

            }
            catch (Exception e)
            {
                UnitOfWork.Users.Remove(NewUser);
                throw e;
            }

            
        }

        [Route("Users/{id}")]
        public IHttpActionResult Patch(int id, JsonPatchDocument<User> patchData)
        {
            var objectToUpdate = UnitOfWork.Users.Get(id);
            patchData.ApplyUpdatesTo(objectToUpdate);
            UnitOfWork.Complete();

            return Ok();
        }
    }
}