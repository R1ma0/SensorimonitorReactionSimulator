using System;
using System.Collections.Generic;
using System.Linq;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels
{
    class Level_1 : SSRBaseClass
    {
        #region Constructors
        public Level_1()
        {
            _minTargetInvisibleTimeMS = 2000; // 2 sec
            _maxTargetInvisibleTimeMS = 6000; // 6 sec
            _numberOfRounds = 3;
            _currentRoundNumber = 1;

            ShowTargetThroughTheInterval(GetRandomNumberFromRange(_minTargetInvisibleTimeMS, _maxTargetInvisibleTimeMS));
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
                ApplicationPreferences.TrainingLevelStartupDatas[0].Title,
                LevelResults,
                ApplicationPreferences.TrainingLevelStartupDatas[0].LevelID
            );
        }
        #endregion
    }
}
