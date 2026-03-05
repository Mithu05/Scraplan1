using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.OrderDetailModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;
using Scraplan_dotnet.Repositiry.Services;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController(IOrderDetailService service) : ControllerBase
    {
        private readonly IOrderDetailService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<OrderDetailResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<OrderDetailResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<OrderDetailResponseModel>>  Get(long id)
        { 
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<OrderDetailResponseModel>> Create(OrderDetailRequestModel model)
        { 

            return await _service.CreateAsync(model);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<OrderDetailResponseModel>> Update(long id, OrderDetailRequestModel model,long modifiedBy)
        {
            return await _service.UpdateAsync(id,model,modifiedBy);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<string>> Delete(long id, long deletedBy)
        { 
            return await _service.DeleteAsync(id,deletedBy);
        }
    }
}