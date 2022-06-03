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
            LevelStatistics levelStatistics = new LevelStatistics();
            int authorizedUserIndex = ApplicationPreferences.AuthorizedUserIndex;

            // Is there a level in the list
            bool isLevelIndexContained = Statistics.Users[authorizedUserIndex].StatisticsByLevels.Any(level => level.LevelID == levelID.ToString());

            if (isLevelIndexContained)
            {
                levelStatistics = Statistics.Users[authorizedUserIndex].StatisticsByLevels[levelID];
                levelStatistics.LevelTitle = levelTitle;
                levelStatistics.LevelID = levelID.ToString();
                levelStatistics.NumberOfExecutions = (Convert.ToInt32(levelStatistics.NumberOfExecutions) + 1).ToString();
                levelStatistics.AverageReactionTimesForAllTime.Add(Convert.ToDouble(statistics["Среднее время сенсомоторной реакции :"]));
                levelStatistics.AverageMinReactionTimesForAllTime.Add(Convert.ToDouble(statistics["Минимальное время сенсомоторной реакции :"]));
                levelStatistics.AverageMaxReactionTimesForAllTime.Add(Convert.ToDouble(statistics["Максимальное время сенсомоторной реакции :"]));
                levelStatistics.LevelParameters[0] = new StatisticalParameters(
                    "Среднее время сенсомоторной реакции :",
                    StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageReactionTimesForAllTime).ToString()
                );
                levelStatistics.LevelParameters[1] = new StatisticalParameters(
                    "Максимальное время сенсомоторной реакции :",
                    StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageMaxReactionTimesForAllTime).ToString()
                );
                levelStatistics.LevelParameters[2] = new StatisticalParameters(
                    "Минимальное время сенсомоторной реакции :",
                    StatisticsHandler.CalculateAverageParameterValue(levelStatistics.AverageMinReactionTimesForAllTime).ToString()
                );

                Statistics.Users[authorizedUserIndex].StatisticsByLevels[levelID] = levelStatistics;
            }
            else
            {
                levelStatistics.LevelTitle = levelTitle;
                levelStatistics.LevelID = levelID.ToString();
                levelStatistics.NumberOfExecutions = "1";
                levelStatistics.LevelParameters = StatisticsHandler.StatisticalParametersDictionaryToObservCollection(statistics);
                levelStatistics.AverageReactionTimesForAllTime.Add(Convert.ToDouble(statistics["Среднее время сенсомоторной реакции :"]));
                levelStatistics.AverageMinReactionTimesForAllTime.Add(Convert.ToDouble(statistics["Минимальное время сенсомоторной реакции :"]));
                levelStatistics.AverageMaxReactionTimesForAllTime.Add(Convert.ToDouble(statistics["Максимальное время сенсомоторной реакции :"]));

                Statistics.Users[authorizedUserIndex].StatisticsByLevels.Add(levelStatistics);
            }
        }
        #endregion
    }
}
