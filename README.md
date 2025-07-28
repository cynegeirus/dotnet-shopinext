# Shopinext .NET

**ShopinextDotNet** is a lightweight .NET 9 SDK and API wrapper built to integrate with the [Shopinext Payment API](https://api.shopinext.com/).  
This project provides a clean and extensible way to authenticate, initiate and manage payment transactions via Shopinext using a simple HTTP-based API approach.

## 🚀 Features

- ✅ Token-based authentication with Shopinext API  
- 💳 Create payment transactions easily  
- 🌐 Fully async and extendable  
- ⚙️ Environment configuration (Production / Sandbox)  
- 🧪 Built-in support for request/response DTOs  

## 🔧 Technologies Used

- .NET 9
- ASP.NET Core Web API  
- RESTful design  
- JSON-based serialization  
- Clean architecture and modular services  

## 📦 Installation

To get started:

```bash
git clone https://github.com/cynegeirus/dotnet-shopinext.git
cd dotnet-shopinext
dotnet build
````

> Make sure you have a valid Shopinext `ClientId` and `ClientSecret` from your Shopinext developer account.

### Code Snippet:

```csharp
[HttpGet("Send")]
public async Task<IActionResult> Send([FromBody] PaymentRequest request)
{
    var service = new BaseService(EnvironmentType.Production);

    var authenticateResponse = await service.PostAsync<AuthenticateRequest, AuthenticateResponse>("/authenticate", new AuthenticateRequest
    {
        ClientId = service.ApiClientId,
        ClientSecret = service.ApiClientSecret
    });

    service.SetAuthorization(authenticateResponse.Data?.AccessToken);

    var paymentResponse = await service.PostAsync<PaymentRequest, PaymentResponse>("/createPayment", request);
    
    return paymentResponse.Success ? Ok(paymentResponse.Data) : BadRequest(paymentResponse.Message);
}
```
## 🔐 Authentication Flow

1. Call `/authenticate` with your `ClientId` and `ClientSecret`.
2. Use the returned access token to authorize further requests.
3. Initiate payment via `/createPayment`.

## 📘 API Reference

You can explore the official Shopinext API here:
🔗 [https://api.shopinext.com/](https://api.shopinext.com/)

---

## 📜 License

This project is licensed under the [MIT License](LICENSE). See the license file for details.

---

## 🙌 Issues, Feature Requests or Support

Please use the Issue > New Issue button to submit issues, feature requests or support issues directly to me. You can also send an e-mail to akin.bicer@outlook.com.tr.
