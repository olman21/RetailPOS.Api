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
    public class ContactTypeController : BaseController<ContactType, int>
    {
        public ContactTypeController(IUnitOfWork UnitOfWork) : base(UnitOfWork.ContactTypes) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Contacts/Types")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("Contacts/Types/{id:int}", Name ="GetContactType")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("Contacts/Types")]
        public override IHttpActionResult Post([FromBody] ContactType entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetContactType", new { id = entity.TypeID }));
            return Created(locationHeader, entity);

        }

        [Route("Contacts/Types/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] ContactType entity)
        {
            return base.Put(id, entity);
        }

        [Route("Contacts/Types/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<ContactType> patchData)
        {
            return Ok();
        }
        [Route("Contacts/Types/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
