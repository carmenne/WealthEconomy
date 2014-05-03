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

    public abstract class BaseUserLicenseRatingController : BaseController
    {
        public BaseUserLicenseRatingController()
		{
			MainUnitOfWork = new UserLicenseRatingUnitOfWork();		
		}

		protected UserLicenseRatingUnitOfWork MainUnitOfWork { get; private set; }

        // GET odata/UserLicenseRating
        [Queryable]
        public virtual IQueryable<UserLicenseRating> Get()
        {
			var list = MainUnitOfWork.AllLive;
			using (var userUnitOfWork = new UserUnitOfWork())
			    list = list.Where(item => item.UserId == ApplicationUser.Id);
            return list;
        }

        // GET odata/UserLicenseRating(5)
        [Queryable]
        public virtual SingleResult<UserLicenseRating> Get([FromODataUri] int key)
        {
            return SingleResult.Create(MainUnitOfWork.AllLive.Where(userLicenseRating => userLicenseRating.Id == key));
        }

        // PUT odata/UserLicenseRating(5)
        public virtual async Task<IHttpActionResult> Put([FromODataUri] int key, UserLicenseRating userLicenseRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != userLicenseRating.Id)
            {
                return BadRequest();
            }

            MainUnitOfWork.Update(userLicenseRating);

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

            return Updated(userLicenseRating);
        }

        // POST odata/UserLicenseRating
        public virtual async Task<IHttpActionResult> Post(UserLicenseRating userLicenseRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MainUnitOfWork.Insert(userLicenseRating);

            try
            {
                await MainUnitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (MainUnitOfWork.Exists(userLicenseRating.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userLicenseRating);
        }

        // PATCH odata/UserLicenseRating(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<UserLicenseRating> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLicenseRating = await MainUnitOfWork.FindAsync(key);
            if (userLicenseRating == null)
            {
                return NotFound();
            }

            patch.Patch(userLicenseRating);
            MainUnitOfWork.Update(userLicenseRating);

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

            return Updated(userLicenseRating);
        }

        // DELETE odata/UserLicenseRating(5)
        public virtual async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var userLicenseRating = await MainUnitOfWork.FindAsync(key);
            if (userLicenseRating == null)
            {
                return NotFound();
            }

            MainUnitOfWork.Delete(userLicenseRating.Id);
            await MainUnitOfWork.SaveAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

    public partial class UserLicenseRatingController : BaseUserLicenseRatingController
    {
	}
}
