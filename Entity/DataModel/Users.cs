using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
	public class Users : BaseModel
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public string EMail { get; set; }
		public string Password { get; set; }
		public int? City { get; set; }
		public int? Town { get; set; }
		public DateTime BirthDate { get; set; }


	}
}
