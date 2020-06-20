using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicUniverse.Application.Artists.Queries;

namespace MusicUniverse.WebPortal.Controllers
{
    public class ArtistController : BaseController
    {
        [HttpGet]
        [Route("api/artists")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await Mediator.Send(new ArtistsListQuery()));
        }
    }
}
