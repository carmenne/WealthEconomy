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

    public abstract class BaseUserSectorRatingController : BaseController
    {
        public BaseUserSectorRatingController()
		{
			MainUnitOfWork = new UserSectorRatingUnitOfWork();		
		}

		protected UserSectorRatingUnitOfWork MainUnitOfWork { get; private set; }

        // GET odata/UserSectorRating
        [Queryable]
        public virtual IQueryable<UserSectorRating> Get()
        {
			var list = MainUnitOfWork.AllLive;
			using (var userUnitOfWork = new UserUnitOfWork())
			    list = list.Where(item => item.UserId == ApplicationUser.Id);
            return list;
        }

        // GET odata/UserSectorRating(5)
        [Queryable]
        public virtual SingleResult<UserSectorRating> Get([FromODataUri] int key)
        {
            return SingleResult.Create(MainUnitOfWork.AllLive.Where(userSectorRating => userSectorRating.Id == key));
        }

        // PUT odata/UserSectorRating(5)
        public virtual async Task<IHttpActionResult> Put([FromODataUri] int key, UserSectorRating userSectorRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != userSectorRating.Id)
            {
                return BadRequest();
            }

            MainUnitOfWork.Update(userSectorRating);

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

            return Updated(userSectorRating);
        }

        // POST odata/UserSectorRating
        public virtual async Task<IHttpActionResult> Post(UserSectorRating userSectorRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MainUnitOfWork.Insert(userSectorRating);

            try
            {
                await MainUnitOfWork.SaveAsync();
            }
            catch (DbUpdateException)
            {
                if (MainUnitOfWork.Exists(userSectorRating.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userSectorRating);
        }

        // PATCH odata/UserSectorRating(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<UserSectorRating> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userSectorRating = await MainUnitOfWork.FindAsync(key);
            if (userSectorRating == null)
            {
                return NotFound();
            }

            patch.Patch(userSectorRating);
            MainUnitOfWork.Update(userSectorRating);

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

            return Updated(userSectorRating);
        }

        // DELETE odata/UserSectorRating(5)
        public virtual async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var userSectorRating = await MainUnitOfWork.FindAsync(key);
            if (userSectorRating == null)
            {
                return NotFound();
            }

            MainUnitOfWork.Delete(userSectorRating.Id);
            await MainUnitOfWork.SaveAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

    public partial class UserSectorRatingController : BaseUserSectorRatingController
    {
	}
}