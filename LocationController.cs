using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.LocationModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        public class LocationController(ILocationService service) : ControllerBase
        {
            private readonly ILocationService _service = service;

        [HttpPut("[action]")]
        public async Task<PagedResponse<List<LocationResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }

       
        [HttpGet("[action]")]
        public async Task<ServiceResponse<LocationResponseModel>> GetById(int id)
        {
            return await _service.GetAsync(id);
        }

       
        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<LocationResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }


        [HttpPost("[action]")]
        public async Task<ServiceResponse<LocationResponseModel>> Create(LocationRequestModel model, int createdBy)
        {
            return await _service.CreateAsync(model, createdBy);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<LocationResponseModel>> Update(int id, LocationRequestModel model,int modifiedBy)
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

      
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<LocationResponseModel>> Delete(int id, int deletedBy)
        {
            return await _service.DeleteAsync(id,deletedBy);
        }
    }
}