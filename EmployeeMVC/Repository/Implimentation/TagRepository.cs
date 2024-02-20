using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Repository.Implimentation
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TagRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;      
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await _applicationDbContext.Tags.AddAsync(tag);
            await _applicationDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await _applicationDbContext.Tags.FindAsync(id);

            if(existingTag != null)
            {
                _applicationDbContext.Tags.Remove(existingTag);
                await _applicationDbContext.SaveChangesAsync();
                return existingTag; 
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        { 
            return await _applicationDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
           return await _applicationDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await _applicationDbContext.Tags.FindAsync(tag.Id);

            if(existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await _applicationDbContext.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }
    }
}
