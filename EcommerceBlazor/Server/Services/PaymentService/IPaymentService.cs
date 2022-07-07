using Stripe.Checkout;

namespace EcommerceBlazor.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
    }
}
