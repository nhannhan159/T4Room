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
    public class RoomsController : ODataController
    {
        private EFContext db = new EFContext();

        private bool RoomExists(string key)
        {
            return this.db.Set<Room>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Room> Get()
        {
            return this.db.Set<Room>();
        }

        [EnableQuery]
        public SingleResult<Room> Get([FromODataUri] string key)
        {
            IQueryable<Room> result = this.db.Set<Room>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<Room>().Add(room);
            await this.db.SaveChangesAsync();
            return Created(room);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Room> room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<Room>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            room.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, Room update)
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
                if (!RoomExists(key))
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
            var room = await this.db.Set<Room>().FindAsync(key);
            if (room == null)
            {
                return NotFound();
            }
            db.Set<Room>().Remove(room);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}