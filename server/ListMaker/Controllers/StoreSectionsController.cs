using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class StoreSectionsController : ControllerBase
{
    private readonly IStoreSectionRepository _storeSectionRepo;

    public StoreSectionsController(IStoreSectionRepository storeSectionRepo)
    {
        _storeSectionRepo = storeSectionRepo;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_storeSectionRepo.GetAll());
    }
}