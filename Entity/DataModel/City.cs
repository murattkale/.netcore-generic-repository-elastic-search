using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
	public class City : BaseModel
	{
		public string Name { get; set; }

		public virtual ICollection<Town> Towns { get; set; }

	}
}
