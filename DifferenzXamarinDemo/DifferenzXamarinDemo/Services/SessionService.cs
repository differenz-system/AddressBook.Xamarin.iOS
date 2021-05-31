using System;
using UIKit;

namespace DifferenzXamarinDemo.Services
{
    public class SessionService
    {
        #region Constructor
        public SessionService()
        {
        }
        #endregion

        #region Private Properties

        #endregion

        #region Public Properties
        public static readonly string EMAIL_REGEX = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly string PHONE_NO_REGEX = @"\d{10}";
        #endregion

        #region Private Methods

        #endregion

        #region Public methods

        public static void Logout()
        {
            SettingsService.IsLoggedIn = false;
            SettingsService.LoggedInUserEmail = string.Empty;
        }

        public static void AutoLogin()
        {
            SettingsService.IsLoggedIn = true;
        }

        #endregion
    }
}
