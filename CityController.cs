using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.CityModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StateModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(ICityService cityService) : ControllerBase
    {
        private readonly ICityService _cityService = cityService;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<CityResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _cityService.GetPagedAsync(input);
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<CityResponseModel>>> GetAll()
        {
            return await _cityService.GetAllAsync();
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<CityResponseModel>> Create(CityRequestModel model, int UserId)
        {
            return await _cityService.CreateAsync(model,UserId);
        }

      
        [HttpGet("[action]")]
        public async Task<ServiceResponse<CityResponseModel>> GetById(long id)
        {
            return await _cityService.GetByIdAsync(id);
        }

        
        [HttpPut("[action]")]
        public async Task<ServiceResponse<CityResponseModel>> Update(long id, CityRequestModel model,int UserId)
        {
            return await _cityService.UpdateAsync(id, model,UserId);
        }

     
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<CityResponseModel>> Delete(long id,int UserId)
        {
            return await _cityService.DeleteAsync(id,UserId);
        }
    }
}
