using Microsoft.AspNetCore.Mvc;
using ShopinextDotNet.Dtos.Requests;
using ShopinextDotNet.Dtos.Responses;
using ShopinextDotNet.Enumerations;
using ShopinextDotNet.Services;

namespace ShopinextDotNet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        [HttpGet("Send")]
        public async Task<IActionResult> Send([FromBody] PaymentRequest request)
        {
            var service = new BaseService(EnvironmentType.Production);

            var authenticateResponse = await service.PostAsync<AuthenticateRequest, AuthenticateResponse>("/authenticate", new AuthenticateRequest
            {
                ClientId = service.ApiClientId,
                ClientSecret = service.ApiClientSecret
            })!;

            service.SetAuthorization(authenticateResponse.Data?.AccessToken);

            var paymentResponse = await service.PostAsync<PaymentRequest, PaymentResponse>("/createPayment", request)!;
            
            return paymentResponse.Success ? Ok(paymentResponse.Data) : BadRequest(paymentResponse.Message);
        }
    }
}
