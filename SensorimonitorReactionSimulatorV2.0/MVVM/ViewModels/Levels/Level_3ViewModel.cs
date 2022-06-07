using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models;
using System.Collections.ObjectModel;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels
{
    class Level_3ViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<StatisticalParameters> _statisticalParameters;
        private Level_3 _levelModel;
        private Style _backgroundBlurEffectStyle;
        private readonly Style _blurredBackgroundStyle;
        private bool _isStatisticsWindowVisible;
        private bool _isStartButtonVisible;

        #endregion

        #region Properties
        public RelayCommand GoToMainMenuCommand { get; set; }
        public RelayCommand KeyDownEventHandler { get; set; }
        public RelayCommand StartTask { get; set; }
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
        public SolidColorBrush LeftEllipseColor
        {
            get => _levelModel.LeftEllipseColor;
            set
            {
                _levelModel.LeftEllipseColor = value;
                OnPropertyChanged("ChangeLeftEllipsColor");
            }
        }
        public SolidColorBrush MiddleEllipseColor
        {
            get => _levelModel.MiddleEllipseColor;
            set
            {
                _levelModel.MiddleEllipseColor = value;
                OnPropertyChanged("ChangeMiddleEllipsColor");
            }
        }
        public SolidColorBrush RightEllipseColor
        {
            get => _levelModel.RightEllipsColor;
            set
            {
                _levelModel.RightEllipsColor = value;
                OnPropertyChanged("ChangeRightEllipsColor");
            }
        }
        public ObservableCollection<StatisticalParameters> StatisticsParams
        {
            get => _statisticalParameters;
            private set
            {
                _statisticalParameters = value;
                OnPropertyChanged();
            }
        }
        public bool StartButtonVisibility
        {
            get => _isStartButtonVisible;
            set
            {
                _isStartButtonVisible = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public Level_3ViewModel()
        {
            _levelModel = new Level_3();
            _levelModel.PropertyChanged += LevelPropertyChanged;

            _isStatisticsWindowVisible = false;
            _isStartButtonVisible = true;

            _blurredBackgroundStyle = (Style)Application.Current.TryFindResource("BlurredBackground");

            GoToMainMenuCommand = new RelayCommand(GoToMainMenu);
            KeyDownEventHandler = new RelayCommand(_levelModel.HandleKeyboardClickEvent);
            StartTask = new RelayCommand(StartTaskExecution);
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
        private void DisplayStatisticsWindow()
        {
            StatisticsParams = StatisticsHandler.StatisticalParametersDictionaryToObservCollection(_levelModel.LevelResults);

            ChangeBlurEffectStyle = _blurredBackgroundStyle;
            StatisticsWindowVisibility = true;
        }
        private void StartTaskExecution(object sender)
        {
            _levelModel.StartTask();
            StartButtonVisibility = false;
        }
        private void LevelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "LeftEllipsColorChanged":
                    OnPropertyChanged("ChangeLeftEllipsColor");
                    break;
                case "RightEllipsColorChanged":
                    OnPropertyChanged("ChangeRightEllipsColor");
                    break;
                case "MiddleEllipsColorChanged":
                    OnPropertyChanged("ChangeMiddleEllipsColor");
                    break;
                case "TaskComplete":
                    DisplayStatisticsWindow();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
