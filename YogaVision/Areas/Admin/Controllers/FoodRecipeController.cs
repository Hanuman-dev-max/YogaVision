namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.FoodRecipe;
    /// <summary>
    /// Contoller responsible for FoodRecipe model in Admin Area
    /// </summary>
    public class FoodRecipeController : AdministrationController
    {
        private readonly IFoodRecipeService foodRecipeService;
        private readonly ICloudinaryService cloudinaryService;
        /// <summary>
        /// Contructor of FoodRecipeController
        /// </summary>
        /// <param name="foodRecipeService">Interface of type IFoodRecipeService</param>
        /// <param name="cloudinaryService">Interface of typeICloudinaryService </param>
        public FoodRecipeController(
            IFoodRecipeService foodRecipeService,
            ICloudinaryService cloudinaryService)
        {
            this.foodRecipeService = foodRecipeService;
            this.cloudinaryService = cloudinaryService;
        }

        /// <summary>
        /// Displays the Index View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = new FoodRecipesListViewModel
            {
                FoodRecipes = await this.foodRecipeService.GetAllAsync<FoodRecipeViewModel>(),
            };
            return this.View(viewModel);
        }

        /// <summary>
        /// Displays AddFoodRecipe Views
        /// </summary>
        /// <returns></returns>
        public IActionResult AddFoodRecipe()
        {
            return this.View();
        }

        /// <summary>
        /// HttpPost Methot which handles adding of FoodRecipe
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
            await this.foodRecipeService.AddAsync(input.Title,input.RequiredProducts, input.Content, input.Author, imageUrl);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// HttpPost Method which handle deleting a FoodRecipe
        /// </summary>
        /// <param name="id">The Id of the FoodRecipe</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteFoodRecipe(int id)
        {
            await this.foodRecipeService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
