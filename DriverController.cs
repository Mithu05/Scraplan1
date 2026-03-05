using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.DriverModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StateModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController(IDriverService service) : ControllerBase
    {
        private readonly IDriverService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<DriverResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }



        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<DriverResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<DriverResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }


        [HttpPost("[action]")]
        public async Task<ServiceResponse<DriverResponseModel>> Create(DriverRequestModel model)
        {
           return await _service.CreateAsync(model);
        }

       
        [HttpPut("[action]")]
        public async Task<ServiceResponse<DriverResponseModel>> Update(long id, DriverRequestModel model,int modifiedBy)
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

       
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<DriverResponseModel>> Delete(long id,int deletedBy)
        {
            return await _service.DeleteAsync(id,deletedBy);

        }
    }

}