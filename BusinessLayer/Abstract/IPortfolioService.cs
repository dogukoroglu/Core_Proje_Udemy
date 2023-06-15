using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Abstract
{
	public interface IPortfolioService : IGenericService<Portfolio>
	{
		void PortfolioStatusChangeTrue(int id);
		void PortfolioStatusChangeFalse(int id);
	}
}
