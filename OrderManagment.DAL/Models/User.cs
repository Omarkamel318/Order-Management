using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.DAL.Models
{
	public class User : BaseEntity
	{
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
