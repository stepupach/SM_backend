using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Artist;
using api.Dtos.Exhibit;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ExhibitRepository : IExhibitRepository
    {
        private readonly ApplicationDBContext _context;
        public ExhibitRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Exhibit> CreateAsync(Exhibit exhibitModel)
        {
            await _context.Exhibits.AddAsync(exhibitModel);
            await _context.SaveChangesAsync();
            return exhibitModel;
        }

        public async Task<Exhibit?> DeleteAsync(int id)
        {
            var exhibitModel = await _context.Exhibits.FirstOrDefaultAsync(e => e.Id == id);

            if (exhibitModel == null)
            {
                return null;
            }

            _context.Exhibits.Remove(exhibitModel);
            await _context.SaveChangesAsync();
            return exhibitModel;
        }

        public async Task<List<Exhibit>> GetAllAsync(QueryObjectExhibit query)
        {
            var exhibits = _context.Exhibits.AsQueryable();
            if (query.MinPrice !=0 || query.MaxPrice!= 0)
            {
                exhibits = exhibits.Where(e => e.Price >= query.MinPrice & e.Price <= query.MaxPrice);
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    exhibits = query.IsDescending ? exhibits.OrderByDescending(e => e.Price) : exhibits.OrderBy(e => e.Price);
                }
                else if (query.SortBy.Equals("YearOfCreation", StringComparison.OrdinalIgnoreCase))
                {
                    exhibits = query.IsDescending ? exhibits.OrderByDescending(e => e.YearOfCreation) : exhibits.OrderBy(e => e.YearOfCreation);
                }
                // switch (query.SortBy.ToLower())
                // {
                //     case "price":
                //     {
                //         exhibits = query.IsDescending ? exhibits.OrderByDescending(e => e.Price) : exhibits.OrderBy(e => e.Price);
                //         break;
                //     }
                // }
            }

            if (query.Sold)
            {
                exhibits = exhibits.Where(e => e.DateOfSale != DateOnly.MinValue);
            }


            return await exhibits.ToListAsync();
        }

        public async Task<Exhibit?> GetByIdAsync(int id)
        {
            return await _context.Exhibits.FindAsync(id);
        }

        public async Task<Exhibit?> UpdateAsync(int id, UpdateExhibitPriceDto exhibitModel)
        {
            var existingExhibit = await _context.Exhibits.FindAsync(id);

            if (existingExhibit == null)
            {
                return null;
            }

            existingExhibit.Price = exhibitModel.Price;
        
            await _context.SaveChangesAsync();
            return existingExhibit;
        }

        public async Task<Exhibit?> SellAsync(int id)
        {
            var existingExhibit = await _context.Exhibits.FindAsync(id);

            if (existingExhibit == null)
            {
                return null;
            }

            existingExhibit.DateOfSale = DateOnly.FromDateTime(DateTime.Now);
        
            await _context.SaveChangesAsync();
            return existingExhibit;
        }

        public async Task<List<ExhibitWithSchoolOfPaintingDto>> GetExhibitWithSchoolOfPaintingAsync()
        {
            var exhibitWithSchoolOfPainting = from exhibit in _context.Exhibits
                join artist in _context.Artists on exhibit.ArtistId equals artist.Id 
                select new ExhibitWithSchoolOfPaintingDto
                {
                    Title = exhibit.Title,
                    YearOfCreation = exhibit.YearOfCreation,
                    FullName = artist.FullName,
                    SchoolOfPainting = artist.SchoolOfPainting
                };
            return await exhibitWithSchoolOfPainting.ToListAsync();
        }
    }
}