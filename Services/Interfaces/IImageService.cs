
using Blog23.ViewModels;
using Blog23.Services;
using Blog23.Services.Interfaces;

namespace Blog23.Services.Interfaces
{
    public interface IImageService
    {
        public Task<byte[]> EncodeImageAsync(IFormFile file);
        public Task<byte[]> EncodeImageAsync(string fileName);
        string DecodeImage(byte[] data, string type);
        string ContentType(IFormFile file);
        int Size(IFormFile file);
    }
}