using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Artist;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllAsync(QueryObjectArtist query);
        Task<Artist?> GetByIdAsync(int id);
        Task<Artist> CreateAsync(Artist artistModel);
        Task<Artist?> UpdateAsync(int id, UpdateArtistDto artistDto);
        Task<Artist> DeleteAsync(int id);
        Task <bool> ArtistsExists(int id);
        Task<List<ArtistWithAvgPriceDto>> GetArtistWithAvrPriceAsync();
    }
}