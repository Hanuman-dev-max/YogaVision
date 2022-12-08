namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.FoodRecipe;
    using YogaVision.Core.Services;
    using YogaVision.Infrastructure.Data.Models;

    public class FoodRecipeServiceTests : BaseServiceTests
    {
        private IFoodRecipeService Service => this.ServiceProvider.GetRequiredService<IFoodRecipeService>();

        [Fact]
        public async Task GetCountForPaginationAsyncShouldReturnCorrectCount()
        {
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();

            var expected = this.DbContext.FoodRecipes.Where(x => !x.IsDeleted).ToArray().Count();
            var actual = await this.Service.GetCountForPaginationAsync();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateFoodRecipeAsync();

            var title = new NLipsum.Core.Sentence().ToString();
            var requiredProduct = new NLipsum.Core.Paragraph().ToString();
            var content = new NLipsum.Core.Paragraph().ToString();
            var author = new NLipsum.Core.Word().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(title, requiredProduct, content, author, imageUrl);

            var foodRecipesCount = await this.DbContext.FoodRecipes.CountAsync();
            Assert.Equal(2, foodRecipesCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var foodRecipe = await this.CreateFoodRecipeAsync();

            await this.Service.DeleteAsync(foodRecipe.Id);

            var foodRecipesCount = this.DbContext.FoodRecipes.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedFoodRecipe = await this.DbContext.FoodRecipes.FirstOrDefaultAsync(x => x.Id == foodRecipe.Id);
            Assert.Equal(0, foodRecipesCount);
            Assert.Null(deletedFoodRecipe);
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var foodRecipe = await this.CreateFoodRecipeAsync();

            //Act
            var actualFoodRecipe = await this.Service.GetByIdAsync<FoodRecipeViewModel>(foodRecipe.Id);
            //Assert
            Assert.Equal(foodRecipe.Title, actualFoodRecipe.Title);
        }

        [Fact]
        public async Task GetAllWithPagingAsyncShouldReturnCorrectly()
        {
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();
            await this.CreateFoodRecipeAsync();


            var actual = await this.Service.GetAllWithPagingAsync<FoodRecipeViewModel>(null, 3, 1);
            Assert.Equal(3, actual.Count());
        }
        private async Task<FoodRecipe> CreateFoodRecipeAsync()
        {
            var foodRecipe = new FoodRecipe
            {
                Title = new NLipsum.Core.Sentence().ToString(),
                RequiredProducts = new NLipsum.Core.Paragraph().ToString(),
                Content = new NLipsum.Core.Paragraph().ToString(),
                Author = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
            };

            await this.DbContext.FoodRecipes.AddAsync(foodRecipe);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<FoodRecipe>(foodRecipe).State = EntityState.Detached;
            return foodRecipe;
        }
    }
}