
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

namespace Locky.Droid
{
    [Activity(Label = "DetailActivity")]			
    public class DetailActivity : Activity
    {
        TextView passwordTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Detail);

            passwordTextView = FindViewById<TextView>(Resource.Id.passwordTextView);
            passwordTextView.Text = Intent.Extras.GetString("password_value");
        }
    }
}

