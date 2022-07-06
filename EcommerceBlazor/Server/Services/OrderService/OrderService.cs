using System.Security.Claims;

namespace EcommerceBlazor.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(DataContext context,
            ICartService cartService,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() =>
            int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            //first get cart products
            var products = (await _cartService.GetDbCartProducts()).Data;

            //count total price of the cart products
            decimal totalPrice = 0;
            products.ForEach(p => totalPrice += p.Price * p.Quantity);

            //put all products from the cart
            //to the List<OrderItems>
            //one by one
            var orderItems = new List<OrderItem>();
            products.ForEach(p => orderItems.Add(new OrderItem
            {
                ProductId = p.ProductId,
                ProductTypeId = p.ProductTypeId,
                Quantity = p.Quantity,
                TotalPrice = p.Price * p.Quantity
            }));

            //create an order
            var order = new Order
            {
                UserId = GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            //add order to the Db table and save changes
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
