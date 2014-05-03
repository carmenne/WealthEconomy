//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Controllers.OData
{
    using BusinessObjects;
    using Facade;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.Http.OData;

    [Authorize(Roles="Administrator")]
    public abstract class BaseResourcePoolController : BaseController
    {
        public BaseResourcePoolController()
		{
			MainUnitOfWork = new ResourcePoolUnitOfWork();		
		}

		protected ResourcePoolUnitOfWork MainUnitOfWork { get; private set; }

        // GET odata/ResourcePool
        [Queryable]
        public virtual IQueryable<ResourcePool> Get()
        {
			var list = MainUnitOfWork.AllLive;
            return list;
        }

        // GET odata/ResourcePool(5)
        [Queryable]
        public virtual SingleResult<ResourcePool> Get([FromODataUri] int key)
        {
            return SingleResult.Create(MainUnitOfWork.AllLive.Where(resourcePool => resourcePool.Id == key));
        }

        // PUT odata/ResourcePool(5)
        public virtual async Task<IHttpActionResult> Put([FromODataUri] int key, ResourcePool resourcePool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != resourcePool.Id)
            {
                return BadRequest();
            }

            MainUnitOfWork.Update(resourcePool);

            try
            {
                await MainUnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainUnitOfWork.Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(resourcePool);
        }

        // POST odata/ResourcePool
        public virtual async Task<IHttpActionResult> Post(ResourcePool resourcePool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MainUnitOfWork.Insert(resourcePool);

            try
            {
                await MainUnitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (MainUnitOfWork.Exists(resourcePool.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(resourcePool);
        }

        // PATCH odata/ResourcePool(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ResourcePool> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resourcePool = await MainUnitOfWork.FindAsync(key);
            if (resourcePool == null)
            {
                return NotFound();
            }

            patch.Patch(resourcePool);
            MainUnitOfWork.Update(resourcePool);

            try
            {
                await MainUnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainUnitOfWork.Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(resourcePool);
        }

        // DELETE odata/ResourcePool(5)
        public virtual async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var resourcePool = await MainUnitOfWork.FindAsync(key);
            if (resourcePool == null)
            {
                return NotFound();
            }

            MainUnitOfWork.Delete(resourcePool.Id);
            await MainUnitOfWork.SaveAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

    public partial class ResourcePoolController : BaseResourcePoolController
    {
	}
}