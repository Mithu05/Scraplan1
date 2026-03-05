using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.BlogModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
        public class BlogController(IBlogService service) : ControllerBase
        {
            private readonly IBlogService _service = service;


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<BlogResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<BlogResponseModel>> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<BlogResponseModel>> Create( BlogRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<BlogResponseModel>> Update(int id, BlogUpdateModel model)
        {
            return await _service.UpdateAsync(id, model);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<BlogResponseModel>> Delete(int id, int deletedBy)
        {
            return await _service.DeleteAsync(id, deletedBy);
        }
    }
}