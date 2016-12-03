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
    public class ContactMethodValueController : BaseController<ContactMethodValue, Guid>
    {
        public ContactMethodValueController(IUnitOfWork UnitOfWork) : base(UnitOfWork.ContactMethodValues) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Contacts/{id:guid}/ContactMethods")]
        public override IHttpActionResult Get(Guid id)
        {
            var result = UnitOfWork.ContactMethodValues.Find(c => c.ContactID == id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [Route("Contacts/{id:guid}/ContactMethods/{cid:int}", Name = "GetContactMethodValue")]
        public IHttpActionResult Get(Guid id, int cid)
        {
            var result = UnitOfWork.ContactMethodValues.SingleOrDefault(c=>c.ContactID == id && c.ContactMethodID == cid);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("Contacts/{id:guid}/ContactMethods")]
        public override IHttpActionResult Post([FromBody] ContactMethodValue entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetContactMethodValue", new { id = entity.ContactID, cid=entity.ContactMethodID }));
            return Created(locationHeader, entity);

        }

        [Route("Contacts/{id:guid}/ContactMethods/{cid:int}")]
        public IHttpActionResult Put([FromUri] Guid id,[FromUri] int cid, [FromBody] ContactMethodValue entity)
        {
            return base.Put(id, entity);
        }

        [Route("Contacts/{id:guid}/ContactMethods/{cid:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<ContactMethodValue> patchData)
        {
            return Ok();
        }

        [Route("Contacts/{id:guid}/ContactMethods/{cid:int}")]
        public IHttpActionResult Delete(Guid id, int cid)
        {
            var value = UnitOfWork.ContactMethodValues.SingleOrDefault(c => c.ContactID == id && c.ContactMethodID == cid);
            return base.Delete(value);
        }
    }
}
