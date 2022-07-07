using Stripe;
using Stripe.Checkout;

namespace EcommerceBlazor.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51LIyo9LYmNBx8CcYZl7Ved0koApcglpmvcZpI5MxSzI93fDfmbGVlyhgXEWxN6MpoPnkalKOCfMk2lyHd7rKtycP001TP6hgrx";


            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            //products of a user currently in the cart
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            //add products to a Stripe Session
            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100, //that's how stripe works
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity
            }));

            //options of the session
            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                PaymentMethodTypes = new List<string>
                {
                    "card" //googlepay & applepay
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7057/order-success", //move to if success
                CancelUrl = "https://localhost:7057/cart" //move to if failure
            };

            var service = new SessionService();
            //create session
            Session session = service.Create(options);
            return session;
        }
    }
}
