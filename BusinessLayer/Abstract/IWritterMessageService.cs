﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IWritterMessageService : IGenericService<WritterMessage>
	{
		List<WritterMessage> TGetListSenderMessage(string p);
		List<WritterMessage> TGetListReceiverMessage(string p);
	}
}
