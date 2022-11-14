

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.FoodRecipes;
    public class FoodRecipesController : AdministrationController
    {
        private readonly IFoodRecipesService foodRecipesService;
        private readonly ICloudinaryService cloudinaryService;

        public FoodRecipesController(
            IFoodRecipesService foodRecipesService,
            ICloudinaryService cloudinaryService)
        {
            this.foodRecipesService = foodRecipesService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new FoodRecipesListViewModel
            {
                FoodRecipes = await this.foodRecipesService.GetAllAsync<FoodRecipeViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddFoodRecipe()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodRecipe(FoodRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Title);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                imageUrl = GlobalConstants.Images.CloudinaryMissing;
            }
            var createdOn = DateTime.Now;
            await this.foodRecipesService.AddAsync(input.Title, input.Content, input.Author, imageUrl, createdOn);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodRecipe(int id)
        {
            await this.foodRecipesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
