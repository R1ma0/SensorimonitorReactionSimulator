using SensorimonitorReactionSimulatorV2._0.MVVM.Models;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels;
using System.ComponentModel;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels
{
    class Level_2ViewModel : TheLevelThatCalculatesReactionSpeedToTheButtonViewModel
    {
        #region Fileds
        private readonly Level_2 _levelModel;
        #endregion

        #region Properties
        public int CanvasLeftIndent
        {
            get => _levelModel.CanvasLeftIndent;
            set
            {
                _levelModel.CanvasLeftIndent = value;
                OnPropertyChanged("CanvasLeftIndent");
            }
        }
        public int CanvasTopIndent
        {
            get => _levelModel.CanvasTopIndent;
            set
            {
                _levelModel.CanvasTopIndent = value;
                OnPropertyChanged("CanvasTopIndent");
            }
        }
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
        public Level_2ViewModel()
        {
            _levelModel = new Level_2();
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
            switch (e.PropertyName)
            {
                case "TargetVisibilityChanged":
                    OnPropertyChanged("TargetVisibility");
                    break;
                case "TaskComplete":
                    DisplayStatisticsWindow();
                    break;
                case "CanvasLeftIndentChanged":
                    OnPropertyChanged("CanvasLeftIndent");
                    break;
                case "CanvasTopIndentChanged":
                    OnPropertyChanged("CanvasTopIndent");
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
