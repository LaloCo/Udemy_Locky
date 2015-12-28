using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Locky.iOS
{
	partial class DetailsViewController : UIViewController
	{
        public string password;
		public DetailsViewController (IntPtr handle) : base (handle)
		{
            
		}

        public override void ViewDidAppear(bool animated)
        {
            passwordLabel.Text = password;
        }
	}
}
