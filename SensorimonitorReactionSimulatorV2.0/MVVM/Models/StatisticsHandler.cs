using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models
{
    class StatisticsHandler
    {
        #region Methods
        public double CalculateAverageClickTime(List<double> clickTimeList)
        {
            double avgClickTimeSum = 0.0;

            if(clickTimeList.Count != 0)
            {
                foreach(double time in clickTimeList)
                {
                    avgClickTimeSum += time;
                }

                avgClickTimeSum /= clickTimeList.Count;
            }

            return Math.Truncate(avgClickTimeSum);
        }
        #endregion
    }
}
