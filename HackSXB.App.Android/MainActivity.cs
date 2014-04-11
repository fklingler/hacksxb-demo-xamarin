using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HackSXB.Core;
using System.Collections.Generic;

namespace HackSXB.App.Android
{
	[Activity(Label = "HackSXB.App.Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
        ArrayAdapter ListAdapter;

		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ListAdapter = new ArrayAdapter<Question>(this, Resource.Layout.MainListItem);

            ListView listView = FindViewById<ListView>(Resource.Id.listView);
            listView.Adapter = ListAdapter;

            Question.FindXamarinQuestions(delegate(List<Question> questions)
            {
                if (questions != null)
                {
                    RunOnUiThread(() =>
                    {
                        ListAdapter.Clear();
                        ListAdapter.AddAll(questions);
                        ListAdapter.NotifyDataSetChanged();
                    });
                }
            });
        }
	}
}


