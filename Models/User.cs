using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill_Popper.Models
{
    public class User
    {

		private ObservableCollection<Medication> medicines = new ObservableCollection<Medication>();
		private String name;
		public ObservableCollection<MedAlarm> alarms = new ObservableCollection<MedAlarm>();

		public ObservableCollection<MedAlarm> Alarms
		{
			get { return alarms; }
			set { alarms = value; }
		}
		public ObservableCollection<Medication> Medicines
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
