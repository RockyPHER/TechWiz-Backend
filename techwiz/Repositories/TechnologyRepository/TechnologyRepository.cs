using TechWiz.Database;
using TechWiz.Models;

namespace TechWiz.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly ApplicationDbContext _context;
        public TechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Technology?> GetTechnologyByIdAsync(uint id)
        {
            return await _context.Technologies.FindAsync(id);
        }

        public async Task<Technology> CreateTechnologyAsync(Technology technology)
        {
            _context.Add(technology);
            await _context.SaveChangesAsync();
            return technology;
        }
    }
}