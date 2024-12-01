using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Artist;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDBContext _context;
        
        public ArtistRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Artist>> GetAllAsync(QueryObjectArtist query)
        {
            var artists = _context.Artists.Include(e => e.Exhibits).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SchoolOfPainting))
            {
                artists = artists.Where(a => a.SchoolOfPainting.Contains(query.SchoolOfPainting));
            }

            if (!string.IsNullOrWhiteSpace(query.FullName))
            {
                artists = artists.Where(a => a.FullName.Contains(query.FullName));
            }

           if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("FullName", StringComparison.OrdinalIgnoreCase))
                {
                    artists = query.IsDescending ? artists.OrderByDescending(a => a.FullName) : artists.OrderBy(a => a.FullName);
                }
                else if (query.SortBy.Equals("SchoolOfPainting", StringComparison.OrdinalIgnoreCase))
                {
                    artists = query.IsDescending ? artists.OrderByDescending(a => a.SchoolOfPainting) : artists.OrderBy(a => a.SchoolOfPainting);
                }
                else if (query.SortBy.Equals("DateOfBirth", StringComparison.OrdinalIgnoreCase))
                {
                    artists = query.IsDescending ? artists.OrderByDescending(a => a.DateOfBirth) : artists.OrderBy(a => a.DateOfBirth);
                }
            }

            return await artists.ToListAsync();
        }


        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Artists.Include(e => e.Exhibits).FirstOrDefaultAsync(i => i.Id == id);
        }

         public async Task<Artist> CreateAsync(Artist artistModel)
        {
            await _context.Artists.AddAsync(artistModel);
            await _context.SaveChangesAsync();
            return artistModel;
        }

        public async Task<Artist> DeleteAsync(int id)
        {
            var artistModel = await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);

            if (artistModel == null)
            {
                return null;
            }

            _context.Artists.Remove(artistModel);
            await _context.SaveChangesAsync();
            return artistModel;
        }

        public async Task<Artist?> UpdateAsync(int id, UpdateArtistDto artistDto)
        {
            var existingArtist = await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);

            if (existingArtist == null)
            {
                return null;
            }

            existingArtist.FullName = artistDto.FullName;
            existingArtist.SchoolOfPainting = artistDto.SchoolOfPainting;
        
            await _context.SaveChangesAsync();
            return existingArtist;
        }

        public Task<bool> ArtistsExists(int id)
        {
            return _context.Artists.AnyAsync(a => a.Id == id);
        }

        public async Task<List<ArtistWithAvgPriceDto>> GetArtistWithAvrPriceAsync()
        {
            var artistsWithAvgPrice = from artist in _context.Artists
                select new ArtistWithAvgPriceDto
                {
                    FullName = artist.FullName,
                    AveragePrice = artist.Exhibits.Any() 
                        ? artist.Exhibits.Average(e => e.Price) 
                        : 0,
                    NumberOfWorks = artist.Exhibits.Count()
                };
            return await artistsWithAvgPrice.ToListAsync();
        }
    }
}