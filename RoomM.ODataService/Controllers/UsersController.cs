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
    public class UsersController : ODataController
    {
        private EFContext db = new EFContext();

        private bool UserExists(string key)
        {
            return this.db.Set<User>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<User> Get()
        {
            return this.db.Set<User>();
        }

        [EnableQuery]
        public SingleResult<User> Get([FromODataUri] string key)
        {
            IQueryable<User> result = this.db.Set<User>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<User>().Add(user);
            await this.db.SaveChangesAsync();
            return Created(user);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<User> user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<User>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            user.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, User update)
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
                if (!UserExists(key))
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
            var user = await this.db.Set<User>().FindAsync(key);
            if (user == null)
            {
                return NotFound();
            }
            db.Set<User>().Remove(user);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}