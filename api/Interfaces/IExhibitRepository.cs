using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Exhibit;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IExhibitRepository // благодаря интерфейсам мы можем подключать код в других местах, абстрагирование
    {
        Task<List<Exhibit>> GetAllAsync(QueryObjectExhibit query);
        Task<Exhibit?> GetByIdAsync(int id);
        Task<Exhibit> CreateAsync(Exhibit exhibitModel);
        Task<Exhibit?> UpdateAsync(int id, UpdateExhibitPriceDto exhibitModel);
        Task<Exhibit?> SellAsync(int id);
        Task<Exhibit?> DeleteAsync(int id);
        Task<List<ExhibitWithSchoolOfPaintingDto>> GetExhibitWithSchoolOfPaintingAsync();
    }
}