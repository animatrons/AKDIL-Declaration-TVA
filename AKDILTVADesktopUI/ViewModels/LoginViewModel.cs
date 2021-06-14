using AKDILDesktopUI.Library.Api;
using AKDILTVADesktopUI.EventModels;
using Caliburn.Micro;
using System;
using System.Threading.Tasks;

namespace AKDILTVADesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private string _errorMessage;
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;
            }

        }

        // method, property naming and parameter positioning is calibur.micro convention based 
        // the names must match the element identifier x:name in the view (case incensitive)

        public bool CanLogIn
        {
            get 
            {
                bool output = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authentificate(UserName, Password);
                ErrorMessage = "";

                // Capture more info about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                _events.PublishOnUIThread(new LogInEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = "Mot de passe ou e-mail incorrecte" + " Or " + ex.Message;
            }
        }
    }
}
