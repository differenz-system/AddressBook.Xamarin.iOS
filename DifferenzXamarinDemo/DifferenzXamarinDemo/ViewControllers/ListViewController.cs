using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using DifferenzXamarinDemo.Interface;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using UIKit;

namespace DifferenzXamarinDemo.ViewControllers
{
    public partial class ListViewController : UIViewController, IContactInterface
    {
        #region Constructor
        public ListViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion


        #region Private Properties
        private List<UserData> _itemdata;
        #endregion


        #region Public Properties

        #endregion


        #region Public EventHandler
        public event EventHandler OnAddButtonClick;
        public event EventHandler OnLogoutButtonClick;
        #endregion


        #region Public methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            listData();
            ControlsAnimationLayer();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        #endregion


        #region Private methods

        private void listData()
        {
            List<UserData> listData = DatabaseService.GetAll();
            var sorted = listData.OrderBy(item => item.Name).ToList();
            _itemdata = sorted;
        }

        private void ListViewCell()
        {
            var cell = (UserDataCell)ListView.DequeueReusableCell("cell");
            ListView.Source = new TableSource(_itemdata, OnAddButtonClick, this);
            ListView.AllowsSelection = true;
            ListView.ReloadData();
        }

        private void ControlsAnimationLayer()
        {
            SearchView.Layer.MasksToBounds = false;
            SearchView.Layer.ShadowColor = UIColor.FromRGB(35, 91, 95).CGColor;
            SearchView.Layer.ShadowOffset = new CGSize(0f, 10f);
            SearchView.Layer.ShadowOpacity = 0.4f;
            SearchBar.AddTarget(ValueChanged, UIControlEvent.EditingChanged);
            ListViewCell();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            List<UserData> listData = DatabaseService.GetAll();
            if (SearchBar.Text.Count() > 0)
            {
                var sorted = listData.Where(c => c.Name.ToLower().Contains(SearchBar.Text.ToLower()))
                    .OrderBy(item => item.Name).ToList();
                _itemdata = sorted;
            }
            else
            {
                var sorted = listData.OrderBy(item => item.Name).ToList();
                _itemdata = sorted;
            }
            ListViewCell();
        }

        #endregion


        #region Partial Methods

        partial void AddUserButton_TouchUpInside(UIButton sender)
        {
            OnAddButtonClick?.Invoke(sender, new EventArgs());
        }

        partial void LogOutButton_TouchUpInside(UIButton sender)
        {
            OnLogoutButtonClick?.Invoke(sender, new EventArgs());
        }

        public void DeleteContact(UserData userData)
        {
            DatabaseService.DeleteItem(userData.ID);
            listData();
            ListViewCell();
        }

        #endregion
    }
}