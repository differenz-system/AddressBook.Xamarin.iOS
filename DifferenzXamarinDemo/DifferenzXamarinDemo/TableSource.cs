using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using DifferenzXamarinDemo.Interface;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.ViewControllers;
using Foundation;
using UIKit;

namespace DifferenzXamarinDemo
{
    public class TableSource : UITableViewSource
    {
        IContactInterface _listner;

        #region Constructor
        public TableSource(List<UserData> items, EventHandler eventHandler, IContactInterface listner)
        {
            OnAddButtonClick = eventHandler;
            _listner = listner;

            indexedTableItems = new Dictionary<string, List<UserData>>();
            foreach (var user in items)
            {
                if (indexedTableItems.ContainsKey(user.Name.Substring(0, 1).ToUpper()))
                {
                    indexedTableItems[user.Name.Substring(0, 1).ToUpper()].Add(user);
                }
                else
                {
                    indexedTableItems.Add(user.Name.Substring(0, 1).ToUpper(), new List<UserData>() { user });
                }
            }
            keys = indexedTableItems.Keys.ToArray();
            values = indexedTableItems.Values.ToArray();
        }
        #endregion

        #region Private Properties
        private Dictionary<string, List<UserData>> indexedTableItems;
        private string[] keys;
        private List<UserData>[] values;
        #endregion


        #region Public Properties

        #endregion


        #region Public EventHandler
        public event EventHandler OnAddButtonClick;
        #endregion

        #region Private methods

        private UIContextualAction ContextualDeleteAction(UserData userData, UITableView tableView)
        {
            var action = UIContextualAction.FromContextualActionStyle
                     (UIContextualActionStyle.Normal,
                         "Delete",
                         (FlagAction, view, success) =>
                         {
                             DeleteAddress(userData);
                             tableView.ReloadData();
                             success(true);
                         });

            action.Image = UIImage.FromFile("delete.png");
            action.BackgroundColor = UIColor.White;

            return action;
        }

        private void DeleteAddress(UserData userData)
        {
            if (userData != null)
            {
                _listner.DeleteContact(userData);
                //var storyboard = UIStoryboard.FromName("Main", null);
                //var viewController = storyboard.InstantiateViewController("ListViewController") as ListViewController;

                //DatabaseService.DeleteItem(userData.ID);
                //viewController.ListViewCell();
            }
        }

        #endregion

        #region Public methods

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (UserDataCell)tableView.DequeueReusableCell("cell", indexPath);
            var data = indexedTableItems[keys[indexPath.Section]][indexPath.Row];
            cell.UpdateCell(data);
            cell.UserInteractionEnabled = true;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UserDetailViewController.UserData = indexedTableItems[keys[indexPath.Section]][indexPath.Row];
            OnAddButtonClick?.Invoke(null, new EventArgs());
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Count();
        }

        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return keys;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            System.Diagnostics.Debug.WriteLine($"section - {section}\n Title - {keys[section]}");
            return keys[section];
            //return keys.Length != 0 ? keys[section] : string.Empty;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return values[section].Count();
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            UIView view = new UIView();
            view.Frame = new CGRect(0, 40, tableView.Frame.Size.Width, 40);

            UILabel label = new UILabel();
            label.Frame = new CGRect(10, 10, tableView.Frame.Size.Width, 20);
            label.Text = keys[section];
            label.TextColor = UIColor.Black;
            var attributedString = new NSMutableAttributedString(keys[section]);
            var range = attributedString.MutableString.LocalizedStandardRangeOfString(new NSString(keys[section]));
            attributedString.AddAttribute(UIStringAttributeKey.Font, UIFont.BoldSystemFontOfSize(16), range);
            label.AttributedText = attributedString;

            var gradientLayer = new CAGradientLayer
            {
                Frame = view.Bounds,
                StartPoint = new CGPoint(0, 0.1),
                EndPoint = new CGPoint(1, 0),
                Colors = new CGColor[] { UIColor.FromRGBA(152, 227, 211, 255).CGColor, UIColor.FromRGBA(122, 160, 162, 255).CGColor }
            };
            view.Layer.InsertSublayer(gradientLayer, 0);
            view.Add(label);

            return view;
        }

        public override UISwipeActionsConfiguration GetTrailingSwipeActionsConfiguration(UITableView tableView, NSIndexPath indexPath)
        {
            var deleteAction = ContextualDeleteAction(indexedTableItems[keys[indexPath.Section]][indexPath.Row], tableView);
            var TrailingSwipe = UISwipeActionsConfiguration.FromActions(new UIContextualAction[] { deleteAction });
            TrailingSwipe.PerformsFirstActionWithFullSwipe = false;
            return TrailingSwipe;
        }
        #endregion
    }
}