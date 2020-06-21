using Microsoft.AspNetCore.Mvc;
using MusicUniverse.Application.Compositions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicUniverse.WebPortal.Controllers
{
    public class CompositionController : BaseController
    {
        [HttpGet]
        [Route("api/artist/compositions/{artistId}")]
        public async Task<IActionResult> GetByArtist(int artistId)
        {
            return Ok(await Mediator.Send(new CompositionsByArtistQuery { ArtistId = artistId }));
        }
    }
}
