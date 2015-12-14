using RoomM.Domain.AssetModule.Aggregates;
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
    public class AssetHistoriesController : ODataController
    {
        private EFContext db = new EFContext();

        private bool AssetHistoryExists(string key)
        {
            return this.db.Set<AssetHistory>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<AssetHistory> Get()
        {
            return this.db.Set<AssetHistory>();
        }

        [EnableQuery]
        public SingleResult<AssetHistory> Get([FromODataUri] string key)
        {
            IQueryable<AssetHistory> result = this.db.Set<AssetHistory>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(AssetHistory assetHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<AssetHistory>().Add(assetHistory);
            await this.db.SaveChangesAsync();
            return Created(assetHistory);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<AssetHistory> assetHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<AssetHistory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            assetHistory.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetHistoryExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, AssetHistory update)
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
                if (!AssetHistoryExists(key))
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
            var assetHistory = await this.db.Set<AssetHistory>().FindAsync(key);
            if (assetHistory == null)
            {
                return NotFound();
            }
            db.Set<AssetHistory>().Remove(assetHistory);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}