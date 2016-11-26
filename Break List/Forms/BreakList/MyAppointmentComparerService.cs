using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler.Services.Internal;
using DevExpress.XtraScheduler;
using System.Reflection;

namespace Break_List.Forms.BreakList
{
    public class MyAppointmentComparerService : IExternalAppointmentCompareService
    {
        public MyAppointmentComparerService(string propertyName)
        {
            this.propertyName = propertyName;
        }

        string propertyName;

        #region IExternalAppointmentCompareService Members

        public IComparer<DevExpress.XtraScheduler.Appointment> Comparer
        {
            get { return new MyAppointmentComparer(propertyName); }
        }

        #endregion
    }

    public class MyAppointmentComparer : IComparer<Appointment>
    {
        public MyAppointmentComparer(string propertyName)
        {
            this.propertyName = propertyName;
        }

        string propertyName;

        public int Compare(Appointment x, Appointment y)
        {
            IComparable a = (IComparable)GetObject(x, propertyName);
            IComparable b = (IComparable)GetObject(y, propertyName);

            return a.CompareTo(b);
        }

        object GetObject(object obj, string propertyName)
        {
            Type t = obj.GetType();
            PropertyInfo p = t.GetProperty(propertyName);
            return p.GetValue(obj, null);
        }
    }
}
