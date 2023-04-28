using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Entity.Models
{
	public class Category
	{
		public Category()
		{
			Products = new List<Product>();
		}

		public Category(string name)
		{
			Name = name;
			Products = new List<Product>();
		}

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Product> Products { get; set; }
		//category.Products.Add(Product) => product.CategoryId = category.Id
	}
}
