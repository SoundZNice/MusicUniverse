using Microsoft.AspNetCore.Mvc;
using MusicUniverse.Application.Albums.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicUniverse.WebPortal.Controllers
{
    public class AlbumController : BaseController
    {
        [HttpGet]
        [Route("api/artist/albums/{artistId}")]
        public async Task<IActionResult> GetByArtist(int artistId)
        {
            return Ok(await Mediator.Send(new GetAlbumsListByArtistQuery { ArtistId = artistId }));
        }
    }
}
