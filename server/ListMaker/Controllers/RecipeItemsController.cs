using ListMaker.Models;
using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class RecipeItemsController : ControllerBase
{
    private readonly IRecipeItemRepository _recipeItemRepo;

    public RecipeItemsController(IRecipeItemRepository recipeItemRepo)
    {
        _recipeItemRepo = recipeItemRepo;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var recipeItem = _recipeItemRepo.GetById(id);
        if (recipeItem == null) return NotFound();
        return Ok(recipeItem);
    }

    [HttpPost]
    public IActionResult Post(RecipeItem recipeItem)
    {
        _recipeItemRepo.Add(recipeItem);
        return CreatedAtAction("GetById", new { id = recipeItem.Id }, recipeItem);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, RecipeItem recipeItem)
    {
        if (id != recipeItem.Id)
        {
            return BadRequest();
        }

        _recipeItemRepo.Update(recipeItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _recipeItemRepo.Delete(id);
        return NoContent();
    }
}