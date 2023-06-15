using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer.EntityFramework
{
	public class EfPortfoiloDal : GenericRepository<Portfolio>, IPortfolioDal
	{
		public void PortfolioStatusChangeFalse(int id)
		{
			using var c = new Context();
			Portfolio portfolio = c.Portfolios.Find(id);
			portfolio.Status = false;
			c.SaveChanges();
		}

		public void PortfolioStatusChangeTrue(int id)
		{
			using var c = new Context();
			Portfolio portfolio = c.Portfolios.Find(id);
			portfolio.Status = true;
			c.SaveChanges();
		}
	}
}
