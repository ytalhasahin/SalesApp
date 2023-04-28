using SalesApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Entity.Context
{
	public class SalesDbContext:DbContext
	{
		DbSet<Category> Categories { get; set; }
		DbSet<Customer> Customers { get; set; }
		DbSet<Order> Orders { get; set; }
		DbSet<Product> Products { get; set;}
	}
}
