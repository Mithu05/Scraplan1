using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Controllers;
using Scraplan_dotnet.Models.BlogModel;
using Scraplan_dotnet.Models.OrderDetailModel;
using Scraplan_dotnet.Models.OrderLogModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers

{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderLogController(IOrderLogService service) : ControllerBase
{
    private readonly IOrderLogService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<OrderLogResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<IEnumerable<OrderLogResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<OrderLogResponseModel>> Get(long id)
        {
            return await _service.GetByIdAsync(id);
        }

      
        [HttpPost("[action]")]
        public async Task<ServiceResponse<OrderLogResponseModel>> Create(OrderLogRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

       
        [HttpPut("[action]")]
        public async Task<ServiceResponse<OrderLogResponseModel>> Update(long id, OrderLogRequestModel model, long modifiedBy)
        {
            return await _service.UpdateAsync(id, model,modifiedBy);
        }

        
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<string>> Delete(long id, long userId)
        {
            return await _service.DeleteAsync(id, userId);
        }
    }
}