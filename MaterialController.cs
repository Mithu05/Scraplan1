using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.MaterialModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController(IMaterialService service) : ControllerBase
    {
        private readonly IMaterialService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<MaterialResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<MaterialResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<MaterialResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<MaterialResponseModel>> Create(MaterialRequestModel model, long UserId)
        {
            return await _service.CreateAsync(model,UserId);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<MaterialResponseModel>> Update(long id, MaterialRequestModel model, long UserId)
        {
            return await _service.UpdateAsync(id, model, UserId);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<MaterialResponseModel>> Delete(long id, long UserId)
        {
            return await _service.DeleteAsync(id,UserId);
        }
    }
}