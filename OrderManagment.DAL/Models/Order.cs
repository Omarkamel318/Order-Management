namespace OrderManagment.DAL.Models
{
	public class Order : BaseEntity
	{
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
		public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public OrderStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Discount { get; set; }
    }
}