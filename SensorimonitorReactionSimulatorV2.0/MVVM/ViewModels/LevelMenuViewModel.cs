using System.Collections.ObjectModel;
using System.Linq;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models;
using SensorimonitorReactionSimulatorV2._0.MVVM.Views.Levels;
using SensorimonitorReactionSimulatorV2._0.Core;
using System.Windows.Controls;
using System.Windows;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels
{
    internal class LevelMenuViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<TrainingLevelStartupData> _trainingLevelList;
        private ObservableCollection<ContentControl> _levelsViewsCollection;
        #endregion

        #region Properties
        public RelayCommand LoadSelectedLevelCommand { get; set; }
        public ObservableCollection<TrainingLevelStartupData> TrainingLevelList
        {
            get => _trainingLevelList;
            set
            {
                _trainingLevelList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public LevelMenuViewModel()
        {
            TrainingLevelList = new ObservableCollection<TrainingLevelStartupData>(ApplicationPreferences.TrainingLevelStartupDatas);

            _levelsViewsCollection = new ObservableCollection<ContentControl>()
            {
                new Level_1(),
                new Level_2(),
            };

            LoadSelectedLevelCommand = new RelayCommand(LoadSelectedLevel);
        }
        #endregion

        #region Methods
        private void LoadSelectedLevel(object sender)
        {
            int levelIDToStart = (int)sender;

            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.MainWindowContent.Content = _levelsViewsCollection[levelIDToStart];
            }
        }
        #endregion
    }
}
