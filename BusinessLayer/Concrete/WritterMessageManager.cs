using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WritterMessageManager : IWritterMessageService
	{
		IWritterMessageDal _writterMessageDal;

		public WritterMessageManager(IWritterMessageDal writterMessageDal)
		{
			_writterMessageDal = writterMessageDal;
		}

		public void TAdd(WritterMessage t)
		{
			_writterMessageDal.Insert(t);
		}

		public void TDelete(WritterMessage t)
		{
			_writterMessageDal.Delete(t);
		}

		public WritterMessage TGetByID(int id)
		{
			return _writterMessageDal.GetByID(id);
		}

		public List<WritterMessage> TGetList()
		{
			return _writterMessageDal.GetList();
		}

		public List<WritterMessage> TGetListReceiverMessage(string p)
		{
			return _writterMessageDal.GetByFilter(x => x.Receiver == p);
		}

		public List<WritterMessage> TGetListSenderMessage(string p)
		{
			return _writterMessageDal.GetByFilter(x => x.Sender == p);
		}

		public void TUpdate(WritterMessage t)
		{
			_writterMessageDal.Update(t);
		}
	}
}
