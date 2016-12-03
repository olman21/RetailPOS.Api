using Retail.Repository.Interfaces;
using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JsonPatch;
using System.Web.Http.Description;

namespace RetailStore.Controllers
{
    [Authorize]
    public class ContactController : BaseController<Contact, int>
    {
        public ContactController(IUnitOfWork UnitOfWork) : base(UnitOfWork.Contacts) {
            this.UnitOfWork = UnitOfWork;
        }

        [ResponseType(typeof(Contact[]))]
        [Route("Contacts")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [ResponseType(typeof(Contact))]
        [Route("Contacts/{id:int}", Name ="GetContact")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("Contacts")]
        public override IHttpActionResult Post([FromBody] Contact entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetContact", new { id = entity.ContactID }));
            return Created(locationHeader, entity);

        }

        [Route("Contacts/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] Contact entity)
        {
            return base.Put(id, entity);
        }

        [Route("Contacts/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<Contact> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("Contacts/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
