using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models
{
    public static class StatisticsHandler
    {
        #region Methods
        public static double CalculateAverageParameterValue(ObservableCollection<double> collection)
        {
            double avgValue = 0.0;

            if (collection.Count != 0)
            {
                foreach (double item in collection)
                {
                    avgValue += item;
                }

                avgValue /= collection.Count;
            }

            return Math.Truncate(avgValue);
        }

        public static ObservableCollection<StatisticalParameters> StatisticalParametersDictionaryToObservCollection(Dictionary<string, string> dictionary)
        {
            ObservableCollection<StatisticalParameters> statisticalParameters = new ObservableCollection<StatisticalParameters>();

            foreach (KeyValuePair<string, string> item in dictionary)
            {
                statisticalParameters.Add(new StatisticalParameters(item.Key, item.Value));
            }

            return statisticalParameters;
        }
        #endregion
    }
}
