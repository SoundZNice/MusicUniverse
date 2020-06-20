using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories.Abstractions
{
    public interface IImageRepository
    {
        Task UploadAsync(string name, string format, byte[] content);

        Task<bool> HasNameDuplicateAsync(string name);
    }
}
