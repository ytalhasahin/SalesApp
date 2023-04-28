using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Entity.Models
{
	public class Order
	{
		public Order()
		{
		}

		public Order(DateTime orderDate, int quantity)
		{
			OrderDate = orderDate;
			Quantity = quantity;
		}

		[Key]
		public int Id { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public int Quantity { get; set; }
		public double TotalPrice { get; set; }

	}
}
