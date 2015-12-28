using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Locky.Shared;

namespace Locky.iOS
{
	partial class NewPasswordViewController : UIViewController
	{
		public NewPasswordViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            saveButton.Clicked += SaveButton_Clicked;
        }

        async void SaveButton_Clicked (object sender, EventArgs e)
        {
            bool result = await Passwords.addPassword(new Password()
                {
                    Name = passwordNameTextField.Text,
                    PasswordValue = passwordTextField.Text
                });

            if (!result)
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Error",
                    Message = "There was an error inserting the item"
                };
                alert.AddButton("Ok");
                alert.Show();
            }
            else
            {
                UIAlertView alert = new UIAlertView()
                    {
                        Title = "Success",
                        Message = "Theitem was successfully inserted"
                    };
                alert.AddButton("Great!");
                alert.Show();

                NavigationController.PopViewController(true);
            }
        }
	}
}
