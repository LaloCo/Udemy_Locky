using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Locky.Shared;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Locky.Droid
{
    [Activity(Label = "NewPasswordActivity")]			
    public class NewPasswordActivity : Activity
    {
        EditText nameEditText, passwordEditText;
        Button saveButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.NewPassword);

            nameEditText = FindViewById<EditText>(Resource.Id.passwordNameEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            saveButton = FindViewById<Button>(Resource.Id.saveButton);

            saveButton.Click += SaveButton_Click;
        }

        async void SaveButton_Click (object sender, EventArgs e)
        {
            bool result = await Passwords.addPassword(new Password()
                {
                    Name = nameEditText.Text,
                    PasswordValue = passwordEditText.Text
                });

            if (!result)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);

                alert.SetTitle("Error");
                alert.SetMessage("There was an error inserting the item");

                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                    {
                    });
                RunOnUiThread(() =>
                    {
                        alert.Show();
                    });
            }
            else
            {
                AlertDialog.Builder alert = new AlertDialog.Builder (this);

                alert.SetTitle ("Success");
                alert.SetMessage("The item was succesfully inserted");

                alert.SetPositiveButton ("Great", (senderAlert, args) => {
                } );
                RunOnUiThread (() => {
                    alert.Show();
                } );

                StartActivity(typeof(PasswordsListActivity));
            }
        }
    }
}

