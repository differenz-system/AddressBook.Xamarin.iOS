using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using CoreGraphics;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using UIKit;

namespace DifferenzXamarinDemo.ViewControllers
{
    public partial class UserDetailViewController : UIViewController
    {
        #region Constructor
        public UserDetailViewController(IntPtr handle) : base(handle)
        {
            
        }
        #endregion


        #region Private Properties

        private int id = 0;

        #endregion


        #region Public Properties

        public static UserData UserData { get; set; }

        #endregion


        #region Public EventHandler

        public event EventHandler OnBackButton;
        public event EventHandler OnLogoutButtonClick;

        #endregion


        #region Public methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (UserData != null)
            {
                NameTxt.Text = UserData.Name;
                ActiveSwitch.On = UserData.Active;
                NumberTxt.Text = UserData.ContactNumber;
                EmailTxt.Text = UserData.EmailAddress;
                id = UserData.ID;
            }

            ControlsAnimationLayer();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        #endregion


        #region Private methods

        private void ControlsAnimationLayer()
        {
            NameTxt.Layer.BorderColor = UIColor.FromRGB(35, 91, 95).CGColor;
            NameTxt.Layer.BorderWidth = 2;
            NameTxt.Layer.CornerRadius = 5;

            EmailTxt.Layer.BorderColor = UIColor.FromRGB(35, 91, 95).CGColor;
            EmailTxt.Layer.BorderWidth = 2;
            EmailTxt.Layer.CornerRadius = 5;

            NumberTxt.Layer.BorderColor = UIColor.FromRGB(35, 91, 95).CGColor;
            NumberTxt.Layer.BorderWidth = 2;
            NumberTxt.Layer.CornerRadius = 5;

            UpdateButton.SetTitle(UserData != null ? AppResources.TEXT_UPDATE : AppResources.TEXT_SAVE, UIControlState.Normal);
            UpdateButton.Layer.MasksToBounds = false;
            UpdateButton.Layer.ShadowColor = UIColor.FromRGB(59, 89, 152).CGColor;
            UpdateButton.Layer.ShadowOffset = new CGSize(0f, 10f);
            UpdateButton.Layer.ShadowOpacity = 0.4f;
            UpdateButton.Layer.ShadowRadius = 15;

            DeleteButton.SetTitle(id > 0 ? AppResources.TEXT_DELETE : AppResources.TEXT_CANCEL, UIControlState.Normal);
            DeleteButton.Layer.MasksToBounds = false;
            DeleteButton.Layer.ShadowColor = UIColor.FromRGB(59, 89, 152).CGColor;
            DeleteButton.Layer.ShadowOffset = new CGSize(0f, 10f);
            DeleteButton.Layer.ShadowOpacity = 0.4f;
            DeleteButton.Layer.ShadowRadius = 15;
        }

        #endregion


        #region Partial Methods

        partial void UpdateButton_TouchUpInside(UIButton sender)
        {
            try
            {
                if (!string.IsNullOrEmpty(NameTxt.Text) && !string.IsNullOrEmpty(EmailTxt.Text) && !string.IsNullOrEmpty(NumberTxt.Text))
                {
                    if (!(Regex.IsMatch(EmailTxt.Text, SessionService.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                    {
                        var okAlertController = UIAlertController.Create(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_INVALID_EMAIL, UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                        return;
                    }

                    if (!(Regex.IsMatch(NumberTxt.Text, SessionService.PHONE_NO_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                    {
                        var okAlertController = UIAlertController.Create(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_INVALID_CONTACT_NO, UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                        return;
                    }

                    Loader.StartAnimating();
                    var userData = new UserData();
                    userData.ID = id;
                    userData.Name = NameTxt.Text;
                    userData.EmailAddress = EmailTxt.Text;
                    userData.ContactNumber = NumberTxt.Text;
                    userData.Active = ActiveSwitch.On;
                    DatabaseService.SaveItem(userData);
                    Loader.StopAnimating();
                    Loader.Hidden = true;

                    var okAlertController1 = UIAlertController.Create(AppResources.TITLE_SUCCESS, UpdateButton.TitleLabel.Text == AppResources.TEXT_SAVE ? AppResources.MESSAGE_SUCCESS_DATA_SAVE : AppResources.MESSAGE_SUCCESS_DATA_UPDATED, UIAlertControllerStyle.Alert);
                    okAlertController1.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, (actionOK) => { OnBackButton?.Invoke(null, new EventArgs()); }));
                    PresentViewController(okAlertController1, true, null);
                }
                else
                {
                    var okAlertController = UIAlertController.Create(AppResources.TITLE_VALIDATION_ERROR, AppResources.MESSAGE_ERROR_INSERT_ALL_DATA, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex);
            }
        }

        partial void DeleteButton_TouchUpInside(UIButton sender)
        {
            Loader.StartAnimating();
            DatabaseService.DeleteItem(id);
            Loader.StopAnimating();
            Loader.Hidden = true;
            OnBackButton?.Invoke(null, new EventArgs());
        }

        partial void BackButton_TouchUpInside(UIButton sender)
        {
            OnBackButton?.Invoke(null, new EventArgs());
        }

        partial void LogOutButton_TouchUpInside(UIButton sender)
        {
            OnLogoutButtonClick?.Invoke(sender, new EventArgs());
        }

        #endregion
    }
}

