using JsonPatch;
using Microsoft.AspNet.Identity.Owin;
using Retail.Repository.Interfaces;
using RetailStore.Infrastructure;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using RetailStore.Models;
using Microsoft.AspNet.Identity;
using RetailStore.Domain;
using System.Security.Claims;
using System.Linq;

namespace RetailStore.Controllers
{
    public abstract class BaseController<TEntity, TKey> : ApiController
        where TEntity : class, new()
    {
        private IRepository<TEntity> Repository { get; set; }
        protected IUnitOfWork UnitOfWork;
        private ModelFactory _modelFactory;
        private ApplicationUserManager _AppUserManager = null;
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }


        public BaseController(IRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public virtual IHttpActionResult Get()
        {
            var result = this.Repository.GetAll();
            return Ok(result);
        }

        public virtual IHttpActionResult Get(TKey id)
        {
            var result = this.Repository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        public virtual IHttpActionResult Post([FromBody]TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bEntity = entity as BaseEntity;
            if (bEntity != null)
            {
                var userClaim = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "appUserId");
                int userId;
                if (userClaim != null && int.TryParse(userClaim.Value, out userId))
                    bEntity.CreatedByID = userId;
            }

            this.Repository.Add(entity);
            this.UnitOfWork.Complete();
            return Ok(entity);
        }

        public virtual IHttpActionResult Post([FromBody]IEnumerable<TEntity> entities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entities.ToList().ForEach(entity =>
            {
                var bEntity = entity as BaseEntity;
                if (bEntity != null)
                {
                    var userClaim = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "appUserId");
                    int userId;
                    if (userClaim != null && int.TryParse(userClaim.Value, out userId))
                        bEntity.CreatedByID = userId;
                }
            });

            this.Repository.AddRange(entities);
            this.UnitOfWork.Complete();
            return Ok(entities);
        }

        public virtual IHttpActionResult Put([FromUri]TKey id, [FromBody]TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bEntity = entity as BaseEntity;
            if (bEntity != null)
            {
                var userClaim = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "appUserId");
                int userId;
                if (userClaim != null && int.TryParse(userClaim.Value, out userId))
                    bEntity.ModifiedByID = userId;
            }

            this.Repository.Update(entity);
            this.UnitOfWork.Complete();
            return Ok();
        }

        public virtual IHttpActionResult Delete(TKey id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = this.Repository.Get(id);
            if (entity is BaseEntity)
            {
                var baseEnt = (entity as BaseEntity);
                if (!baseEnt.IsDeleted)
                {
                    var userClaim = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "appUserId");
                    int deletedBy;
                    if (userClaim != null && int.TryParse(userClaim.Value, out deletedBy))
                        baseEnt.DeletedByID = deletedBy;

                    baseEnt.IsDeleted = true;
                }

            }
            else
            {
                this.Repository.Remove(entity);
            }

            this.UnitOfWork.Complete();
            return Ok();
        }

        public virtual IHttpActionResult Delete(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (entity is BaseEntity)
            {
                var baseEnt = (entity as BaseEntity);
                if (!baseEnt.IsDeleted)
                {
                    var userClaim = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "appUserId");
                    int deletedBy;
                    if (userClaim != null && int.TryParse(userClaim.Value, out deletedBy))
                        baseEnt.DeletedByID = deletedBy;

                    baseEnt.IsDeleted = true;
                }

            }
            else
            {
                this.Repository.Remove(entity);
            }

            this.UnitOfWork.Complete();
            return Ok();
        }


        public virtual IHttpActionResult Patch(object id, JsonPatchDocument<TEntity> patchData)
        {

            var objectToUpdate = Repository.Get(id);
            patchData.ApplyUpdatesTo(objectToUpdate);

            var bEntity = objectToUpdate as BaseEntity;
            if (bEntity != null)
            {
                var userClaim = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "appUserId");
                int userId;
                if (userClaim != null && int.TryParse(userClaim.Value, out userId))
                    bEntity.ModifiedByID = userId;
            }

            UnitOfWork.Complete();

            return Ok();
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UnitOfWork != null)
                {
                    UnitOfWork.Dispose();
                }
            }
            base.Dispose(disposing);
        }


    }
}
