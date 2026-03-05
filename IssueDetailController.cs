using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.IssueDetailModel;
using Scraplan_dotnet.Models.IssueModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IssueDetailController(IIssueDetailService service) : ControllerBase
    {
        private readonly IIssueDetailService _service = service;


        [HttpPost("[action]")]
        public async Task<PagedResponse<List<IssueDetailResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<IssueDetailResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<IssueDetailResponseModel>> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<IssueDetailResponseModel>> Create(IssueDetailRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<IssueDetailResponseModel>> Update(int id, IssueDetailRequestModel model)
        {
            return await _service.UpdateAsync(id, model);
        }


        [HttpDelete("[action]")]
        public async Task<ServiceResponse<IssueDetailResponseModel>> Delete(int id)
        {
            return await _service.DeleteAsync(id);
        }

    }
}
