using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill_Popper.Models
{
    class User
    {

		private List<Medication> medicines = new List<Medication>();
		private String name;

		public List<Medication> Medicines
		{
			get { return medicines; }
			set { medicines = value; }
		}
		public String Name
		{
			get { return name; }
			set { name = value; }
		}



	}
}
