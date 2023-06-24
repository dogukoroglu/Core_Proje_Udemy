using System;

namespace Core_Proje_Udemy.Areas.Writter.Models
{
	public class WritterMessageImageUrl
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string SenderName { get; set; }
		public string MessageContent { get; set; }
		public string ImageUrl { get; set; }
	}
}
