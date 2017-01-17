
using System;

namespace Break_List.Class
{
    public class TimeScaleFixedInterval : DevExpress.XtraScheduler.TimeScaleFixedInterval
    {
        readonly TimeSpan _start;
        readonly TimeSpan _end;

        public TimeScaleFixedInterval(TimeSpan span, TimeSpan spanStart, TimeSpan spanEnd) : base(span)
        {
            Width = 35;
            _start = spanStart;
            _end = spanEnd;
        }

        public override DateTime Floor(DateTime date)
        {
            if (date.TimeOfDay < _start)
                return date.Date.AddDays(-1) + _end - Value;
            if (date.TimeOfDay == _start)
                return date;
            if (date.TimeOfDay == _end)
                return date;
            var result = base.Floor(date);
            if (result.TimeOfDay > _end)
                return date.Date + _end;
            if (result.TimeOfDay < _start)
                return result.Date + _start;
            return result;
        }

        public override DateTime GetNextDate(DateTime date)
        {
            if (date.TimeOfDay == _start)
                date = base.Floor(date);
            var result = base.GetNextDate(date);
            if (result.TimeOfDay >= _end)
                return result.Date.AddDays(1) + _start;
            if (result.TimeOfDay <= _start)
                return result + _start;
            return result;
        }

        public override string FormatCaption(DateTime start, DateTime end)
        {
            return start.ToString(Value == TimeSpan.FromDays(1) ? "d ddd" : "HH:mm");
        }
    }
}
