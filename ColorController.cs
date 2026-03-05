using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.BlogModel;
using Scraplan_dotnet.Models.ColorModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{ }
[Route("api/[controller]")]
[ApiController]

public class ColorController(IColorService service) : ControllerBase
{
    private readonly IColorService _service = service;


    [HttpGet("[action]")]
    public async Task<ServiceResponse<List<ColorResponseModel>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("[action]")]
    public async Task<ServiceResponse<ColorResponseModel>> Get(int id)
    {
        return await _service.GetByIdAsync(id);
    }

    [HttpPost("[action]")]
    public async Task<ServiceResponse<ColorResponseModel>> Create(ColorRequestModel model)
    {
        return await _service.CreateAsync(model);
    }

    [HttpPut("[action]")]
    public async Task<ServiceResponse<ColorResponseModel>> Update(int id, ColorRequestModel model)
    {
        return await _service.UpdateAsync(id, model);
    }

    [HttpDelete("[action]")]
    public async Task<ServiceResponse<ColorResponseModel>> Delete(int id)
    {
        return await _service.DeleteAsync(id);
    }
}

