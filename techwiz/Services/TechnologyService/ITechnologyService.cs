using TechWiz.Models;

namespace TechWiz.Services
{
    public interface ITechnologyService
    {
        Task<Technology?> GetTechnologyByIdAsync(uint id); 
    }
}