using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scraplan_dotnet.Entities;
using Scraplan_dotnet.Models.AccountModel;
using Scraplan_dotnet.Models.ResponseModel;
using Scraplan_dotnet.Models.ResponseModel.ResponseConstants;
using Scraplan_dotnet.Repositiry.IServices;

namespace Scraplan_dotnet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        

        [HttpPost("[action]")]
        public async Task<ServiceResponse<LoginResponseModel>> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return new(400, ResponseConstant.BadRequest);

            return await _accountService.Login(model);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResponse<RegisterResponseModel>> Register(RegisterModel Model)
        {
            if (!ModelState.IsValid)
                return new(400, ResponseConstant.BadRequest);

            return await _accountService.Register(Model);
        }


        [HttpPost("[action]")]
        public async Task<ServiceResponse<ResetResponseModel>> ResetPassword(ResetModel model)
        {
            if (!ModelState.IsValid)
                return new ServiceResponse<ResetResponseModel>(400, "Bad Request");

            return await _accountService.ResetPassword(model);

        }

        [HttpGet("[action]")]
        public async Task<ServiceResponse<LogOutResponseModel>> logout()
        {
            return await _accountService.Logout();
        }


        [HttpGet("[action]")]
        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            if (!ModelState.IsValid)
                return new(400, ResponseConstant.BadRequest);
            return await _accountService.GetUserById(id);
        }
    }           
}