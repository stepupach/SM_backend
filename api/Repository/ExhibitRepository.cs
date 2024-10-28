using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Exhibit;
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

        public async Task<Exhibit> DeleteAsync(int id)
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

        public async Task<List<Exhibit>> GetAllAsync()
        {
            return await _context.Exhibits.ToListAsync();
        }

        public async Task<Exhibit?> GetByIdAsync(int id)
        {
            return await _context.Exhibits.FindAsync(id);
        }

        public async Task<Exhibit?> UpdateAsync(int id, UpdateExhibitRequestDto exhibitDto)
        {
            var existingExhibit = await _context.Exhibits.FirstOrDefaultAsync(e => e.Id == id);

            if (existingExhibit == null)
            {
                return null;
            }

            existingExhibit.Title = exhibitDto.Title;
            existingExhibit.YearOfCreation = exhibitDto.YearOfCreation;
            existingExhibit.Price = exhibitDto.Price;
            existingExhibit.Technique = exhibitDto.Technique;
        
            await _context.SaveChangesAsync();
            return existingExhibit;
        }
    }
}