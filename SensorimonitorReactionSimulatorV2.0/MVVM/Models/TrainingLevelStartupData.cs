using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models
{
    public class TrainingLevelStartupData
    {
        #region Properties
        public int LevelID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        #endregion

        #region Constructors
        public TrainingLevelStartupData(string title, string description, int levelID)
        {
            Title = title;
            Description = description;
            LevelID = levelID;
        }
        #endregion
    }
}
