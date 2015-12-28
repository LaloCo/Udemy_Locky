using System;
using Locky.Shared;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;

namespace Locky.iOS
{
    public partial class ViewController : UIViewController
    {
        bool hasLoggedIn = false;

        private MobileServiceUser user;
        public MobileServiceUser User
        {
            get{ return user; }
        }

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            signInButton.TouchUpInside += SignInButton_TouchUpInside;
        }

        async void SignInButton_TouchUpInside (object sender, EventArgs e)
        {
            try
            {
                user = await Passwords.client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                hasLoggedIn = true;
                this.PerformSegue("loggedInSegue", this);
            }
            catch (Exception)
            {
                UIAlertView alert = new UIAlertView()
                {
                    Message = "There was an error signing you in",
                    Title = "Error"
                };
                alert.AddButton("Ok");
                alert.Show();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override bool ShouldPerformSegue(string segueIdentifier, Foundation.NSObject sender)
        {
            if (segueIdentifier == "loggedInSegue")
            {
                return hasLoggedIn;
            }
            return true;
        }
    }
}

