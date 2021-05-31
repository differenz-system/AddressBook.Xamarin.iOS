// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace DifferenzXamarinDemo.ViewControllers
{
    [Register ("UserDataCell")]
    partial class UserDataCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CellFirstView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CellView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ColorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Email { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView MainStack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Number { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CellFirstView != null) {
                CellFirstView.Dispose ();
                CellFirstView = null;
            }

            if (CellView != null) {
                CellView.Dispose ();
                CellView = null;
            }

            if (ColorView != null) {
                ColorView.Dispose ();
                ColorView = null;
            }

            if (Email != null) {
                Email.Dispose ();
                Email = null;
            }

            if (MainStack != null) {
                MainStack.Dispose ();
                MainStack = null;
            }

            if (mainView != null) {
                mainView.Dispose ();
                mainView = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }

            if (Number != null) {
                Number.Dispose ();
                Number = null;
            }
        }
    }
}