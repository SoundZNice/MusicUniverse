using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicUniverse.Application.Home.Queries;

namespace MusicUniverse.WebPortal.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [Route("home")]
        public async Task<IActionResult> Home()
        {
            return Ok(await Mediator.Send(new HomePageQuery()));
        }
    }
}
