using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using static Android.App.Application;

namespace WeatherApp.Droid
{
    public class MainApplication : Application, IActivityLifecycleCallbacks
    {
        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityPaused(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityResumed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStarted(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStopped(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}