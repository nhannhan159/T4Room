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
    public class AssetsController : ODataController
    {
        private EFContext db = new EFContext();

        private bool AssetExists(string key)
        {
            return this.db.Set<Asset>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Asset> Get()
        {
            return this.db.Set<Asset>();
        }

        [EnableQuery]
        public SingleResult<Asset> Get([FromODataUri] string key)
        {
            IQueryable<Asset> result = this.db.Set<Asset>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<Asset>().Add(asset);
            await this.db.SaveChangesAsync();
            return Created(asset);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Asset> asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<Asset>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            asset.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, Asset update)
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
                if (!AssetExists(key))
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
            var asset = await this.db.Set<Asset>().FindAsync(key);
            if (asset == null)
            {
                return NotFound();
            }
            db.Set<Asset>().Remove(asset);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}