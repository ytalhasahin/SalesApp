using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Entity.Models
{
	public class Customer
	{
		public Customer()
		{
			Orders = new List<Order>();
		}

		public Customer(string name, string surname, string city)
		{
			Name = name;
			Surname = surname;
			City = city;
			Orders = new List<Order>();
		}

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string City { get; set; }
		public List<Order> Orders { get; set; }
	}
}
