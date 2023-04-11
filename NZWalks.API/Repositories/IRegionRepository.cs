using NZWalks.API.Models.Domain;
using System.Runtime.InteropServices;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        //Nullable region (?)
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        //Nullable region (?)
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
