
using Blog23.ViewModels;
using Blog23.Services;
using Blog23.Services.Interfaces;

namespace Blog23.Services.Interfaces
{
    public interface IImageService
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileData, string extension);
    }
}
