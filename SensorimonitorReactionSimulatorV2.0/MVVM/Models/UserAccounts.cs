using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models
{
    public class UserAccounts
    {
        #region Properties
        public string UserName { get; set; }
        #endregion

        #region Constructors
        public UserAccounts(string userName)
        {
            UserName = userName;
        }
        #endregion
    }
}
