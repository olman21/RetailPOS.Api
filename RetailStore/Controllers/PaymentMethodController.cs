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
    public class PaymentMethodController : BaseController<PaymentMethod, int>
    {
        public PaymentMethodController(IUnitOfWork UnitOfWork) : base(UnitOfWork.PaymentMethods) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("PaymentMethods")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }
        [Route("PaymentMethods/{id:int}", Name ="GetPaymentMethod")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("PaymentMethods")]
        public override IHttpActionResult Post([FromBody] PaymentMethod entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetPaymentMethod", new { id = entity.PaymentMethodID }));
            return Created(locationHeader, entity);

        }

        [Route("PaymentMethods/{id:int}")]
        public override IHttpActionResult Put([FromUri] int id, [FromBody] PaymentMethod entity)
        {
            return base.Put(id, entity);
        }

        [Route("PaymentMethods/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<PaymentMethod> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("PaymentMethods/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
