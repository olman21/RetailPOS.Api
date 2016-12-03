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
    public class OrderController : BaseController<Order, int>
    {
        public OrderController(IUnitOfWork UnitOfWork) : base(UnitOfWork.Orders) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Orders")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("Order/{id:int}",Name ="GetOrder")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("Orders")]
        public override IHttpActionResult Post([FromBody] Order entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetOrder", new { id = entity.OrderID }));
            return Created(locationHeader, entity);

        }

        [Route("Orders/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] Order entity)
        {
            return base.Put(id, entity);
        }

        [Route("Orders/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<Order> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("Orders/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
