using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepo;

    public ItemsController(IItemRepository itemRepo)
    {
        _itemRepo = itemRepo;
    }

    [HttpGet]
    public IActionResult GetAll(int? userId)
    {
        return Ok(_itemRepo.GetAll(userId));
    }
}