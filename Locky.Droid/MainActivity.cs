using Android.App;
using Android.Widget;
using Android.OS;
using Locky.Shared;
using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Locky.Droid
{
    [Activity(Label = "Locky.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        Button signInButton;

        private MobileServiceUser user;
        public MobileServiceUser User
        {
            get{ return user; }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            signInButton = FindViewById<Button>(Resource.Id.loginButton);

            signInButton.Click += SignInButton_Click;
        }

        async void SignInButton_Click (object sender, System.EventArgs e)
        {
            try
            {
                user = await Passwords.client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                StartActivity(typeof(PasswordsListActivity));
            }
            catch (Exception)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder (this);

                alert.SetTitle ("Error");
                alert.SetMessage("There was an error logging you in");

                alert.SetPositiveButton ("Ok", (senderAlert, args) => {
                } );
                RunOnUiThread (() => {
                    alert.Show();
                } );
            }
        }
    }
}


