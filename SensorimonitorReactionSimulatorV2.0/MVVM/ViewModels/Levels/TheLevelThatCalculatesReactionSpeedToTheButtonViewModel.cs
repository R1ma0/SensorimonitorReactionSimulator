using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;
using SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels
{
    abstract class TheLevelThatCalculatesReactionSpeedToTheButtonViewModel : ObservableObject
    {
        #region Fields
        protected ObservableCollection<StatisticalParameters> _statisticalParameters;
        protected Style _backgroundBlurEffectStyle;
        protected readonly Style _blurredBackgroundStyle;
        protected bool _isStatisticsWindowVisible;
        #endregion

        #region Properties
        public RelayCommand GoToMainMenuCommand { get; set; }
        public RelayCommand TargetClickCommand { get; set; }
        public ObservableCollection<StatisticalParameters> StatisticsParams
        {
            get => _statisticalParameters;
            protected set
            {
                _statisticalParameters = value;
                OnPropertyChanged();
            }
        }
        public Style ChangeBlurEffectStyle
        {
            get => _backgroundBlurEffectStyle;
            protected set
            {
                _backgroundBlurEffectStyle = value;
                OnPropertyChanged();
            }

        }
        public bool StatisticsWindowVisibility
        {
            get => _isStatisticsWindowVisible;
            protected set
            {
                _isStatisticsWindowVisible = value;
                OnPropertyChanged();
            }
        }
        public abstract bool TargetVisibility { get; protected set; }
        #endregion

        #region Constructors
        public TheLevelThatCalculatesReactionSpeedToTheButtonViewModel()
        {
            StatisticsParams = new ObservableCollection<StatisticalParameters>();

            _isStatisticsWindowVisible = false;

            _blurredBackgroundStyle = (Style)Application.Current.TryFindResource("BlurredBackground");

            GoToMainMenuCommand = new RelayCommand(GoToMainMenu);
            TargetClickCommand = new RelayCommand(ChangeTargetVisibility);
        }
        #endregion

        #region Methods
        protected void GoToMainMenu(object sender)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainWindowContent.Content = new TabMenusViewModel();
            }
        }

        protected void ChangeTargetVisibility(object sender)
        {
            TargetVisibility = !TargetVisibility;
        }

        protected abstract void LevelPropertyChanged(object sender, PropertyChangedEventArgs e);

        protected abstract void DisplayStatisticsWindow();
        #endregion
    }
}
