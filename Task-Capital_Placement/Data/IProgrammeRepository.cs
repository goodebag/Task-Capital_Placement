using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;

namespace Task_Capital_Placement.Data
{
    public interface IProgrammeRepository
    {
        Task<Programme> Create(ProgrammeDto program);
        Task Delete(string programId);
        Task<Programme> GetByIdAsync(string programId);
        Task<IEnumerable<Programme>> GetAllAsync();
        Task<Programme> UpdateAsync( Programme program);
    }
}
