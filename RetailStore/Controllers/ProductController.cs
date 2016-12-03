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
    public class ProductController : BaseController<Product, Guid>
    {
        public ProductController(IUnitOfWork UnitOfWork) : base(UnitOfWork.Products) {
            this.UnitOfWork = UnitOfWork;
        }

        [ResponseType(typeof(Product[]))]
        [Route("Products")]
        public override IHttpActionResult Get()
        {
            var result = this.UnitOfWork.Products.GetAll(p=>p.MeasureUnit);
            return Ok(result);
        }
        [ResponseType(typeof(Product))]
        [Route("Products/{id:guid}", Name = "GetProduct")]
        public override IHttpActionResult Get(Guid id)
        {
            return base.Get(id);
        }

        [Route("Products")]
        public override IHttpActionResult Post([FromBody] Product entity)
        {
            base.Post(entity);
            Uri locationHeader = new Uri(Url.Link("GetProduct", new { id = entity.ProductID }));
            return Created(locationHeader, entity);

        }

        [Route("Products/{id:int}")]
        public override IHttpActionResult Put([FromUri] Guid id, [FromBody] Product entity)
        {
            return base.Put(id, entity);
        }

        [Route("Products/{id:guid}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<Product> patchData)
        {
            return base.Patch(id, patchData);
        }
        [Route("Products/{id:guid}")]
        public override IHttpActionResult Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}
