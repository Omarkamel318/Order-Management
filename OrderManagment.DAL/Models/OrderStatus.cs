namespace OrderManagment.DAL.Models
{
	public enum OrderStatus : byte
	{
		Pending,
		PaymentRecieved,
		PaymentFailed
	}
}