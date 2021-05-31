using System;
using System.Diagnostics;
using CoreGraphics;
using DifferenzXamarinDemo.Services;
using Foundation;
using Plugin.Connectivity;
using UIKit;

namespace DifferenzXamarinDemo
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIResponder, IUIApplicationDelegate
    {
        [Export("window")]
        public UIWindow Window { get; set; }

        public bool CheckConnectivity()
        {
            try
            {
                return CrossConnectivity.Current.IsConnected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex);
                return false;
            }
        }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            return true;
        }

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {

        }
    }
}