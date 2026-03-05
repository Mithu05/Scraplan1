using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.VehicleModel;
using Scraplan_dotnet.Models.VendorModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(IVehicleService service) : ControllerBase
    {
        private readonly IVehicleService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<VehicleResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpPost("[action]")]
        public async Task<ServiceResponse<VehicleResponseModel>> Create(VehicleRequestModel model, long createdBy)
        {
            return await _service.CreateAsync(model,createdBy);
        }



        [HttpGet("[action]")]
       public async Task<ServiceResponse<VehicleResponseModel>> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }



        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<VehicleResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }



        [HttpPut("[action]")]
       public async Task<ServiceResponse<VehicleResponseModel>> Update(int id, VehicleRequestModel model, long modifiedBy)
        {
            return await _service.UpdateAsync(id, model, modifiedBy);
        }



        [HttpDelete("[action]")]
        public async Task<ServiceResponse<bool>> Delete(int id, long deletedBy)
        {
            return await _service.DeleteAsync(id, deletedBy);
        }

    }
}
