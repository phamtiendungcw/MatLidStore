using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public TagRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<bool> IsTagNameUniqueAsync(string name)
        {
            return !await _context.Tags.AnyAsync(t => t.Name == name);
        }

        public override async Task CreateAsync(Tag entity)
        {
            if (!await IsTagNameUniqueAsync(entity.Name))
            {
                throw new InvalidOperationException("Tag name must be unique.");
            }

            await base.CreateAsync(entity);
        }

        public override async Task UpdateAsync(Tag entity)
        {
            if (!await IsTagNameUniqueAsync(entity.Name))
            {
                throw new InvalidOperationException("Tag name must be unique.");
            }

            await base.UpdateAsync(entity);
        }
    }
}