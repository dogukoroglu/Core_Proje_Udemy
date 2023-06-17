using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class ToDoListPanel :ViewComponent
	{
		ToDoListManager toDoListManager = new ToDoListManager(new EfToDoListDal());
		public IViewComponentResult Invoke()
		{
			var values = toDoListManager.TGetList();
			return View(values);
		}
	}
}
