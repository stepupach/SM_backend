using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Exhibit;
using api.Models;

namespace api.Interfaces
{
    public interface IExhibitRepository // благодаря интерфейсам мы можем подключать код в других местах, абстрагирование
    {
        Task<List<Exhibit>> GetAllAsync();
        Task<Exhibit?> GetByIdAsync(int id);
        Task<Exhibit> CreateAsync(Exhibit exhibitModel);
        Task<Exhibit?> UpdateAsync(int id, UpdateExhibitRequestDto exhibitDto);
        Task<Exhibit> DeleteAsync(int id);
    }
}