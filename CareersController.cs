using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.CareersModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
      
        public class CareersController(ICareerService service) : ControllerBase
        {
            private readonly ICareerService _service = service;



        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<CareersResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<CareersResponseModel>> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<CareersResponseModel>> Create(CareersRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<CareersResponseModel>> Update(int id, CareersRequestModel model)
        {
            return await _service.UpdateAsync(id, model);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<CareersResponseModel>> Delete(int id, int deletedBy)
        {
            return await _service.DeleteAsync(id, deletedBy);
        }
    }
}
