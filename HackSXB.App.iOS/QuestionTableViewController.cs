using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HackSXB.Core;
using System.Collections.Generic;

namespace HackSXB.App.iOS
{
    public class QuestionTableViewController : UITableViewController
    {
        public QuestionTableViewController() : base(UITableViewStyle.Grouped)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Register the TableView's data source
            TableView.Source = new QuestionTableViewSource();

            Question.FindXamarinQuestions(delegate(List<Question> questions)
            {
                if (questions != null)
                {
                    InvokeOnMainThread(() =>
                    {
                        ((QuestionTableViewSource)TableView.Source).Questions = questions;

                        TableView.ReloadData();
                    });
                }
            });
        }
    }
}

