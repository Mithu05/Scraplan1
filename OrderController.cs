using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.OrderModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService service) : ControllerBase
    {
        private readonly IOrderService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<OrderResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<OrderResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

      
        [HttpGet("[action]")]
        public async Task<ServiceResponse<OrderResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }

       
        [HttpPost("[action]")]
        public async Task<ServiceResponse<OrderResponseModel>> Create( OrderRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

       
        [HttpPut("[action]")]
        public async Task<ServiceResponse<OrderResponseModel>> Update(long id, OrderRequestModel model,long modifiedBy)
      
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

        
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<OrderResponseModel>> Delete(long id, long deletedBy)
        {
            return await _service.DeleteAsync(id,deletedBy);
        }
    }
}
