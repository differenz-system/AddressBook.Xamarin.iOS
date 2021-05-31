using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DifferenzXamarinDemo.Services
{
    public class SettingsService
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string IsLoggedInKey = "isLoggedIn_key";
        private static readonly bool IsLoggedInDefault = false;

        private const string LoggedInUserEmailKey = "LoggedInUserEmail_key";
        private static readonly string LoggedInUserEmailDefault = string.Empty;

        #endregion

        #region Public Method
        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static bool IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsLoggedInKey, IsLoggedInDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsLoggedInKey, value);
            }
        }

        public static string LoggedInUserEmail
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoggedInUserEmailKey, LoggedInUserEmailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoggedInUserEmailKey, value);
            }
        }
        #endregion
    }
}
