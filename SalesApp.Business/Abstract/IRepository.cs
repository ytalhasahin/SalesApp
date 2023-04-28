using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Business.Abstract
{
	public interface IRepository<Tentity> where Tentity : class, new()
	{
		List<Tentity> GetAll();
		Tentity Get(int id);
		void Add(Tentity entity);
		void Update(Tentity entity);
		void Delete(int id);
		void Delete(Tentity entity);
	}
}
