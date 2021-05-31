using System;
using System.Diagnostics;
using System.Drawing;
using System.Json;
using System.Text.RegularExpressions;
using CoreAnimation;
using CoreGraphics;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using UIKit;
using Xamarin.Auth;

namespace DifferenzXamarinDemo.ViewControllers
{
    public partial class LoginViewController : UIViewController
    {
        public static readonly string FacebookClientId = "";

        #region Constructor
        public LoginViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion


        #region Private Properties

        #endregion


        #region Public Properties

        #endregion


        #region Public EventHandler
        public event EventHandler OnLoginSuccess;
        #endregion


        #region Public methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            gradiantView();
            ControlsAnimationLayer();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        #endregion


        #region Private Methods

        private void ControlsAnimationLayer()
        {
            EmailTxt.Layer.BorderColor = UIColor.FromRGB(35, 91, 95).CGColor;
            EmailTxt.Layer.BorderWidth = 2;
            EmailTxt.Layer.CornerRadius = 5;
            EmailTxt.Layer.ShadowColor = UIColor.FromRGB(59, 89, 152).CGColor;
            EmailTxt.Layer.ShadowOffset = new CGSize(0f, 10f);
            EmailTxt.Layer.ShadowOpacity = 0.4f;
            EmailTxt.Layer.ShadowRadius = 15;

            PasswordTxt.SecureTextEntry = true;
            PasswordTxt.Layer.BorderColor = UIColor.FromRGB(35, 91, 95).CGColor;
            PasswordTxt.Layer.BorderWidth = 2;
            PasswordTxt.Layer.CornerRadius = 5;

            LoginButton.Layer.MasksToBounds = false;
            LoginButton.Layer.ShadowColor = UIColor.FromRGB(59, 89, 152).CGColor;
            LoginButton.Layer.ShadowOffset = new CGSize(0f, 10f);
            LoginButton.Layer.ShadowOpacity = 0.4f;
            LoginButton.Layer.ShadowRadius = 15;

            FaceBookLoginButton.ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            FaceBookLoginButton.Layer.MasksToBounds = false;
            FaceBookLoginButton.Layer.ShadowColor = UIColor.FromRGB(59, 89, 152).CGColor;
            FaceBookLoginButton.Layer.ShadowOffset = new CGSize(0f, 10f);
            FaceBookLoginButton.Layer.ShadowOpacity = 0.4f;
            FaceBookLoginButton.Layer.ShadowRadius = 15;
        }

        private void gradiantView()
        {
            var gradientLayer = new CAGradientLayer
            {
                StartPoint = new CGPoint(0, 0.5),
                EndPoint = new CGPoint(1, 0.5),
                Colors = new CGColor[] { UIColor.FromRGB(91, 218, 187).CGColor, UIColor.FromRGB(35, 91, 95).CGColor }
            };
            LoginButton.Layer.InsertSublayer(gradientLayer, 0);
        }

        private async void LoginMethod(object sender)
        {
            try
            {
                //Loader.StartAnimating();
                LoginModel LoginData = new LoginModel();
                LoginData.Email = EmailTxt.Text;
                LoginData.Password = PasswordTxt.Text;
                LoginData.DeviceOSType = "No Device";
                LoginData.DeviceToken = "";
                LoginData.DeviceUDID = "";
                var result = await LoginService.Login(LoginData);

                if (result != null)
                {
                    //Loader.StopAnimating();
                    //Loader.Hidden = true;

                    if (result.Errors.Count > 0)
                    {
                        var okAlertController = UIAlertController.Create(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                    }
                    else
                    {
                        NavigateToMain(result.Email, sender);
                    }
                }
                else
                {
                    var okAlertController = UIAlertController.Create(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex);
            }
        }

        private void NavigateToMain(string username, object sender)
        {
            SettingsService.LoggedInUserEmail = username;
            Debug.WriteLine($"Logged In User : {username}");
            SettingsService.IsLoggedIn = true;
            OnLoginSuccess?.Invoke(sender, new EventArgs());
        }

        #endregion


        #region Partial Methods

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            try
            {
                var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                if (string.IsNullOrEmpty(EmailTxt.Text) && string.IsNullOrEmpty(PasswordTxt.Text))
                {
                    var okAlertController = UIAlertController.Create(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                    return;
                }

                if (!(Regex.IsMatch(EmailTxt.Text, SessionService.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                {
                    var okAlertController = UIAlertController.Create(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_INVALID_EMAIL, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                    return;
                }
                var isConnected = appDelegate.CheckConnectivity();
                if (!isConnected)
                {
                    var okAlertController = UIAlertController.Create(AppResources.TITLE_ALERT, AppResources.MESSAGE_ERROR_NO_INTERNET, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create(AppResources.TEXT_OK, UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                    return;
                }

                LoginMethod(sender);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex);
            }
        }

        partial void FaceBookLoginButton_TouchUpInside(UIButton btnSender)
        {
            var rc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            var auth = new OAuth2Authenticator(
                    clientId: FacebookClientId,
                    scope: "email, public_profile",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"))
            {
                AllowCancel = true,
                ShowErrors = false,
                ClearCookiesBeforeLogin = true,
            };

            auth.Error += (sender, eventArgs) =>
            {
                auth.OnCancelled();
                rc.DismissModalViewController(true);
            };

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=id,name,email,first_name,last_name,gender,picture,link"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var user = JsonValue.Parse(response.GetResponseText());
                    var fbName = user["name"];
                    // var fbProfile = user["picture"]["data"]["url"];

                    NavigateToMain(fbName.ToString(), sender);
                }
                else
                {
                    // The user cancelled
                }

                rc.DismissModalViewController(true);
            };

            // We presented the UI, so it's up to us to dimiss it on iOS.
            rc.PresentViewController(auth.GetUI(), false, null);
        }

        #endregion
    }
}

