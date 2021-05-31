// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DifferenzXamarinDemo.ViewControllers
{
    [Register ("UserDetailViewController")]
    partial class UserDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch ActiveSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Loader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogOutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NumberTxt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UpdateButton { get; set; }

        [Action ("BackButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("DeleteButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DeleteButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("LogOutButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LogOutButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UpdateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UpdateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ActiveSwitch != null) {
                ActiveSwitch.Dispose ();
                ActiveSwitch = null;
            }

            if (BackButton != null) {
                BackButton.Dispose ();
                BackButton = null;
            }

            if (DeleteButton != null) {
                DeleteButton.Dispose ();
                DeleteButton = null;
            }

            if (EmailTxt != null) {
                EmailTxt.Dispose ();
                EmailTxt = null;
            }

            if (Loader != null) {
                Loader.Dispose ();
                Loader = null;
            }

            if (LogOutButton != null) {
                LogOutButton.Dispose ();
                LogOutButton = null;
            }

            if (NameTxt != null) {
                NameTxt.Dispose ();
                NameTxt = null;
            }

            if (NumberTxt != null) {
                NumberTxt.Dispose ();
                NumberTxt = null;
            }

            if (UpdateButton != null) {
                UpdateButton.Dispose ();
                UpdateButton = null;
            }
        }
    }
}