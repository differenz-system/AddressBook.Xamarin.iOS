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
    [Register ("ListViewController")]
    partial class ListViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddUserButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ListView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogOutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SearchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SearchView { get; set; }

        [Action ("AddUserButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddUserButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("LogOutButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LogOutButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddUserButton != null) {
                AddUserButton.Dispose ();
                AddUserButton = null;
            }

            if (ListView != null) {
                ListView.Dispose ();
                ListView = null;
            }

            if (LogOutButton != null) {
                LogOutButton.Dispose ();
                LogOutButton = null;
            }

            if (SearchBar != null) {
                SearchBar.Dispose ();
                SearchBar = null;
            }

            if (SearchView != null) {
                SearchView.Dispose ();
                SearchView = null;
            }
        }
    }
}