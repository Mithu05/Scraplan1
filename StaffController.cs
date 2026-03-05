using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StaffModel;
using Scraplan_dotnet.Models.StateModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController(IStaffService service) : ControllerBase
    {
        private readonly IStaffService _service = service;


        [HttpPost("[action]")]
        public async Task<PagedResponse<List<StaffResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<StaffResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();

        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<StaffResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<StaffResponseModel>> Create(StaffRequestModel model)
        {
            return await _service.CreateAsync(model);

        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<StaffResponseModel>>Update(long id, StaffRequestModel model, long modifiedBy)
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<StaffResponseModel>> Delete(long id, long deletedBy)
        {
            return await _service.DeleteAsync(id,deletedBy);
        }
    }
}
