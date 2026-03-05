using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StoreModel;
using Scraplan_dotnet.Models.VendorModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController(IVendorService service) : ControllerBase
    {
        private readonly IVendorService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<VendorResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpPost("[action]")]
        public async Task<ServiceResponse<VendorResponseModel>> Create(VendorRequestModel model,long createdBy)
        {
            return await _service.CreateAsync(model,createdBy);
        }


     
        [HttpGet("[action]")]
        public async Task<ServiceResponse<VendorResponseModel>> GetById(long id)
        {
            return await _service.GetAsync(id);
        }

      
      
        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<VendorResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

      
       
        [HttpPut("[action]")]
        public async Task<ServiceResponse<VendorResponseModel>> Update(long id, VendorRequestModel model,long modifiedBy)
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

       
      
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<VendorResponseModel>> Delete(long id,long UserId)
        {
            return await _service.DeleteAsync(id,UserId);
        }
       
    }
}