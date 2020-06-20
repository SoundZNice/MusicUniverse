using Microsoft.AspNetCore.Mvc;
using MusicUniverse.Application.Common.Models;
using MusicUniverse.Application.Images.Commands;
using System.Threading.Tasks;

namespace MusicUniverse.WebPortal.Controllers
{
    public class ImageController : BaseController
    {
        [HttpPost]
        [Route("api/image")]
        public async Task<IActionResult> UploadImages([FromBody] ImageDto[] images)
        {
            return Ok(await Mediator.Send(new UploadImagesCommand { Images = images }));
        }
    }
}
