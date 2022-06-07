using System.ComponentModel;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels
{
    class Level_1ViewModel : TheLevelThatCalculatesReactionSpeedToTheButtonViewModel
    {
        #region Fields
        private readonly Level_1 _levelModel;
        #endregion

        #region Properties
        public override bool TargetVisibility
        {
            get => _levelModel.IsTargetVisible;
            protected set
            {
                _levelModel.IsTargetVisible = value;
                OnPropertyChanged("TargetVisibility");
            }
        }
        #endregion

        #region Constructors
        public Level_1ViewModel()
        {
            _levelModel = new Level_1();
            _levelModel.PropertyChanged += LevelPropertyChanged;
        }
        #endregion

        #region Methods
        protected override void DisplayStatisticsWindow()
        {
            StatisticsParams = StatisticsHandler.StatisticalParametersDictionaryToObservCollection(_levelModel.LevelResults);
            ChangeBlurEffectStyle = _blurredBackgroundStyle;
            StatisticsWindowVisibility = true;
        }
        protected override void LevelPropertyChanged(object sender, PropertyChangedEventArgs e)
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

        protected override void StartTaskExecution(object sender)
        {
            _levelModel.StartTask();
            StartButtonVisibility = false;
        }
        #endregion
    }
}
