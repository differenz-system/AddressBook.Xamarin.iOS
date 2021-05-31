using System;
using CoreAnimation;
using CoreGraphics;
using DifferenzXamarinDemo.Models;
using Foundation;
using UIKit;

namespace DifferenzXamarinDemo.ViewControllers
{
    public partial class UserDataCell : UITableViewCell
    {
        #region Constructor
        protected UserDataCell(IntPtr handle) : base(handle)
        {   
        }
        #endregion

        #region Private methods
        private void gradiantView()
        {
            var gradientLayer = new CAGradientLayer
            {
                Frame = ColorView.Bounds,
                StartPoint = new CGPoint(0, 0.1),
                EndPoint = new CGPoint(1, 0),
                Colors = new CGColor[] {UIColor.FromRGB(91, 218, 187).CGColor, UIColor.FromRGB(35, 91, 95).CGColor}
            };
            ColorView.Layer.InsertSublayer(gradientLayer, 0);
        }
        #endregion

        #region Public methods
        public void UpdateCell(UserData userData)
        {
            gradiantView();
            CellFirstView.Layer.MasksToBounds = false;
            CellFirstView.Layer.ShadowColor = UIColor.FromRGB(35, 91, 95).CGColor;
            CellFirstView.Layer.ShadowOffset = new CGSize(7f, 7f);
            CellFirstView.Layer.ShadowOpacity = 0.2f;
            CellFirstView.Layer.ShadowRadius = 5;
            mainView.Layer.CornerRadius = 15;
            mainView.Layer.MasksToBounds = true;

            Name.Text = userData.Name;
            Email.Text = userData.EmailAddress;
            Number.Text = userData.ContactNumber;
        }
        #endregion
    }
}
