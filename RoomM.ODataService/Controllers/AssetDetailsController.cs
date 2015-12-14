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
    public class AssetDetailsController : ODataController
    {
        private EFContext db = new EFContext();

        private bool AssetDetailExists(string key)
        {
            return this.db.Set<AssetDetail>().Any(p => key.Equals(p.Id));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<AssetDetail> Get()
        {
            return this.db.Set<AssetDetail>();
        }

        [EnableQuery]
        public SingleResult<AssetDetail> Get([FromODataUri] string key)
        {
            IQueryable<AssetDetail> result = this.db.Set<AssetDetail>().Where(p => key.Equals(p.Id));
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(AssetDetail assetDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.db.Set<AssetDetail>().Add(assetDetail);
            await this.db.SaveChangesAsync();
            return Created(assetDetail);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<AssetDetail> assetDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await this.db.Set<AssetDetail>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            assetDetail.Patch(entity);
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetDetailExists(key))
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

        public async Task<IHttpActionResult> Put([FromODataUri] string key, AssetDetail update)
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
                if (!AssetDetailExists(key))
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
            var assetDetail = await this.db.Set<AssetDetail>().FindAsync(key);
            if (assetDetail == null)
            {
                return NotFound();
            }
            db.Set<AssetDetail>().Remove(assetDetail);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}