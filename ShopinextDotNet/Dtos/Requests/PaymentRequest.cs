using Newtonsoft.Json;

namespace ShopinextDotNet.Dtos.Requests;

public class BillingInfo
{
    [JsonProperty("billing_firstname")]
    public string? BillingFirstname { get; set; }

    [JsonProperty("billing_surname")]
    public string? BillingSurname { get; set; }

    [JsonProperty("billing_address")]
    public string? BillingAddress { get; set; }

    [JsonProperty("billing_city")]
    public string? BillingCity { get; set; }

    [JsonProperty("billing_state")]
    public string? BillingState { get; set; }

    [JsonProperty("billing_postal_code")]
    public string? BillingPostalCode { get; set; }

    [JsonProperty("billing_country")]
    public string? BillingCountry { get; set; }

    [JsonProperty("billing_country_code")]
    public string? BillingCountryCode { get; set; }

    [JsonProperty("billing_phone")]
    public string? BillingPhone { get; set; }
}

public class OrderProduct
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("quantity")]
    public int? Quantity { get; set; }

    [JsonProperty("price")]
    public double? Price { get; set; }

    [JsonProperty("total")]
    public double? Total { get; set; }
}

public class PaymentRequest
{
    [JsonProperty("firstname")]
    public string? Firstname { get; set; }

    [JsonProperty("surname")]
    public string? Surname { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("amount")]
    public double? Amount { get; set; }

    [JsonProperty("currency")]
    public string? Currency { get; set; }

    [JsonProperty("max_installment")]
    public int? MaxInstallment { get; set; }

    [JsonProperty("merchant_order_id")]
    public string? MerchantOrderId { get; set; }

    [JsonProperty("identity_number")]
    public string? IdentityNumber { get; set; }

    [JsonProperty("company")]
    public string? Company { get; set; }

    [JsonProperty("tax_office")]
    public string? TaxOffice { get; set; }

    [JsonProperty("tax_number")]
    public string? TaxNumber { get; set; }

    [JsonProperty("is_digital")]
    public int? IsDigital { get; set; }

    [JsonProperty("order_products")]
    public List<OrderProduct>? OrderProducts { get; set; }

    [JsonProperty("billing_info")]
    public BillingInfo? BillingInfo { get; set; }

    [JsonProperty("shipping_info")]
    public ShippingInfo? ShippingInfo { get; set; }

    [JsonProperty("success_url")]
    public string? SuccessUrl { get; set; }

    [JsonProperty("fail_url")]
    public string? FailUrl { get; set; }

    [JsonProperty("callback_url")]
    public string? CallbackUrl { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }
}

public class ShippingInfo
{
    [JsonProperty("shipping_firstname")]
    public string? ShippingFirstname { get; set; }

    [JsonProperty("shipping_surname")]
    public string? ShippingSurname { get; set; }

    [JsonProperty("shipping_address")]
    public string? ShippingAddress { get; set; }

    [JsonProperty("shipping_city")]
    public string? ShippingCity { get; set; }

    [JsonProperty("shipping_state")]
    public string? ShippingState { get; set; }

    [JsonProperty("shipping_postal_code")]
    public string? ShippingPostalCode { get; set; }

    [JsonProperty("shipping_country")]
    public string? ShippingCountry { get; set; }

    [JsonProperty("shipping_country_code")]
    public string? ShippingCountryCode { get; set; }

    [JsonProperty("shipping_phone")]
    public string? ShippingPhone { get; set; }
}

