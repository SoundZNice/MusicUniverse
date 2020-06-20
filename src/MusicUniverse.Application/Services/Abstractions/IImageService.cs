using MusicUniverse.Application.Common.Enums;
using MusicUniverse.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services.Abstractions
{
    public interface IImageService
    {
        Task<StatusCode> UploadImageAsync(ImageDto image);
    }
}
