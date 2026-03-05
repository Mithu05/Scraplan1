using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Models.CityModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.SettingsModel;
//using Scraplan_dotnet.Repositiry.CityService;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SettingController(ISettingService settingService) : ControllerBase
    {
        private readonly ISettingService _settingService = settingService;


        [HttpGet("[action]")]
        public async Task<ServiceResponse<List<SettingResponseModel>>> GetAll()
        {
            return await _settingService.GetAllAsync();
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<SettingResponseModel>> Create(SettingRequestModel request)
        {
            return await _settingService.CreateAsync(request);
        }

        [HttpPut("[action]")]
        public async Task<ServiceResponse<SettingResponseModel>> Update(string key, SettingRequestModel request)
        {
            return await _settingService.UpdateAsync(key, request);
        }

        [HttpDelete("[action]")]
        public async Task<ServiceResponse<string>> Delete(string key)
        {
            return await _settingService.DeleteAsync(key);
        }
    }
}