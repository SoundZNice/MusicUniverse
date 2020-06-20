using MusicUniverse.Application.Common.Enums;
using MusicUniverse.Application.Common.Models;
using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepo)
        {
            _imageRepository = imageRepo;
        }

        public async Task<StatusCode> UploadImageAsync(ImageDto image)
        {
            if (await _imageRepository.HasNameDuplicateAsync(image.Name))
            {
                return StatusCode.DuplicateObject;
            }

            await _imageRepository.UploadAsync(
                image.Name, 
                image.Format,
                Convert.FromBase64String(image.Base64Content));

            return StatusCode.NoError;
        }
    }
}
