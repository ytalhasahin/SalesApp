using SalesApp.Business.Concrete;
using SalesApp.DAL.Abstract;
using SalesApp.Entity.Context;
using SalesApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.DAL.Concrete
{
    public class OrderDAL:Repository<SalesDbContext,Order>,IOrderDAL
    {
    }
}
