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
    public class OrderTypeController : BaseController<OrderType, int>
    {
        public OrderTypeController(IUnitOfWork UnitOfWork) : base(UnitOfWork.OrderTypes) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Orders/Types")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("Orders/Types/{id:int}", Name ="GetOrderType")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("Orders/Types")]
        public override IHttpActionResult Post([FromBody] OrderType entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetOrderType", new { id = entity.OrderTypeID }));
            return Created(locationHeader, entity);

        }

        [Route("Orders/Types/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] OrderType entity)
        {
            return base.Put(id, entity);
        }

        [Route("Orders/Types/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<OrderType> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("Orders/Types/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
