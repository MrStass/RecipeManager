using Microsoft.AspNetCore.Mvc;
using RecipeManager.Database;
using RecipeManager.Models;

namespace RecipeManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var recipes = _context.Recipes.ToList();
                if (recipes.Count == 0)
                {
                    return NotFound("Рецепт не знайдено");
                }
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var recipes = _context.Recipes.Find(id);
                if (recipes == null)
                {
                    return NotFound("Recipe not found with id");
                }
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Recipe model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Рецет збережено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut] 
        public IActionResult Put(Recipe model) 
        { 
            if (model == null || model.Id == 0)
            {
                if(model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if(model.Id == 0)
                {
                    return BadRequest($"Recipe Id {model.Id} is invalid");
                }
            }
            try
            {
                var recipe = _context.Recipes.Find(model.Id);
                if (recipe == null)
                {
                    return NotFound($"Recipe not found with id {model.Id}");
                }
                recipe.Name = model.Name;
                recipe.Description = model.Description;
                recipe.Ingridients = model.Ingridients;         
                _context.SaveChanges();
                return Ok("Рецепт оновлено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var recipe = _context.Recipes.Find(id);
                if (recipe == null)
                {
                    return NotFound($"Recipe not found with id {id}");
                }
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
                return Ok("рецепт видалено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}