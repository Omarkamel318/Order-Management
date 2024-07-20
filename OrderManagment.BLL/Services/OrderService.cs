using AutoMapper;
using OrderManagment.BLL.DTO;
using OrderManagment.BLL.Iservices;
using OrderManagment.DAL.Data;
using OrderManagment.DAL.IRepository;
using OrderManagment.DAL.Models;
using OrderManagment.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.BLL.Services
{
    public class OrderService : IOrderService
	{
        private readonly IOrderRepository _orderRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<OrderItem> _orderItemRepo;
        private readonly IGenericRepository<Invoice> _invoiceRepo;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService
            (IOrderRepository orderRepo,
			 IGenericRepository<Product> productRepo,
			 IGenericRepository<OrderItem> orderItemRepo,
			 IGenericRepository<Invoice> invoiceRepo,
			 ApplicationDbContext dbContext,
             IMapper mapper)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _orderItemRepo = orderItemRepo;
            _invoiceRepo = invoiceRepo;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderReturnDto?> CreateOrder(OrderDto orderDto)
        {
            Product? product; List<OrderItem> orderItems = new();
            foreach (var item in orderDto.Items)
            {
                product = await _productRepo.GetAsync(item.ProductId);
                if (product is not null && product.Stock >= item.Quantity)
                {
                    OrderItem orderItem = new()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Discount = item.Discount,
                        UnitPrice = product.Price
                    };
                    orderItems.Add(orderItem);
                    product.Stock -= item.Quantity;
                    _productRepo.Update(product);
                }
                else
                    return null;
            }

            decimal totalOrderPrice; decimal totalDiscount = 0;

            totalOrderPrice = orderItems.Sum(o => o.UnitPrice * o.Quantity - o.Discount);

            if (totalOrderPrice >= 100)
                totalDiscount = totalOrderPrice * 0.05m;

            if (totalOrderPrice >= 200)
                totalDiscount = totalOrderPrice * 0.1m;

            OrderReturnDto order = new()
            {
                CustomerId = orderDto.CustomerId,
                Date = DateTime.Now,
                PaymentMethod = orderDto.PaymentMethod,
                Items = orderItems,
                Total = totalOrderPrice,
                Discount = totalDiscount,
                TotalAmount = totalOrderPrice - totalDiscount
            };

            Invoice invoice = new()
            {
                Date = DateTime.Now,
                order = _mapper.Map<Order>(order),
                TotalAmount = order.TotalAmount,
            };

            _orderRepo.Add(_mapper.Map<Order>(order));

            foreach (var item in orderItems)
                _orderItemRepo.Add(item);

            _invoiceRepo.Add(invoice);

            var result = _dbContext.SaveChanges();
            if (result <= 0)
                return null;

            return order;
        }

        public async Task<Order> GetOrderAsync(int id)
            => await _orderRepo.GetAsyncWithIncludeItem(id);


        public async Task<IReadOnlyList<Order>> GetAllOrderAsync() //Auth
            => await _orderRepo.GetAllAsyncWithIncludeItems();

        //auth
        public async Task<Order?> UpdateStatus(int id, OrderStatus status)
        {
            var order = await GetOrderAsync(id);
            if (order is null)
                return null;
            order.Status = status;
            _orderRepo.Update(order);
            _dbContext.SaveChanges();
            return order;
        }

    }
}
