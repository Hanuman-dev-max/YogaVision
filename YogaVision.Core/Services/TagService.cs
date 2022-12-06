namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Tag;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    /// <summary>
    /// Service for Tag
    /// </summary>
    public class TagService : ITagService
    {
        private readonly IDeletableEntityRepository<Tag> tagsRepository;
        public TagService(IDeletableEntityRepository<Tag> tagsRepository)
        {
            this.tagsRepository = tagsRepository;
        }

        /// <summary>
        /// Adds tag
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Adds tags by their names
        /// </summary>
        /// <param name="tags">The names of the tags</param>
        /// <returns>List of int their Ids</returns>
        public async Task<ICollection<int>> AddRangeAsync(ICollection<string> tags)
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
        /// <summary>
        /// Deletes a tag by its Id
        /// </summary>
        /// <param name="Id">The Id of the tag</param>
        /// <returns></returns>
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
        /// <summary>
        /// Gets by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of the tag</param>
        /// <returns>Object of type T</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var tags =
                await this.tagsRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>().ToListAsync();
            return tags;
        }
        /// <summary>
        /// Gets by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of the tag</param>
        /// <returns>Object of type T</returns>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var tag =
                await this.tagsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return tag;
        }
        /// <summary>
        /// Gets tag by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name of the tag</param>
        /// <returns>Objecy of type T</returns>
        public async Task<T> GetByNameAsync<T>(string name)
        {
            var tag =
                await this.tagsRepository
                .AllAsNoTracking()
                .Where(x => x.Name == name)
                .To<T>().FirstOrDefaultAsync();
            return tag;
        }

        
    }
}
