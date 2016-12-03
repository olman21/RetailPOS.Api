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
    public class PersonController : BaseController<Person, int>
    {
        public PersonController(IUnitOfWork UnitOfWork) : base(UnitOfWork.People) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("People")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("People/{id:int}", Name = "GetPerson")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("People")]
        public override IHttpActionResult Post([FromBody] Person entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetPerson", new { id = entity.PersonID }));
            return Created(locationHeader, entity);

        }

        [Route("People/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] Person entity)
        {
            return base.Put(id, entity);
        }

        [Route("People/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<Person> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("People/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
