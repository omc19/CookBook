using CookBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookBook.Services;
using CookBook.Models.DTO;

namespace CookBook.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{

		public readonly RecipeContext _dbContext;
		public readonly IRecipeService _recipeService;

		public RecipesController(RecipeContext dbContext, IRecipeService recipeService)
		{
			_dbContext = dbContext;
			_recipeService = recipeService;
		}

		//GET: api/Recipes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
		{
			if (_dbContext.Recipes == null)
			{
				return NotFound();
			}

			return await _dbContext.Recipes.ToListAsync();
		}

		//GET: api/Recipes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Recipe>> GetRecipe(int id)
		{
			if (_dbContext.Recipes == null)
			{
				return NotFound();
			}

			var recipe = await _dbContext.Recipes.FindAsync(id);

			if (recipe == null)
			{
				return NotFound();
			}

			return recipe;
		}

		//POST: api/Recipes
		[HttpPost]
		public async Task<ActionResult<Recipe>> PostRecipe(RecipeDto recipeDto)
		{
			ActionResult<Recipe> recipe = await _recipeService.PostRecipeAsync(recipeDto);

			return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Value.RecipeId }, recipe);	
		
		}
	}
}
