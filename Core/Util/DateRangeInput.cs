using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util
{
    public class DateRangeInput
    {
        public DateTime StartHoliday { get; private set; }
        public DateTime EndHoliday { get; private set; }

        public DateRangeInput(DateTime _startHoliday, DateTime _endHoliday)
        {
            this.StartHoliday = _startHoliday;
            this.EndHoliday = _endHoliday;
        }
    }
}
