using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CMSProject.Utilities.Convertor
{
    public static class DataConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
