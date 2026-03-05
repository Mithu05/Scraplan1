using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.BlogModel;
using Scraplan_dotnet.Models.IssueModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IssueController(IIssueService service) : ControllerBase
    {
        private readonly IIssueService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<IssueResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }



        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<IssueResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

       
        [HttpGet("[action]")]
        public async Task<ServiceResponse<IssueResponseModel>> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        
        [HttpPost("[action]")]
        public async Task<ServiceResponse<IssueResponseModel>> Create(IssueRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

        
        [HttpPut("[action]")]
        public async Task<ServiceResponse<IssueResponseModel>> Update(int id, IssueRequestModel model)
        {
            return await _service.UpdateAsync(id, model);
        }

       
        [HttpDelete("[action]")]
        public async Task<ServiceResponse<IssueResponseModel>> Delete(int id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}