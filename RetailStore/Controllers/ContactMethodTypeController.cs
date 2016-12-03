using Retail.Repository.Interfaces;
using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JsonPatch;

namespace RetailStore.Controllers
{
    [Authorize]
    public class ContactMethodTypeController : BaseController<ContactMethodType, int>
    {
        public ContactMethodTypeController(IUnitOfWork UnitOfWork) : base(UnitOfWork.ContactMethodTypes) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("ContactMethodTypes")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("ContactMethodTypes/{id:int}", Name = "GetContactMethodType")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("ContactMethodTypes")]
        public override IHttpActionResult Post([FromBody] ContactMethodType entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetContactMethodType", new { id = entity.MethodID }));
            return Created(locationHeader, entity);

        }

        [Route("ContactMethodTypes/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] ContactMethodType entity)
        {
            return base.Put(id, entity);
        }

        [Route("ContactMethodTypes/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<ContactMethodType> patchData)
        {
            return base.Patch(id, patchData);
        }

        [Route("ContactMethodTypes/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
