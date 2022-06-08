using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pagesTest.Backend
{
    public class Time
    {
        private int hour;
        private int minute;

        public Time()
        {
            hour = 0;
            minute = 0;
        }

        public bool setTime(int hour, int minute)
        {
            if (hour < -1 && hour > 24 && minute < -1 && minute > 60)
            {
                this.hour = hour;
                this.minute = minute;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string toString()
        {
            string result;
            result = hour + ":" + minute;
            return result;
        }
    }
}
