using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroceryListsController : ControllerBase
    {
        private readonly IGroceryListRepository _groceryListRepo;

        public GroceryListsController(IGroceryListRepository groceryListRepo)
        {
            _groceryListRepo = groceryListRepo;
        }

        [HttpGet]
        public IActionResult Get(int? userId, bool? listItems, bool? isOpen)
        {
            return Ok(_groceryListRepo.GetAll(userId, listItems, isOpen));
        }
    }
}