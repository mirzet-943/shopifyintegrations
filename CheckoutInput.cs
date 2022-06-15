namespace ShopifyIntegrations;

public class CheckoutInput
{
    public class BillingAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string Zip { get; set; }
    }

    public class Payment
    {
        public BillingAddress BillingAddress { get; set; }
        public string IdempotencyKey { get; set; }
        public PaymentAmount PaymentAmount { get; set; }
        public bool Test { get; set; }
        public string VaultId { get; set; }
    }

    public class PaymentAmount
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class Root
    {
        public string CheckoutId { get; set; }
        public Payment Payment { get; set; }
    }
}