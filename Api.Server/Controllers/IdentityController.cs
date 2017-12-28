using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Identity")]
    public class IdentityController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(User.Claims.Select(x => new { x.Type, x.Value }));
        }
    }
}