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
    public class RoomTypesController : ODataController
    {
        private EFContext db = new EFContext();

        private bool RoomTypeExists(string key)
        {
            return this.db.Set<RoomType>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<RoomType> Get()
        {
            return this.db.Set<RoomType>();
        }

        [EnableQuery]
        public SingleResult<RoomType> Get([FromODataUri] string key)
        {
            IQueryable<RoomType> result = this.db.Set<RoomType>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(RoomType roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<RoomType>().Add(roomType);
            await this.db.SaveChangesAsync();
            return Created(roomType);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<RoomType> roomType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<RoomType>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            roomType.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, RoomType update)
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
                if (!RoomTypeExists(key))
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
            var roomType = await this.db.Set<RoomType>().FindAsync(key);
            if (roomType == null)
            {
                return NotFound();
            }
            db.Set<RoomType>().Remove(roomType);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}