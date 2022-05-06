using ApplyGeek.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApplyGeek
{
    public partial class App : Application
    {
        static SQLiteHelper db;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "applygeekdb.db3"));
                }
                return db; 
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
