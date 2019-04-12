using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
	public class Town : BaseModel
	{
		public string Name { get; set; }

		public int CityId { get; set; }

		public virtual City City { get; set; }

	}
}
