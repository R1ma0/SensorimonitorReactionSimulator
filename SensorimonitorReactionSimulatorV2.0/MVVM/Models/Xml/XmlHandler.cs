using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    static class XmlHandler
    {
        #region Fields
        private static readonly string _pathToXmlDataFile = "UsersAndStatistics.xml";
        private static readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(GlobalStatistics));
        #endregion

        #region Properties
        public static GlobalStatistics Statistics { get; set; } = new GlobalStatistics();
        #endregion

        #region Methods
        public static void ReadStatistics()
        {
            if (File.Exists(_pathToXmlDataFile))
            {
                using (FileStream fileStream = new FileStream(_pathToXmlDataFile, FileMode.OpenOrCreate))
                {
                    Statistics = xmlSerializer.Deserialize(fileStream) as GlobalStatistics;
                }
            }
        }

        public static void WriteStatistics()
        {
            using (FileStream fileStream = new FileStream(_pathToXmlDataFile, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, Statistics);
            }
        }

        public static ObservableCollection<UserAccounts> GetUserAccounts()
        {
            ObservableCollection<UserAccounts> userAccounts = new ObservableCollection<UserAccounts>();

            foreach (UserStatistics user in Statistics.Users)
            {
                userAccounts.Add(new UserAccounts(user.UserName));
            }

            return userAccounts;
        }

        public static void RemoveUserAt(int index)
        {
            Statistics.Users.RemoveAt(index);
        }

        public static void SaveLevelStatistics(string levelTitle, Dictionary<string, string> statistics, int levelID)
        {
            int authorizedUserIndex = ApplicationPreferences.AuthorizedUserIndex;

            if (authorizedUserIndex == -1)
            {
                return;
            }

            LevelStatistics levelStatistics = new LevelStatistics();
            ObservableCollection<LevelStatistics> wantedStatistics = Statistics.Users[authorizedUserIndex].StatisticsByLevels;

            // Is there a level in the list
            bool isLevelIndexContained = wantedStatistics.Any(level => level.LevelID == levelID.ToString());
            bool accuracyContains = statistics.ContainsKey(ApplicationPreferences.AccuractyTitle);

            if (isLevelIndexContained)
            {
                int levelIndex = wantedStatistics.IndexOf(wantedStatistics.First(level => level.LevelID == levelID.ToString()));

                levelStatistics = Statistics.Users[authorizedUserIndex].StatisticsByLevels[levelIndex];
                levelStatistics.AverageReactionTimesForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.AverageTimeReactionTitile]));
                levelStatistics.AverageMinReactionTimesForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.MinTimeReactionTitile]));
                levelStatistics.AverageMaxReactionTimesForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.MaxTimeReactionTitile]));
                levelStatistics.NumberOfExecutions = (Convert.ToInt32(levelStatistics.NumberOfExecutions) + 1).ToString();

                levelStatistics.LevelParameters[0] = new StatisticalParameters(
                    ApplicationPreferences.AverageTimeReactionTitile,
                    StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageReactionTimesForAllTime).ToString()
                );
                levelStatistics.LevelParameters[1] = new StatisticalParameters(
                    ApplicationPreferences.MaxTimeReactionTitile,
                    StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageMaxReactionTimesForAllTime).ToString()
                );
                levelStatistics.LevelParameters[2] = new StatisticalParameters(
                    ApplicationPreferences.MinTimeReactionTitile,
                    StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageMinReactionTimesForAllTime).ToString()
                );

                if (accuracyContains)
                {
                    levelStatistics.AverageAccuracyForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.AccuractyTitle]));
                    levelStatistics.LevelParameters[3] = new StatisticalParameters(
                        ApplicationPreferences.AccuractyTitle,
                        StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageAccuracyForAllTime).ToString()
                    );
                }

                Statistics.Users[authorizedUserIndex].StatisticsByLevels[levelIndex] = levelStatistics;
            }
            else
            {
                levelStatistics.LevelTitle = levelTitle;
                levelStatistics.LevelID = levelID.ToString();
                levelStatistics.NumberOfExecutions = "1";
                levelStatistics.AverageReactionTimesForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.AverageTimeReactionTitile]));
                levelStatistics.AverageMinReactionTimesForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.MinTimeReactionTitile]));
                levelStatistics.AverageMaxReactionTimesForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.MaxTimeReactionTitile]));
                if (accuracyContains)
                {
                    levelStatistics.AverageAccuracyForAllTime.Add(Convert.ToDouble(statistics[ApplicationPreferences.AccuractyTitle]));
                }
                levelStatistics.LevelParameters = StatisticsHandler.StatisticalParametersDictionaryToObservCollection(statistics);

                Statistics.Users[authorizedUserIndex].StatisticsByLevels.Add(levelStatistics);
            }
        }
        #endregion
    }
}
