using TechWiz.Models;
using TechWiz.Repositories;

namespace TechWiz.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<Technology?> GetTechnologyByIdAsync(uint id)
        {
            return await _technologyRepository.GetTechnologyByIdAsync(id);
        }
    }
}