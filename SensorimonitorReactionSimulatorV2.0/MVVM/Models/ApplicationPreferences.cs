using System.Collections.Generic;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models
{
    static class ApplicationPreferences
    {
        #region Fields
        private static int _authorizedUserIndex = -1;
        public static List<TrainingLevelStartupData> TrainingLevelStartupDatas { get; private set; } = new List<TrainingLevelStartupData>()
        {
            new TrainingLevelStartupData(
                "Вычисление скорости простой сенсомоторной реакции №1",
                "Тренировочная задача предназначена для вычисления скорости простой сенсомоторной реакции",
                0
            ),
            new TrainingLevelStartupData(
                "Вычисление скорости простой сенсомоторной реакции №2",
                "Тренировочная задача",
                1
            ),
        };
        #endregion

        #region Properties
        /// <summary>
        /// Contain index of authorized user.
        /// 
        /// Return:
        ///     -1 : No user is logged in;
        ///     0 and more : Index of logged user.
        /// </summary>
        public static int AuthorizedUserIndex
        {
            get => _authorizedUserIndex;
            set
            {
                _authorizedUserIndex = value;
            }
        }
        #endregion
    }
}
