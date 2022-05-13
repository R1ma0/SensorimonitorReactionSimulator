using SensorimonitorReactionSimulatorV2._0.Core;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels
{
    internal class TabMenusViewModel : ObservableObject
    {
        #region Properties
        public LevelMenuViewModel MainMenuVM { get; set; }
        public AuthorizationMenuViewModel AuthorizationVM { get; set; }
        public StatisticsMenuViewModel StatisticsVM { get; set; }
        #endregion

        #region Constructors
        public TabMenusViewModel()
        {
            AuthorizationVM = new AuthorizationMenuViewModel();
            MainMenuVM = new LevelMenuViewModel();
            StatisticsVM = new StatisticsMenuViewModel();
        }
        #endregion
    }
}
