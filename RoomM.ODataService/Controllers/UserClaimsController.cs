using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace RoomM.DataService.Controllers
{
    public class UserClaimsController : ODataController
    {
        private EFContext db = new EFContext();

        private bool UserClaimExists(string key)
        {
            return this.db.Set<UserClaim>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<UserClaim> Get()
        {
            return this.db.Set<UserClaim>();
        }

        [EnableQuery]
        public SingleResult<UserClaim> Get([FromODataUri] string key)
        {
            IQueryable<UserClaim> result = this.db.Set<UserClaim>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(UserClaim userClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<UserClaim>().Add(userClaim);
            await this.db.SaveChangesAsync();
            return Created(userClaim);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<UserClaim> userClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<UserClaim>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            userClaim.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserClaimExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] string key, UserClaim update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!key.Equals(update.Id))
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserClaimExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            var userClaim = await this.db.Set<UserClaim>().FindAsync(key);
            if (userClaim == null)
            {
                return NotFound();
            }
            db.Set<UserClaim>().Remove(userClaim);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}