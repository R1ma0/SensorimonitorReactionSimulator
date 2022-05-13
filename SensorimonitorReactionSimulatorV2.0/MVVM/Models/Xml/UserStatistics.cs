using System.Collections.Generic;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class UserStatistics
    {
        #region Properties
        public string UserName { get; set; } = "Null";
        public List<LevelStatistics> StatisticsByLevels { get; set; } = new List<LevelStatistics>();
        #endregion

        #region Constructors
        public UserStatistics() { }
        public UserStatistics(string userName) 
        {
            UserName = userName;
        }
        public UserStatistics(string userName, List<LevelStatistics> statisticsByLevels)
        {
            UserName = userName;
            StatisticsByLevels = statisticsByLevels;
        }
        #endregion
    }
}
