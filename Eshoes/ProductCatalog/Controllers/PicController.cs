using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Controllers
{
    [Produces("application/json")]         //this is what controller return.
    [Route("api/Pic")]                             //
    public class PicController : Controller
    {
        private readonly IHostingEnvironment _env;

        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetImage(int id)
        {
            var webroot = _env.WebRootPath;
            var path = Path.Combine(webroot + "/pics/", "shoes-" + id );
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/png");
        }
    }
}