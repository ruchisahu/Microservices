using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalog.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalog.Controllers
{
    [Produces("application/json")]
    [Route("api/Catalog")]
    public class CatalogController : Controller
    {
        private readonly EventCatalogContext _catalogContext;

        public CatalogController(EventCatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var items = await _catalogContext.Eventcatalogs.ToListAsync();
            return Ok(items);

        }
    }
}