using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using SensorimonitorReactionSimulatorV2._0.Core;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels
{
    /// <summary>
    /// Simple Sensorimotor Reaction Base Class
    /// </summary>
    abstract class SSRBaseClass : ObservableObject
    {
        #region Fields
        protected ObservableCollection<double> _timesBetweenTargetAppearanceAndClick;
        protected DispatcherTimer _dispatcherTimer;
        protected Random _random;
        protected DateTime _clickStartTime;
        protected DateTime _clickEndTime;
        protected bool _isTargetVisible;
        protected bool _isTaskComplete;
        protected int _minTargetInvisibleTimeMS;
        protected int _maxTargetInvisibleTimeMS;
        protected int _numberOfRounds;
        protected int _currentRoundNumber;
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
        public Dictionary<string, string> LevelResults { get; protected set; }
        #endregion

        #region Constructors
        public SSRBaseClass()
        {
            _random = new Random();
            _timesBetweenTargetAppearanceAndClick = new ObservableCollection<double>();

            _isTargetVisible = false;
            _isTaskComplete = false;
        }
        #endregion

        #region Methods
        protected void CheckTargetVisibility(bool state)
        {
            switch (state)
            {
                case true:
                    _clickStartTime = DateTime.Now;
                    break;
                case false:
                    _clickEndTime = DateTime.Now;
                    _timesBetweenTargetAppearanceAndClick.Add(CalculateReactionTime(_clickStartTime, _clickEndTime));
                    AdditionalActionsAfterHidingOnTheTarget();
                    break;
                default:
                    break;
            }
        }
        protected void ShowTargetThroughTheInterval(int intervalMS)
        {
            _dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(intervalMS)
            };
            _dispatcherTimer.Tick += ShowTargetAfterTimeExpired;
            _dispatcherTimer.Start();
        }
        protected void ShowTargetAfterTimeExpired(object sender, EventArgs e)
        {
            IsTargetVisible = true;
            _dispatcherTimer.Stop();
        }
        protected int GetRandomNumberFromRange(int min, int max)
        {
            return _random.Next(min, max);
        }
        protected int CalculateReactionTime(DateTime start, DateTime end)
        {
            TimeSpan clickTimeSpan = end.Subtract(start);
            return clickTimeSpan.Milliseconds;
        }
        protected void CompleteTheTask()
        {
            SaveStatistics();

            _currentRoundNumber = 1;
            _timesBetweenTargetAppearanceAndClick.Clear();

            IsTaskComplete = true;
        }
        protected abstract void SaveStatistics();
        protected abstract void AdditionalActionsAfterHidingOnTheTarget();
        #endregion
    }
}
