using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util
{
    public class NationalHoliday
    {
        public DateTime Date { get; private set; }
        public string LocalName { get; private set; }
        
        public NationalHoliday(DateTime _date, string _localName)
        {
            Date = _date;   
            LocalName = _localName;
        }

    }
}
