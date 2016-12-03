using JsonPatch;
using Microsoft.AspNet.Identity;
using Retail.Repository.Interfaces;
using RetailStore.Domain;
using RetailStore.Infrastructure;
using RetailStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RetailStore.Controllers
{
    public class CategoryController : BaseController<Category,int>
    {

        public CategoryController(IUnitOfWork UnitOfWork) : base(UnitOfWork.Categories) {
            this.UnitOfWork = UnitOfWork;
        }

        [Route("Categories")]
        [Authorize]
        public override IHttpActionResult Get() {
            return base.Get();
        }

        [Route("Categories/{id:int}", Name ="GetCategory")]
        [HttpGet]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("Categories")]
        public override IHttpActionResult Post([FromBody]Category category)
        {
            base.Post(category);
            Uri locationHeader = new Uri(Url.Link("GetCategory", new { id = category.CategoryID }));
            return Created(locationHeader, category);

        }

        [Route("Categories/{id}")]
        public override IHttpActionResult Put([FromUri]int id,[FromBody]Category entity)
        {
            return base.Put(id, entity);
        }

        [Route("Categories/{id:int}")]
        public override IHttpActionResult Patch(object id, JsonPatchDocument<Category> patchData)
        {
            return base.Patch(id, patchData);
        }

        [Route("Categories/{id:int}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}