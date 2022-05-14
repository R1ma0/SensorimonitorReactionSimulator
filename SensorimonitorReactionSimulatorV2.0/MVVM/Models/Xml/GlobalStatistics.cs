using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class GlobalStatistics
    {
        #region Properties
        public ObservableCollection<UserStatistics> Users { get; private set; } = new ObservableCollection<UserStatistics>();
        #endregion

        #region Constructors
        public GlobalStatistics() { }
        public GlobalStatistics(ObservableCollection<UserStatistics> users)
        {
            Users = users;
        }
        #endregion
    }
}
