namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Tag;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class TagService : ITagService
    {
        private readonly IDeletableEntityRepository<Tag> tagsRepository;
        public TagService(IDeletableEntityRepository<Tag> tagsRepository)
        {
            this.tagsRepository = tagsRepository;
        }

        public async Task<int> AddAsync(string name)
        {
            var tag = new Tag()
            {
                Name = name,
            };
            await this.tagsRepository.AddAsync(tag);
            await this.tagsRepository.SaveChangesAsync();
            return tag.Id;
        }

        public async Task<List<int>> AddRangeAsync(List<string> tags)
        {
            var tagIds = new List<int>();
            foreach (var tag in tags)
            {
                if (!this.tagsRepository.All().Any(t => t.Name == tag))
                {
                    var tagId = await AddAsync(tag);
                    tagIds.Add(tagId);
                }
                else
                {
                    var newTag = await GetByNameAsync<TagViewModel>(tag);
                    tagIds.Add(newTag.Id);
                }
            }
            return tagIds;
        }

        public async Task DeleteAsync(int id)
        {
            var tag =
               await this.tagsRepository
               .All()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
            this.tagsRepository.Delete(tag);
            await this.tagsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            var tags =
                await this.tagsRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>().ToListAsync();
            return tags;
        }

        public Task<IEnumerable<T>> GetAllWithPagingAsync<T>(int? sortId, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var tag =
                await this.tagsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return tag;
        }

        public async Task<T> GetByNameAsync<T>(string name)
        {
            var tag =
                await this.tagsRepository
                .AllAsNoTracking()
                .Where(x => x.Name == name)
                .To<T>().FirstOrDefaultAsync();
            return tag;
        }

        public Task<int> GetCountForPaginationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
