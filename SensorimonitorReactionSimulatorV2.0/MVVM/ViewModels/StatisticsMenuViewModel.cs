using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;
using System.Collections.ObjectModel;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels
{
    internal class StatisticsMenuViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<UserStatistics> _userStatistics;
        #endregion

        #region Properties
        public RelayCommand UpdateStatisticsData { get; private set; }
        public ObservableCollection<UserStatistics> UserStatistics 
        {
            get => _userStatistics;
            set
            {
                _userStatistics = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public StatisticsMenuViewModel()
        {
            UpdateStatistics(null);

            UpdateStatisticsData = new RelayCommand(UpdateStatistics);
        }
        #endregion

        #region Methods
        private void UpdateStatistics(object sender)
        {
            UserStatistics = XmlHandler.Statistics.Users;
        }
        #endregion
    }
}
