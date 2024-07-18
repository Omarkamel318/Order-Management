using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.Models
{
	public class Invoice :BaseEntity
	{
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public Order order { get; set; }
    }
}
