using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace globothai.Utils
{
    public class TimeUtils
    {
        public bool TimeBetween(string timeToCompare, string startTime, string endTime)
        {
            int clearedTimeToCompare = int.Parse(timeToCompare.Remove(2, 1));
            int clearedStartTime = int.Parse(startTime.Remove(2, 1));
            int clearedEndTime = int.Parse(endTime.Remove(2, 1));

            bool compareTime = clearedTimeToCompare >= clearedStartTime && clearedTimeToCompare <= clearedEndTime;

            return compareTime;
        }
    }
}
