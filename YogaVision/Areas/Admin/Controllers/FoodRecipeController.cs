

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.FoodRecipe;
    public class FoodRecipeController : AdministrationController
    {
        private readonly IFoodRecipeService foodRecipeService;
        private readonly ICloudinaryService cloudinaryService;

        public FoodRecipeController(
            IFoodRecipeService foodRecipeService,
            ICloudinaryService cloudinaryService)
        {
            this.foodRecipeService = foodRecipeService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new FoodRecipesListViewModel
            {
                FoodRecipes = await this.foodRecipeService.GetAllAsync<FoodRecipeViewModel>(),
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
            await this.foodRecipeService.AddAsync(input.Title,input.RequiredProducts, input.Content, input.Author, imageUrl, createdOn);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodRecipe(int id)
        {
            await this.foodRecipeService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
