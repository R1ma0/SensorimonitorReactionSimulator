using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels
{
    class Level_1 : ObservableObject
    {
        #region Fields
        private DispatcherTimer _dispatcherTimer;
        private readonly StatisticsHandler _statisticsHandler;
        private readonly List<double> _timesBetweenTargetAppearanceAndClick;
        private readonly Random _pseudorandomNumberGenerator;
        private DateTime _clickStartTime;
        private DateTime _clickEndTime;
        private bool _isTargetVisible;
        private bool _isTaskComplete;
        private readonly int _numberOfRounds;
        private int _currentRoundNumber;
        private readonly int _minTargetInvisibleTimeMS;
        private readonly int _maxTargetInvisibleTimeMS;
        #endregion

        #region Properties
        public bool IsTargetVisible
        {
            get => _isTargetVisible;
            set
            {
                _isTargetVisible = value;
                OnPropertyChanged("TargetVisibilityChanged");
                CheckTargetVisibility(value);
            }
        }
        public bool IsTaskComplete
        {
            get => _isTaskComplete;
            set
            {
                _isTaskComplete = value;
                OnPropertyChanged("TaskComplete");
            }
        }
        public List<StatisticalParameters> LevelResults { get; private set; }
        #endregion

        #region Constructors
        public Level_1()
        {
            _timesBetweenTargetAppearanceAndClick = new List<double>();
            _pseudorandomNumberGenerator = new Random();
            _statisticsHandler = new StatisticsHandler();

            _isTargetVisible = false;
            _isTaskComplete = false;
            _minTargetInvisibleTimeMS = 1500; // 1.5 sec
            _maxTargetInvisibleTimeMS = 5000; // 5 sec
            _numberOfRounds = 3;
            _currentRoundNumber = 1;

            ShowTargetThroughTheInterval(GetRandomNumberFromRange(_minTargetInvisibleTimeMS, _maxTargetInvisibleTimeMS));
        }
        #endregion

        #region Methods
        private void CheckTargetVisibility(bool state)
        {
            switch (state)
            {
                case true:
                    _clickStartTime = DateTime.Now;
                    break;
                case false:
                    _clickEndTime = DateTime.Now;
                    CalculateClickDelay(_clickStartTime, _clickEndTime);
                    CheckNextRoundNeedToStart();
                    break;
                default:
                    break;
            }
        }

        private void ShowTargetThroughTheInterval(int intervalMS)
        {
            _dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(intervalMS)
            };
            _dispatcherTimer.Tick += ShowTargetAfterTimeExpired;
            _dispatcherTimer.Start();
        }

        private void ShowTargetAfterTimeExpired(object sender, EventArgs e)
        {
            IsTargetVisible = true;
            _dispatcherTimer.Stop();
        }

        private int GetRandomNumberFromRange(int min, int max)
        {
            return _pseudorandomNumberGenerator.Next(min, max);
        }

        private void CalculateClickDelay(DateTime start, DateTime end)
        {
            TimeSpan clickTimeSpan = end.Subtract(start);
            _timesBetweenTargetAppearanceAndClick.Add(clickTimeSpan.Milliseconds);
        }

        private void CheckNextRoundNeedToStart()
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

        private void CompleteTheTask()
        {
            SaveStatistics();

            _currentRoundNumber = 1;
            _timesBetweenTargetAppearanceAndClick.Clear();

            IsTaskComplete = true;
        }

        private void SaveStatistics()
        {
            LevelResults = new List<StatisticalParameters>()
            {
                new StatisticalParameters("Среднее время реакции", _statisticsHandler.CalculateAverageClickTime(_timesBetweenTargetAppearanceAndClick).ToString()),
                new StatisticalParameters("Минимальное время реакции", _timesBetweenTargetAppearanceAndClick.Min(k => k).ToString()),
                new StatisticalParameters("Максимальное время реакции", _timesBetweenTargetAppearanceAndClick.Max(k => k).ToString())
            };

            XmlHandler.SaveLevelStatistics(
                ApplicationPreferences.TrainingLevelStartupDatas[0].Title, 
                LevelResults,
                ApplicationPreferences.TrainingLevelStartupDatas[0].LevelID.ToString()
            );
        }
        #endregion
    }
}
