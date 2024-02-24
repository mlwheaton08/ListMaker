﻿using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepo;

        public RecipesController(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        [HttpGet]
        public IActionResult GetAll(int? userId, bool listItems)
        {
            return Ok(_recipeRepo.GetAll(userId, listItems));
        }

        [HttpGet("{id}", Name = "GetRecipeById")]
        public IActionResult GetById(int id)
        {
            var recipe = _recipeRepo.GetById(id);
            if (recipe != null) return Ok(recipe);
            return BadRequest();
        }
    }
}
