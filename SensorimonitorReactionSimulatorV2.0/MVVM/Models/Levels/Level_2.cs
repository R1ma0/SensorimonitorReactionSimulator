using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;
using System.Collections.Generic;
using System.Linq;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels
{
    class Level_2 : SSRBaseClass
    {
        #region Fields
        private int _canvasLeftIndent;
        private int _canvasTopIndent;
        private int _canvasLeftIndentMaxValue;
        private int _canvasTopIndentMaxValue;
        private int _targetAppearanceTimeAfterTaskStart;
        #endregion

        #region Properties
        public int CanvasLeftIndent
        {
            get => _canvasLeftIndent;
            set
            {
                _canvasLeftIndent = value;
                OnPropertyChanged("CanvasLeftIndentChanged");
            }
        }
        public int CanvasTopIndent
        {
            get => _canvasTopIndent;
            set
            {
                _canvasTopIndent = value;
                OnPropertyChanged("CanvasTopIndentChanged");
            }
        }
        #endregion

        #region Constructors
        public Level_2()
        {
            _canvasLeftIndentMaxValue = 1000;
            _canvasTopIndentMaxValue = 400;

            _numberOfRounds = 3;
            _currentRoundNumber = 1;

            _minTargetInvisibleTimeMS = 500;
            _maxTargetInvisibleTimeMS = 2000; // 0.5 sec
            _targetAppearanceTimeAfterTaskStart = 2000; // 2 sec

            CanvasLeftIndent = GetRandomNumberFromRange(0, _canvasLeftIndentMaxValue);
            CanvasTopIndent = GetRandomNumberFromRange(0, _canvasTopIndentMaxValue);

            ShowTargetThroughTheInterval(_targetAppearanceTimeAfterTaskStart);
        }
        #endregion

        #region Methods
        protected override void AdditionalActionsAfterHidingOnTheTarget()
        {
            if (_currentRoundNumber == _numberOfRounds)
            {
                CompleteTheTask();
            }
            else
            {
                _currentRoundNumber++;

                CanvasLeftIndent = GetRandomNumberFromRange(0, _canvasLeftIndentMaxValue);
                CanvasTopIndent = GetRandomNumberFromRange(0, _canvasTopIndentMaxValue);

                ShowTargetThroughTheInterval(GetRandomNumberFromRange(_minTargetInvisibleTimeMS, _maxTargetInvisibleTimeMS));
            }
        }
        protected override void SaveStatistics()
        {
            LevelResults = new Dictionary<string, string>()
            {
                { "Минимальное время сенсомоторной реакции :", _timesBetweenTargetAppearanceAndClick.Min(k => k).ToString() },
                { "Среднее время сенсомоторной реакции :", StatisticsHandler.CalculateAverageParameterValue(_timesBetweenTargetAppearanceAndClick).ToString() },
                { "Максимальное время сенсомоторной реакции :", _timesBetweenTargetAppearanceAndClick.Max(k => k).ToString() },
            };

            XmlHandler.SaveLevelStatistics(
                ApplicationPreferences.TrainingLevelStartupDatas[1].Title,
                LevelResults,
                ApplicationPreferences.TrainingLevelStartupDatas[1].LevelID
            );
        }
        #endregion
    }
}
