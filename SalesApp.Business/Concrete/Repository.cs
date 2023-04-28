using SalesApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Business.Concrete
{
	public class Repository<Tcontext, Tentity> : IRepository<Tentity> where Tentity : class, new() where Tcontext : DbContext, new()
	{
		
		public void Add(Tentity entity)
		{
			using(var db = new Tcontext())
			{
				db.Set<Tentity>().Add(entity);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new Tcontext())
			{
				Tentity entity = db.Set<Tentity>().Find(id);
				db.Set<Tentity>().Remove(entity);
				db.SaveChanges() ;
			}
		}

		public void Delete(Tentity entity)
		{
			using (var db = new Tcontext())
			{
				db.Set<Tentity>().Remove(entity);
				db.SaveChanges();
			}
		}

		public Tentity Get(int id)
		{
			using (var db = new Tcontext())
			{
				var entity = db.Set<Tentity>().Find(id);
				return entity;
			}
		}

		public List<Tentity> GetAll()
		{
			using (var db = new Tcontext())
			{
				return db.Set<Tentity>().ToList();
			}
		}

		public void Update(Tentity entity)
		{
			using (var db = new Tcontext())
			{
				db.Entry(entity).State = EntityState.Modified;
				db.SaveChanges();
			}
		}
	}
}
