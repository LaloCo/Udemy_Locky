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
    [Activity(Label = "PasswordsListActivity")]			
    public class PasswordsListActivity : Activity
    {
        Button addButton;
        ListView passwordsListView;
        List<Password> passwords;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Passwords);

            passwordsListView = FindViewById<ListView>(Resource.Id.passwordListView);
            passwordsListView.ItemClick += PasswordsListView_ItemClick;

            addButton = FindViewById<Button>(Resource.Id.addButton);
            addButton.Click += AddButton_Click;

            PopulateListView();
        }

        void PasswordsListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
        {
            if (e.Position != null)
            {
                var selectedItem = passwords[e.Position];
                var intent = new Android.Content.Intent(this, typeof(DetailActivity));

                Bundle bundle = new Bundle();
                bundle.PutString("password_name", selectedItem.Name);
                bundle.PutString("password_value", selectedItem.PasswordValue);

                intent.PutExtras(bundle);

                StartActivity(intent);
            }
        }

        async void PopulateListView()
        {
            passwords = await Passwords.readPasswords();

            List<string> passwordNames = new List<string>();

            foreach (var password in passwords)
            {
                passwordNames.Add(password.Name);
            }

            passwordsListView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, passwordNames);
        }

        void AddButton_Click (object sender, EventArgs e)
        {
            StartActivity(typeof(NewPasswordActivity));
        }
    }
}

