using System.Collections.Generic;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class GlobalStatistics
    {
        #region Properties
        public List<UserStatistics> Users { get; set; } = new List<UserStatistics>();
        #endregion

        #region Constructors
        public GlobalStatistics() { }
        public GlobalStatistics(List<UserStatistics> users)
        {
            Users = users;
        }
        #endregion
    }
}
