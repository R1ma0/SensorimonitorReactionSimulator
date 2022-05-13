using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        public static void SaveLevelStatistics(string levelTitle, List<StatisticalParameters> statistics, string levelID)
        {
            // Не add а суммирование с уже имеющимися значениями
            Statistics.Users[ApplicationPreferences.AuthorizedUserIndex].StatisticsByLevels.Add(new LevelStatistics(levelTitle, statistics, levelID));
        }

        public static ObservableCollection<UserStatistics> GetStatisticsAsObservableCollection()
        {
            return new ObservableCollection<UserStatistics>(Statistics.Users);
        }
        #endregion
    }
}
