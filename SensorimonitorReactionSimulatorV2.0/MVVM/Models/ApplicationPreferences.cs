using System.Collections.Generic;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models
{
    static class ApplicationPreferences
    {
        #region Fields
        public static string AverageTimeReactionTitile = "Среднее время сенсомоторной реакции (мс) :";
        public static string MaxTimeReactionTitile = "Максимальное время сенсомоторной реакции (мс) :";
        public static string MinTimeReactionTitile = "Минимальное время сенсомоторной реакции (мс) :";
        public static string AccuractyTitle = "Точность (%) :";
        #endregion

        #region Properties
        public static List<TrainingLevelStartupData> TrainingLevelStartupDatas { get; private set; } = new List<TrainingLevelStartupData>()
        {
            new TrainingLevelStartupData(
                "Вычисление и тренировка скорости простой сенсомоторной реакции",
                "Тренировочная задача предназначена для вычисления и улучшения скорости простой сенсомоторной реакции.\n" +
                "В центре экрана с разными временными интервалами будет появляться желтый круг.\n" +
                "При появлении желтого круга необходимо как можно быстрее нажать на него левой кнопкой мыши.\n" +
                "Среднее время сенсомоторной реакции человека 200-240 миллисекунд.",
                0
            ),
            new TrainingLevelStartupData(
                "Тренировка скорости простой сенсомоторной реакции",
                "Тренировочная задача предназначена улучшения скорости простой сенсомоторной реакции.\n" +
                "В случайной области экрана с разными временными интервалами будет появляться желтый круг и увеличиваться в размерах.\n" +
                "При появлении желтого круга необходимо как можно быстрее нажать на него левой кнопкой мыши.",
                1
            ),
            new TrainingLevelStartupData(
                "Тренировка скорости сложной сенсомоторной реакции",
                "Тренировочная задача предназначена улучшения скорости сложной сенсомоторной реакции.\n" +
                "На экране с определенной периодичностью в трех разных позициях будет появляться круг одного из трех цветов: зеленый, желтый, красный. " + 
                "Ниже располагаются две кнопки со стрелками влево и вправо.\n" + 
                "При появлении желтого круга необходимо нажать кнопку со стрелкой влево, зеленого - кнопку со стрелкой вправо, а если красный, то ничего не нажимать.",
                2
            ),
        };
        /// <summary>
        /// Contain index of authorized user.
        /// 
        /// Return:
        ///     -1 : No user is logged in;
        ///     0 and more : Index of logged user.
        /// </summary>
        public static int AuthorizedUserIndex { get; set; } = -1;
        #endregion
    }
}
