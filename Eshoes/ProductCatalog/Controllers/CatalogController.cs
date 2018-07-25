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

namespace ProductCatalog.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _catalogContext;
     //   private readonly IOptionsSnapshot<CatalogSettings> _setting;
        public CatalogController(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
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
        [Route("[action]")]
        public async Task<IActionResult> Items([FromQuery] int pageSize=6,[FromQuery] int pageIndex=0)
        {

            var totalitems = await _catalogContext.CatalogItems.LongCountAsync();
            var itemsOnPage = await _catalogContext.CatalogItems.OrderBy(c=>c.Name)
                .Skip(pageSize * pageIndex).
                Take(pageSize).ToListAsync();
            itemsOnPage = changeUrl(itemsOnPage);
            return Ok(itemsOnPage);

        }
        private List<CatalogItem> changeUrl(List<CatalogItem> item)
        {
            item.ForEach(x => x.PictureUrl = x.PictureUrl.
            Replace("http://externalcatalogbaseurltobereplaced",
            "http://localhost:59180"));
           // _setting.Value.ExternalCatalogBaseUrl));
            return item;
        }
    }
}