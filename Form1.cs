using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ShopifySharp;
using ShopifySharp.Filters;

namespace ShopifyIntegrations;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        GetShopify();
    }

    public string StoreName = "softray-test";

    public string ShopifyStoreAccessToken { get; set; }

    public string ShopifyUrl => $"https://{StoreName}.myshopify.com/api/2022-04/graphql.json";

    public async Task<string> GetShopify()
    {
        // To use NewtonsoftJsonSerializer, add a reference to NuGet package GraphQL.Client.Serializer.Newtonsoft
        var graphQLClient = new GraphQLHttpClient(ShopifyUrl, new NewtonsoftJsonSerializer());
        graphQLClient.HttpClient.DefaultRequestHeaders.Add("X-Shopify-Storefront-Access-Token",
            "19952c4772a91e40838f28bb85a59bc0");

        var personAndFilmsRequest = new GraphQLRequest
        {
            Query =
                @"mutation checkoutCompleteWithCreditCardV2($checkoutId: ID!, $payment: CreditCardPaymentInputV2!) {
  checkoutCompleteWithCreditCardV2(checkoutId: $checkoutId, payment: $payment) {
    checkout {
      id
        email
orderStatusUrl
    }
    checkoutUserErrors {
      field
        message
    }
    payment {
      id
    }
  }
}",
            OperationName = "checkoutCompleteWithCreditCardV2",
            Variables = new
            {
                checkoutId = "123455",
                payment = new CheckoutInput.Payment()
                {
                    Test = true,
                    VaultId = "test123",
                    BillingAddress = new CheckoutInput.BillingAddress()
                    {
                        Address1 = "My address",
                        City = "Tuzla",
                        Phone = "+38762867735",
                        FirstName = "Mirzet",
                        LastName = "Karahodzic",
                        Zip = "75000",
                        Company = "Softray Solutions",
                        Country = "Bosnia and Herzegovina"
                    },
                    IdempotencyKey = "ajkdljfadf",
                    PaymentAmount = new CheckoutInput.PaymentAmount()
                    {
                        Amount = "35.00",
                        CurrencyCode = "USD"
                    }
                    
                }
            }
        };
        try
        {
            
            var result = await graphQLClient.SendMutationAsync<GraphQLResponse<string>>(personAndFilmsRequest);
            String res123 = null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return "true";
    }
}