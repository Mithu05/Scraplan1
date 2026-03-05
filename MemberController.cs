using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.MaterialModel;
using Scraplan_dotnet.Models.MemberModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMemberService service) : ControllerBase
    {
        private readonly IMemberService _service = service;

        [HttpGet("[action]")]
        public async Task<PagedResponse<List<MemberResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<MemberResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<MemberResponseModel>> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<MemberResponseModel>> Create(MemberRequestModel model,long UserId)
        {
            return await _service.CreateAsync(model,UserId);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<MemberResponseModel>> Update(long id, MemberRequestModel model,long UserId)
        {
            return await _service.UpdateAsync(id, model,UserId);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<MemberResponseModel>> Delete(long id, int UserId)
        {
            return await _service.DeleteAsync(id,UserId);
        }
    }
}