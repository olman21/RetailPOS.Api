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
    public class MeasureUnitController : BaseController<MeasureUnit, int>
    {
        public MeasureUnitController(IUnitOfWork UnitOfWork) : base(UnitOfWork.MeasureUnits) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("MeasureUnits")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("MeasureUnits/{id:int}", Name = "GetMeasureUnit")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("MeasureUnits")]
        public override IHttpActionResult Post([FromBody] MeasureUnit entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetMeasureUnit", new { id = entity.MeasureID }));
            return Created(locationHeader, entity);

        }

        [Route("MeasureUnits/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] MeasureUnit entity)
        {
            return base.Put(id, entity);
        }

        [Route("MeasureUnits/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<MeasureUnit> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("MeasureUnits/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
