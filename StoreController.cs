using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StoreModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreService service) : ControllerBase
    {
        private readonly IStoreService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<StoreResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<StoreResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();

        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<StoreResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<StoreResponseModel>> Create(StoreRequestModel model,long UserId)
        {
            return await _service.CreateAsync(model,UserId);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<StoreResponseModel>> Update(long id, StoreRequestModel model,long UserId)
        {
            return await _service.UpdateAsync(id, model,UserId);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<StoreResponseModel>> Delete(long id, long UserId)
        {
            return await _service.DeleteAsync(id,UserId);
        }

    }
}
