using TechWiz.Models;

namespace TechWiz.Repositories
{
    public interface ITechnologyRepository
    {
        Task<Technology?> GetTechnologyByIdAsync(uint id);
    }
}