using System;
using System.Collections.Generic;
using System.IO;
using DifferenzXamarinDemo.Models;
using SQLite;

namespace DifferenzXamarinDemo.Services
{
    #region Interface
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
    #endregion

    public class DatabaseService
    {
        #region Constructor
        public DatabaseService()
        {
        }
        #endregion

        #region Static Properties
        static SQLiteConnection _instance;
        static object locker = new object();
        #endregion

        #region Public
        public static SQLiteConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
                    _instance = new SQLiteConnection(dbPath);
                    _instance.CreateTable<UserData>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

		public static UserData GetItem(string EmailAddress)
        {
            lock (locker)
            {
                return DatabaseService.Instance.Table<UserData>().FirstOrDefault(x => x.EmailAddress == EmailAddress);
            }
        }

		public static List<UserData> GetAll()
        {
            lock (locker)
            {
                return DatabaseService.Instance.Table<UserData>().ToList();
            }
        }

		public static int SaveItem(UserData item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    DatabaseService.Instance.Update(item);
                    return item.ID;
                }
                else
                {
                    return DatabaseService.Instance.Insert(item);
                }
            }
        }

		public static int DeleteItem(int id)
        {
            lock (locker)
            {
                return DatabaseService.Instance.Delete<UserData>(id);
            }
        }
        #endregion
    }
}
