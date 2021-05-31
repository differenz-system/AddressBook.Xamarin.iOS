using System;
using DifferenzXamarinDemo;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.ViewControllers;
using Foundation;
using UIKit;

namespace NewSingleViewTemplate
{
    [Register("SceneDelegate")]
    public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        public UIStoryboard MainStoryboard
        {
            get { return UIStoryboard.FromName("Main", NSBundle.MainBundle); }
        }

        public UIViewController GetViewController(UIStoryboard storyboard, string viewControllerName)
        {
            return storyboard.InstantiateViewController(viewControllerName);
        }

        public void SetRootViewController(UIViewController rootViewController, bool animate)
        {
            if (animate)
            {
                var transitionType = UIViewAnimationOptions.CurveEaseInOut;
                this.Window.RootViewController = rootViewController;
                UIView.Transition(Window, 0.5, transitionType, () => Window.RootViewController = rootViewController, null);
            }
            else
            {
                Window.RootViewController = rootViewController;
            }
        }

        public void LIstViewControllerInit()
        {
            var MainViewController = GetViewController(MainStoryboard, "ListViewController") as ListViewController;
            MainViewController.OnAddButtonClick += ListViewController_OnAddButton;
            MainViewController.OnLogoutButtonClick += OnLogOutButton;
            Window.RootViewController = MainViewController;
        }

        public void ListViewControllerInit()
        {
            UserDetailViewController.UserData = null;
            var MainViewController = GetViewController(MainStoryboard, "ListViewController") as ListViewController;
            MainViewController.OnAddButtonClick += ListViewController_OnAddButton;
            MainViewController.OnLogoutButtonClick += OnLogOutButton;
            Window.RootViewController = MainViewController;
        }

        public void ViewControllerInit()
        {
            var MainViewController = GetViewController(MainStoryboard, "LoginViewController") as LoginViewController;
            MainViewController.OnLoginSuccess += LoginViewController_OnLoginSuccess;
            Window.RootViewController = MainViewController;
        }

        public void UserDetailViewControllerInit()
        {
            var MainController = GetViewController(MainStoryboard, "UserDetailViewController") as UserDetailViewController;
            MainController.OnBackButton += LoginViewController_OnLoginSuccess;
            MainController.OnLogoutButtonClick += OnLogOutButton;
            SetRootViewController(MainController, true);
        }

        [Export("scene:willConnectToSession:options:")]
        public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
        {
            // Use this method to optionally configure and attach the UIWindow `window` to the provided UIWindowScene `scene`.
            // If using a storyboard, the `window` property will automatically be initialized and attached to the scene.
            // This delegate does not imply the connecting scene or session are new (see UIApplicationDelegate `GetConfiguration` instead).

            if (SettingsService.IsLoggedIn)
            {
                ListViewControllerInit();
            }
            else
            {
                ViewControllerInit();
            }
            Window.MakeKeyAndVisible();
        }

        void LoginViewController_OnLoginSuccess(object sender, EventArgs e)
        {
            ListViewControllerInit();
        }

        void ListViewController_OnAddButton(object sender, EventArgs e)
        {
            UserDetailViewControllerInit();
        }

        void OnLogOutButton(object sender, EventArgs e)
        {
            SessionService.Logout();
            ViewControllerInit();
        }

        [Export("sceneDidDisconnect:")]
        public void DidDisconnect(UIScene scene)
        {
            // Called as the scene is being released by the system.
            // This occurs shortly after the scene enters the background, or when its session is discarded.
            // Release any resources associated with this scene that can be re-created the next time the scene connects.
            // The scene may re-connect later, as its session was not neccessarily discarded (see UIApplicationDelegate `DidDiscardSceneSessions` instead).
        }

        [Export("sceneDidBecomeActive:")]
        public void DidBecomeActive(UIScene scene)
        {
            // Called when the scene has moved from an inactive state to an active state.
            // Use this method to restart any tasks that were paused (or not yet started) when the scene was inactive.
        }

        [Export("sceneWillResignActive:")]
        public void WillResignActive(UIScene scene)
        {
            // Called when the scene will move from an active state to an inactive state.
            // This may occur due to temporary interruptions (ex. an incoming phone call).
        }

        [Export("sceneWillEnterForeground:")]
        public void WillEnterForeground(UIScene scene)
        {
            // Called as the scene transitions from the background to the foreground.
            // Use this method to undo the changes made on entering the background.
        }

        [Export("sceneDidEnterBackground:")]
        public void DidEnterBackground(UIScene scene)
        {
            // Called as the scene transitions from the foreground to the background.
            // Use this method to save data, release shared resources, and store enough scene-specific state information
            // to restore the scene back to its current state.
        }
    }
}
