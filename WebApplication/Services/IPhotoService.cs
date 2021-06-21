using System;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IPhotoService
    {
        Task<Guid> AddPhotoAsync(PhotoItemViewModel photo, string ownerId);
        Task<PhotoItemViewModel[]> GetPhotosAsync(string ownerId);
    }
}