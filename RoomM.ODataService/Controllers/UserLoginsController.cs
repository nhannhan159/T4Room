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
    public class UserLoginsController : ODataController
    {
        private EFContext db = new EFContext();

        private bool UserLoginExists(string key)
        {
            return this.db.Set<UserLogin>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<UserLogin> Get()
        {
            return this.db.Set<UserLogin>();
        }

        [EnableQuery]
        public SingleResult<UserLogin> Get([FromODataUri] string key)
        {
            IQueryable<UserLogin> result = this.db.Set<UserLogin>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<UserLogin>().Add(userLogin);
            await this.db.SaveChangesAsync();
            return Created(userLogin);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<UserLogin> userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<UserLogin>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            userLogin.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, UserLogin update)
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
                if (!UserLoginExists(key))
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
            var userLogin = await this.db.Set<UserLogin>().FindAsync(key);
            if (userLogin == null)
            {
                return NotFound();
            }
            db.Set<UserLogin>().Remove(userLogin);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}