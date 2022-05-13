using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region Fields
        private ObservableObject _currentMainWindowContent;
        #endregion

        #region Properties
        public ObservableObject CurrentMainWindowContent
        {
            get => _currentMainWindowContent;
            set
            {
                _currentMainWindowContent = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            CurrentMainWindowContent = new TabMenusViewModel();
            System.Windows.Application.Current.MainWindow.Closing += new System.ComponentModel.CancelEventHandler(MainWindowClosingActions);

            XmlHandler.ReadStatistics();
        }
        #endregion

        #region Methods
        private void MainWindowClosingActions(object senderm, System.ComponentModel.CancelEventArgs e)
        {
            XmlHandler.WriteStatistics();
        }
        #endregion
    }
}
