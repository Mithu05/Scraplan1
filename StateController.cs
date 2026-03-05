using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.CityModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.StateModel;
using Scraplan_dotnet.Models.StoreModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IStateService service) : ControllerBase
    {
        private readonly IStateService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<StateResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<StateResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<StateResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<StateResponseModel>> Create(StateRequestModel model, long UserId)
        {
            return await _service.CreateAsync(model,UserId);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<StateResponseModel>> Update(long id, StateRequestModel model, long UserId)
        {
            return await _service.UpdateAsync(id, model,UserId);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<StateResponseModel>> Delete(long id, int UserId)
        {
            return await _service.DeleteAsync(id, UserId);
        }
    }
}