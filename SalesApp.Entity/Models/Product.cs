using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Entity.Models
{
	public class Product
	{
		public Product()
		{
			Orders = new List<Order>();
		}
		public Product(string name, double price, int stock)
		{
			Name = name;
			Price = price;
			Stock = stock;
			Orders = new List<Order>();
		}

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public List<Order> Orders { get; set; }
	}
}
