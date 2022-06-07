using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class LevelStatistics
    {
        #region Properties
        public string LevelTitle { get; set; } = "Null";
        public string LevelID { get; set; } = "Null";
        public string NumberOfExecutions { get; set; } = "Null";
        public ObservableCollection<StatisticalParameters> LevelParameters { get; set; } = new ObservableCollection<StatisticalParameters>();
        public ObservableCollection<double> AverageReactionTimesForAllTime { get; set; } = new ObservableCollection<double>();
        public ObservableCollection<double> AverageMinReactionTimesForAllTime { get; set; } = new ObservableCollection<double>();
        public ObservableCollection<double> AverageMaxReactionTimesForAllTime { get; set; } = new ObservableCollection<double>();
        public ObservableCollection<double> AverageAccuracyForAllTime { get; set; } = new ObservableCollection<double>();
        #endregion

        #region Constructors
        public LevelStatistics() { }
        public LevelStatistics(string levelTitle, string levelID, string numberOfExecutions, ObservableCollection<StatisticalParameters> levelParameters)
        {
            LevelTitle = levelTitle;
            LevelID = levelID;
            NumberOfExecutions = numberOfExecutions;
            LevelParameters = levelParameters;
        }
        #endregion
    }
}
