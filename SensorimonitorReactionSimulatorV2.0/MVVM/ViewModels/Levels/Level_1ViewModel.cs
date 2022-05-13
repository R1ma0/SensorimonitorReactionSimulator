using System.Linq;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels;
using SensorimonitorReactionSimulatorV2._0.Core;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels
{
    class Level_1ViewModel : ObservableObject
    {
        #region Fields
        private readonly Level_1 _levelModel;
        private ObservableCollection<StatisticalParameters> _taskIndicators;
        private Style _backgroundBlurEffectStyle;
        private readonly Style _blurredBackgroundStyle;
        private bool _isStatisticsWindowVisible;
        #endregion

        #region Properties
        public RelayCommand GoToMainMenuCommand { get; set; }
        public RelayCommand TargetClickCommand { get; set; }
        public bool TargetVisibility
        {
            get => _levelModel.IsTargetVisible;
            private set
            {
                _levelModel.IsTargetVisible = value;
                OnPropertyChanged("TargetVisibility");
            }
        }
        public Style ChangeBlurEffectStyle
        {
            get => _backgroundBlurEffectStyle;
            private set
            {
                _backgroundBlurEffectStyle = value;
                OnPropertyChanged();
            }
               
        }
        public bool StatisticsWindowVisibility
        {
            get => _isStatisticsWindowVisible;
            set
            {
                _isStatisticsWindowVisible = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StatisticalParameters> TaskIndicators
        {
            get => _taskIndicators;
            private set
            {
                _taskIndicators = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public Level_1ViewModel()
        {
            _levelModel = new Level_1();
            _levelModel.PropertyChanged += LevelPropertyChanged;

            TaskIndicators = new ObservableCollection<StatisticalParameters>();

            _isStatisticsWindowVisible = false;

            _blurredBackgroundStyle = (Style)Application.Current.TryFindResource("BlurredBackground");

            GoToMainMenuCommand = new RelayCommand(GoToMainMenu);
            TargetClickCommand = new RelayCommand(ChangeTargetVisibility);
        }
        #endregion

        #region Methods
        private void GoToMainMenu(object sender)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainWindowContent.Content = new TabMenusViewModel();
            }
        }

        private void ChangeTargetVisibility(object sender)
        {
            TargetVisibility = !TargetVisibility;
        }

        private void LevelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "TargetVisibilityChanged":
                    OnPropertyChanged("TargetVisibility");
                    break;
                case "TaskComplete":
                    DisplayStatisticsWindow();
                    break;
                default:
                    break;
            }
        }

        private void DisplayStatisticsWindow()
        {
            TaskIndicators = new ObservableCollection<StatisticalParameters>(_levelModel.LevelResults);

            ChangeBlurEffectStyle = _blurredBackgroundStyle;
            StatisticsWindowVisibility = true;
        }
        #endregion
    }
}
