using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class UserStatistics
    {
        #region Properties
        public string UserName { get; set; } = "Null";
        public ObservableCollection<LevelStatistics> StatisticsByLevels { get; private set; } = new ObservableCollection<LevelStatistics>();
        #endregion

        #region Constructors
        public UserStatistics() { }
        public UserStatistics(string userName) 
        {
            UserName = userName;
        }
        public UserStatistics(string userName, ObservableCollection<LevelStatistics> statisticsByLevels)
        {
            UserName = userName;
            StatisticsByLevels = statisticsByLevels;
        }
        #endregion
    }
}
