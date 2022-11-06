namespace YogaVision.Core.Services
{

    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    using YogaVision.Core.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class FoodRecipesService :IFoodRecipesService
    {
        private readonly IDeletableEntityRepository<FoodRecipe> foodRecipesRepository;

        public FoodRecipesService(IDeletableEntityRepository<FoodRecipe> foodRecipesRepository)
        {
            this.foodRecipesRepository = foodRecipesRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<FoodRecipe> query =
                this.foodRecipesRepository
                .All()
                .OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }



            return await query.To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<FoodRecipe> query =
                this.foodRecipesRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn);

            if (sortId != null)
            {
                query = query
                    .Where(x => x.Id == sortId);
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).To<T>().ToListAsync();
        }

        public async Task<int> GetCountForPaginationAsync()
        {
            return await this.foodRecipesRepository
                .AllAsNoTracking()
                .CountAsync();

            // return await query.CountAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var foodRecipe =
                await this.foodRecipesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return foodRecipe;
        }

        public async Task AddAsync(string title, string content, string author, string imageUrl, DateTime createdOn)
        {
            await this.foodRecipesRepository.AddAsync(new FoodRecipe
            {
                Title = title,
                Content = content,
                Author = author,
                ImageUrl = imageUrl,
                CreatedOn = createdOn,
            });
            await this.foodRecipesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var foodRecipe =
                await this.foodRecipesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.foodRecipesRepository.Delete(foodRecipe);
            await this.foodRecipesRepository.SaveChangesAsync();
        }
    }


}

