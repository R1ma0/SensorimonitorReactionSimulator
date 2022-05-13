using System.Collections.ObjectModel;
using System.Windows;
using SensorimonitorReactionSimulatorV2._0.Core;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models;
using SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml;

namespace SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels
{
    internal class AuthorizationMenuViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<UserAccounts> _usersList;
        private bool _userNameInputBoxVisibility;
        private bool _isUsersListEnabled;
        private bool _userManipulationButtonVisibility;
        private bool _logOutButtonVisibility;
        private string _newUserName;
        private string _selectedUserAccount;
        #endregion

        #region Properties
        public RelayCommand AddNewUser { get; set; }
        public RelayCommand RemoveUser { get; set; }
        public RelayCommand ShowUserNameInputBox { get; set; }
        public RelayCommand UserAccountSelectionMode { get; set; }
        public UserAccounts SelectedUser { get; set; }
        public string UserNameInputBox
        {
            get => _newUserName;
            set
            {
                _newUserName = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<UserAccounts> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }
        public bool UserNameInputBoxVisibility 
        {
            get => _userNameInputBoxVisibility;
            set
            {
                _userNameInputBoxVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsUsersListEnabled 
        {
            get => _isUsersListEnabled; 
            set
            {
                _isUsersListEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool UserManipulationButtonVisibility
        {
            get => _userManipulationButtonVisibility; 
            set
            {
                _userManipulationButtonVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool LogOutButtonVisibility 
        {
            get => _logOutButtonVisibility;
            set
            {
                _logOutButtonVisibility = value;
                OnPropertyChanged();
            } 
        }
        public string SelectedUserAccount 
        { 
            get => _selectedUserAccount;
            set
            {
                _selectedUserAccount = value;
                OnPropertyChanged();
            } 
        }
        #endregion

        #region Constructors
        public AuthorizationMenuViewModel()
        {
            _usersList = XmlHandler.GetUserAccounts();
            
            _userNameInputBoxVisibility = false;
            _isUsersListEnabled = true;
            _userManipulationButtonVisibility = true;
            _logOutButtonVisibility = false;
            _selectedUserAccount = null;

            AddNewUser = new RelayCommand(CreateNewUser);
            RemoveUser = new RelayCommand(DeleteUser);
            ShowUserNameInputBox = new RelayCommand(ChangeUserNameInputBoxVisibility);
            UserAccountSelectionMode = new RelayCommand(ChangeUserAccountSelectionMode);
        }
        #endregion

        #region Methods
        private void CreateNewUser(object sender)
        {
            if(UserNameInputBox != null)
            {
                UsersList.Add(new UserAccounts(UserNameInputBox));

                XmlHandler.Statistics.Users.Add(new UserStatistics(UserNameInputBox));
            }

            ChangeUserNameInputBoxVisibility(this);
            UserNameInputBox = null;
        }

        private void ChangeUserNameInputBoxVisibility(object sender)
        {
            UserNameInputBoxVisibility = !UserNameInputBoxVisibility;
        }
        
        private void DeleteUser(object sender)
        {
            if (SelectedUser != null)
            {
                int index = UsersList.IndexOf(SelectedUser);

                UsersList.RemoveAt(index);
                XmlHandler.RemoveUserAt(index);
            }
        }

        private void ChangeUserAccountSelectionMode(object sender)
        {
            if (SelectedUser != null)
            {
                IsUsersListEnabled = !IsUsersListEnabled;
                UserManipulationButtonVisibility = !UserManipulationButtonVisibility;
                LogOutButtonVisibility = !LogOutButtonVisibility;

                if (SelectedUserAccount == null)
                {
                    int index = UsersList.IndexOf(SelectedUser);
                    SelectedUserAccount = UsersList[index].UserName;

                    ApplicationPreferences.AuthorizedUserIndex = index;
                }
                else
                {
                    ApplicationPreferences.AuthorizedUserIndex = -1;
                    SelectedUserAccount = null;
                }
            }
        }
        #endregion
    }
}
