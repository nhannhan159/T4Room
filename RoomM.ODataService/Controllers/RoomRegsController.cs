using RoomM.Domain.RoomModule.Aggregates;
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
    public class RoomRegsController : ODataController
    {
        private EFContext db = new EFContext();

        private bool RoomRegExists(string key)
        {
            return this.db.Set<RoomReg>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<RoomReg> Get()
        {
            return this.db.Set<RoomReg>();
        }

        [EnableQuery]
        public SingleResult<RoomReg> Get([FromODataUri] string key)
        {
            IQueryable<RoomReg> result = this.db.Set<RoomReg>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(RoomReg roomReg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<RoomReg>().Add(roomReg);
            await this.db.SaveChangesAsync();
            return Created(roomReg);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<RoomReg> roomReg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<RoomReg>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            roomReg.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomRegExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, RoomReg update)
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
                if (!RoomRegExists(key))
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
            var roomReg = await this.db.Set<RoomReg>().FindAsync(key);
            if (roomReg == null)
            {
                return NotFound();
            }
            db.Set<RoomReg>().Remove(roomReg);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}