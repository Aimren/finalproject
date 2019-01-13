using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(mypro.Droid.SharPref))]
namespace mypro.Droid
{
    public class SharPref : ISharPref
    {
        public SharPref()
        {

        }

        public string getItem(string key)
        {

            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            string item = prefs.GetString(key, "N0_1t3m");
            return item;

        }

        public void setItem(string key, string item)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString(key, item);
            editor.Apply();
        }

        public int getIndex(string key)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            int item = prefs.GetInt(key, 0);
            return item;
        }

        public void setIndex(string key, int index)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt(key, index);
            editor.Apply();
        }
        
        public int getDersId(string key)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            int item = prefs.GetInt(key, 0);
            return item;
        }

        public void setDersId(string key, int id)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt(key, id);
            editor.Apply();
        }
        public string getElement(string key)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            string item = prefs.GetString(key, "");
            return item;
        }

        public void setElement(string key, string id)
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString(key, id);
            editor.Apply();
        }

        public void clearShar()
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.Clear();
            editor.Commit();
            editor.Apply();
        }
    }
}