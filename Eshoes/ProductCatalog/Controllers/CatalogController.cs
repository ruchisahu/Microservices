using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductCatalog.Data;
using ProductCatalog.Domain;
using ProductCatalog.ViewModel;

namespace ProductCatalog.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _catalogContext;
        private readonly IOptionsSnapshot<CatalogSetting> _setting;
        public CatalogController(CatalogContext catalogContext, IOptionsSnapshot<CatalogSetting> setting)
        {
            _catalogContext = catalogContext;
            _setting = setting;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var items = await _catalogContext.CatalogTypes.ToListAsync();
                return Ok(items);

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogBrands()
        {
            var items = await _catalogContext.CatalogBrands.ToListAsync();
            return Ok(items);

        }

        

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            if(id<=0)
            {
                return BadRequest();
            }
            var item = await _catalogContext.CatalogItems.SingleOrDefaultAsync(c => c.Id==id);
                if(item !=null)
            {
                item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _setting.Value.ExternalCatalogBaseUrl);
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery] int pageSize = 6, [FromQuery] int pageIndex = 0)
        {

            var totalitems = await _catalogContext.CatalogItems.LongCountAsync();
            var itemsOnPage = await _catalogContext.CatalogItems.OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex).
                Take(pageSize).ToListAsync();
            itemsOnPage = changeUrl(itemsOnPage);
            var model = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalitems, itemsOnPage);
            return Ok(model);

        }

        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Items(string name, [FromQuery] int pageSize = 6, [FromQuery] int pageIndex = 0)
        {

            var totalitems = await _catalogContext.CatalogItems.Where(c => c.Name.StartsWith(name)).LongCountAsync();

            var itemsOnPage = await _catalogContext.CatalogItems.Where(c => c.Name.StartsWith(name))
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex).
                Take(pageSize).ToListAsync();
            itemsOnPage = changeUrl(itemsOnPage);
            var model = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalitems, itemsOnPage);
            return Ok(model);

        }


        [HttpGet]
        [Route("[action]/type/{catalogTypeId}/brand/{catalogBrandId}")]
        public async Task<IActionResult> Items(int? catalogTypeId, int? catalogBrandId, [FromQuery] int pageSize = 6, [FromQuery] int pageIndex = 0)
        {
            var root = (IQueryable<CatalogItem>)_catalogContext.CatalogItems;

            if (catalogTypeId.HasValue)
            {
                root = root.Where(c => c.CatalogTypeId == catalogTypeId);
            }
            if (catalogBrandId.HasValue)
            {
                root = root.Where(c => c.CatalogTypeId == catalogBrandId);
            }
            var totalitems = await root.LongCountAsync();

            var itemsOnPage = await root
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex).
                Take(pageSize).ToListAsync();
            itemsOnPage = changeUrl(itemsOnPage);
            var model = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalitems, itemsOnPage);
            return Ok(model);

        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateProduct([FromBody] CatalogItem Product)
        {

            var item = new CatalogItem
            {
                CatalogBrandId = Product.CatalogBrandId,
                CatalogTypeId = Product.CatalogTypeId,
                Description = Product.Description,
                Name = Product.Name,
                Price = Product.Price
            };
            _catalogContext.CatalogItems.Add(item);
            await _catalogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id });

        }


        [HttpPut]
        [Route("items")]
        public async Task<IActionResult> UpdateProduct([FromBody] CatalogItem ProductToUpdate)
        {

            var catalogitem = await _catalogContext.CatalogItems.SingleOrDefaultAsync(c => c.Id == ProductToUpdate.Id);

            if (catalogitem == null)
            {
                return NotFound(new { Message = $"Item with id {ProductToUpdate.Id} not found" });
            }
            catalogitem = ProductToUpdate;
            _catalogContext.CatalogItems.Update(catalogitem);
            await _catalogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemById), new { id = ProductToUpdate.Id });

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product = await _catalogContext.CatalogItems.SingleOrDefaultAsync(c => c.Id ==id);

            if (product == null)
            {
                return NotFound();
            }
           // catalogitem = catalogItems.Remove(product);
            _catalogContext.CatalogItems.Remove(product);
            await _catalogContext.SaveChangesAsync();
            return NoContent();

        }

        private List<CatalogItem> changeUrl(List<CatalogItem> item)
        {
            item.ForEach(x => x.PictureUrl = x.PictureUrl.
            Replace("http://externalcatalogbaseurltobereplaced",
             _setting.Value.ExternalCatalogBaseUrl));
            //  "http://localhost:59180"));

            return item;
        }
    }
}