using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.RateModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StaffModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RateController(IRateService service) : ControllerBase
    {
        private readonly IRateService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<RateResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpGet("[action]")]

        public async Task<ServiceResponse<List<RateResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<RateResponseModel>> Get(long id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<RateResponseModel>> Create(RateRequestModel model, long createdBy)
        {
            return await _service.CreateAsync(model,createdBy);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<RateResponseModel>> Update(long id, RateRequestModel model, long modifiedBy)
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<RateResponseModel>> Delete(long id, long deletedBy)
        {
            return await _service.DeleteAsync(id,deletedBy);
        }
    }
}
