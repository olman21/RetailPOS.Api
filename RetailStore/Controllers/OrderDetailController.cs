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
    public class OrderDetailController : BaseController<OrderDetail, int>
    {
        public OrderDetailController(IUnitOfWork UnitOfWork) : base(UnitOfWork.OrderDetails) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Orders/{id:int}/OrderDetails")]
        public override IHttpActionResult Get(int id)
        {
            var result = UnitOfWork.OrderDetails.Find(d => d.OrderID == id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [Route("Orders/{id:int}/OrderOrderDetailsDetail/{oid:int}", Name ="GetOrderDetail")]
        public IHttpActionResult Get(int id, int oid)
        {
            var result = UnitOfWork.OrderDetails.Get(oid);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("Orders/{id:int}/OrderDetails")]
        public override IHttpActionResult Post([FromBody] OrderDetail entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetOrderDetail", new { id = entity.OrderID, oid=entity.OrderDetailID }));
            return Created(locationHeader, entity);

        }

        [Route("Orders/{id:int}/OrderDetails/{oid:int}")]
        public IHttpActionResult Put([FromUri] int id,[FromUri] int oid, [FromBody] OrderDetail entity)
        {
            return base.Put(oid, entity);
        }

        [Route("Orders/{id:int}/OrderDetails/{oid:int}")]
        public IHttpActionResult Patch(object id,object oid, JsonPatchDocument<OrderDetail> patchData)
        {
            return base.Patch(oid, patchData);
        }
        [Route("Orders/{id:int}/OrderDetails/{oid:int}")]
        public override IHttpActionResult Delete(int oid)
        {
            return base.Delete(oid);
        }
    }
}
