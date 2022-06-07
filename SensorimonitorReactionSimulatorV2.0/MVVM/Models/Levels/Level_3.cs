using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Levels
{
    class Level_3 : ObservableObject
    {
        #region Fields
        private ObservableCollection<double> _timesBetweenTargetAppearanceAndClick;
        private Random _random;
        private DispatcherTimer _dispatcherTimer;
        private List<SolidColorBrush> _ellipsesColors;
        private List<SolidColorBrush> _brushes;
        private Color _displayedElipseColor;
        private DateTime _userClickTime;
        private DateTime _ellipseAppearanceTime;
        private int _ellipsVisibilityTime;
        private int _delayInStartingATask;
        private int _currentRoundNumber;
        private int _numberOfRounds;
        private int _numberOfHits;
        private int _numberOfValidEllipses;
        private int _previousEllipsIndex;
        private bool _isTaskComplete;
        #endregion

        #region Properties
        public SolidColorBrush LeftEllipseColor
        {
            get => _ellipsesColors[0];
            set
            {
                _ellipsesColors[0] = value;
                OnPropertyChanged("LeftEllipseColorChanged");
            }
        }
        public SolidColorBrush MiddleEllipseColor
        {
            get => _ellipsesColors[1];
            set
            {
                _ellipsesColors[1] = value;
                OnPropertyChanged("LeftEllipseColorChanged");
            }
        }
        public SolidColorBrush RightEllipsColor
        {
            get => _ellipsesColors[2];
            set
            {
                _ellipsesColors[2] = value;
                OnPropertyChanged("LeftEllipseColorChanged");
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
        public Dictionary<string, string> LevelResults { get; set; }
        #endregion

        #region Constructors
        public Level_3()
        {
            _random = new Random();
            _timesBetweenTargetAppearanceAndClick = new ObservableCollection<double>();

            _brushes = new List<SolidColorBrush>()
            {
                new SolidColorBrush(Colors.Red),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Yellow),
            };
            _ellipsesColors = new List<SolidColorBrush>()
            {
                new SolidColorBrush(Colors.Transparent),
                new SolidColorBrush(Colors.Transparent),
                new SolidColorBrush(Colors.Transparent),
            };

            _ellipsVisibilityTime = 500;
            _delayInStartingATask = 1000;
            _currentRoundNumber = 1;
            _numberOfHits = 0;
            _numberOfValidEllipses = 0;
            _numberOfRounds = 10;
            _previousEllipsIndex = 1;
    }
        #endregion

        #region Methods
        private void SwitchCirleColorAndPosition()
        {
            SetTransparentColorToEllipses(_ellipsesColors);

            int ellipseIndex = _random.Next(_ellipsesColors.Count);
            while (ellipseIndex == _previousEllipsIndex)
            {
                ellipseIndex = _random.Next(_ellipsesColors.Count);
            }
            _previousEllipsIndex = ellipseIndex;

            int brushIndex = _random.Next(_brushes.Count);
            Color selectedColor = _brushes[brushIndex].Color;

            _ellipsesColors[ellipseIndex].Color = selectedColor;
            _displayedElipseColor = selectedColor;

            CheckThatTheEllipsValid(selectedColor);
        }
        private void CheckThatTheEllipsValid(Color ellipsColor)
        {
            if (Equals(ellipsColor, Colors.Green) || Equals(ellipsColor, Colors.Yellow))
            {
                _numberOfValidEllipses++;
            }
        }
        private void SetTransparentColorToEllipses(List<SolidColorBrush> elipsesColors)
        {
            foreach (SolidColorBrush elipsColor in elipsesColors)
            {
                elipsColor.Color = Colors.Transparent;
            }
        }
        private void ShowEllipsThroughTheInterval(int intervalMS)
        {
            _dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(intervalMS)
            };
            _dispatcherTimer.Tick += ShowEllipsAfterTimeExpired;
            _dispatcherTimer.Start();
        }
        private void ShowEllipsAfterTimeExpired(object sender, EventArgs e)
        {
            _dispatcherTimer.Stop();
            TrackingTheTaskCompletionProcess();
        }
        private void TrackingTheTaskCompletionProcess()
        {
            if (_currentRoundNumber == _numberOfRounds)
            {
                SaveStatistics();
                IsTaskComplete = true;

                _currentRoundNumber = 0;
                _numberOfHits = 0;
            }
            else
            {
                _currentRoundNumber++;

                _ellipseAppearanceTime = DateTime.Now;

                SwitchCirleColorAndPosition();
                ShowEllipsThroughTheInterval(_ellipsVisibilityTime);
            }
        }
        private bool CheckColorMatchingCondition(string buttonDirection, Color displayedColor)
        {
            bool isLeftDirection = buttonDirection == "Left";
            bool isYellowColor = displayedColor == Colors.Yellow;
            bool isGreenColor = displayedColor == Colors.Green;

            bool isColorMatches = (isLeftDirection && isYellowColor) || (!isLeftDirection && isGreenColor);
            return isColorMatches;
        }
        private void SaveStatistics()
        {
            LevelResults = _timesBetweenTargetAppearanceAndClick.Count is 0
                ? new Dictionary<string, string>()
                {
                    { ApplicationPreferences.MinTimeReactionTitile, "0" },
                    { ApplicationPreferences.AverageTimeReactionTitile, "0" },
                    { ApplicationPreferences.MaxTimeReactionTitile, "0" },
                }
                : new Dictionary<string, string>()
                {
                    { ApplicationPreferences.MinTimeReactionTitile, _timesBetweenTargetAppearanceAndClick.Min(k => k).ToString() },
                    { ApplicationPreferences.AverageTimeReactionTitile, StatisticsHandler.CalculateAverageParameterValue(_timesBetweenTargetAppearanceAndClick).ToString() },
                    { ApplicationPreferences.MaxTimeReactionTitile, _timesBetweenTargetAppearanceAndClick.Max(k => k).ToString() },
                };
            double accuracy = _numberOfHits / (double)_numberOfValidEllipses * 100.0;
            accuracy = Math.Round(accuracy, 1);
            LevelResults.Add(ApplicationPreferences.AccuractyTitle, accuracy.ToString());

            XmlHandler.SaveLevelStatistics(
                ApplicationPreferences.TrainingLevelStartupDatas[2].Title,
                LevelResults,
                ApplicationPreferences.TrainingLevelStartupDatas[2].LevelID
            );
        }
        private int CalculateDeltaTime(DateTime start, DateTime end)
        {
            TimeSpan clickTimeSpan = end.Subtract(start);
            return clickTimeSpan.Milliseconds;
        }
        private void CalculateUserReactionTime()
        {
            int reactionTime = CalculateDeltaTime(_ellipseAppearanceTime, _userClickTime);
            _timesBetweenTargetAppearanceAndClick.Add(reactionTime);
        }
        public void HandleKeyboardClickEvent(object key)
        {
            bool isColorMathces = false;
            string keyName = (string)key;
            bool isLeftArrow = keyName == "Left";
            bool isRightArrow = keyName == "Right";

            if (isLeftArrow || isRightArrow)
            {
                isColorMathces = CheckColorMatchingCondition(keyName, _displayedElipseColor);
            }

            if (isColorMathces)
            {
                _numberOfHits++;
                _userClickTime = DateTime.Now;
                CalculateUserReactionTime();
            }
        }
        public void StartTask()
        {
            ShowEllipsThroughTheInterval(_delayInStartingATask);
        }
        #endregion
    }
}
