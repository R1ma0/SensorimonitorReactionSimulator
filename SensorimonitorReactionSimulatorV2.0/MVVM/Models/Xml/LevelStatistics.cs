using System.Collections.Generic;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class LevelStatistics
    {
        #region Properties
        public string LevelTitle { get; set; } = "Null";
        public string LevelID { get; set; } = "Null";
        public List<StatisticalParameters> LevelParameters { get; set; } = new List<StatisticalParameters>();
        #endregion

        #region Constructors
        public LevelStatistics() { }
        public LevelStatistics(string levelTitle, List<StatisticalParameters> levelParameters, string levelID)
        {
            LevelTitle = levelTitle;
            LevelParameters = levelParameters;
            LevelID = levelID;
        }
        #endregion
    }
}
