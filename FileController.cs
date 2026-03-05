using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.FileModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(IFileService service) : ControllerBase
    {
        private readonly IFileService _service = service;

        [HttpPost("[action]")]
        public async Task<PagedResponse<List<FileResponseModel>>> GetPaged(PagedResponseInput input)
        {
            return await _service.GetPagedAsync(input);
        }

            [HttpGet("[action]")]
        public async Task<ServiceResponse<List<FileResponseModel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<FileResponseModel>> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<FileResponseModel>> Create(FileRequestModel model)
        {
            return await _service.CreateAsync(model);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<FileResponseModel>> Update(int id, FileUpdateModel model)
        {
            return await _service.UpdateAsync(id, model);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<FileResponseModel>> Delete(int id, int deletedBy)
        {
            return await _service.DeleteAsync(id, deletedBy);
        }
    }
}