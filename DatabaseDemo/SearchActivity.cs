using System;

using Android.App;
using Android.OS;
using Android.Widget;
using DatabaseDemo.ORM;

namespace DatabaseDemo
{
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchLayout);
            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);

            string task = dbr.GetTaskByID(int.Parse(txtId.Text));

            Toast.MakeText(this, task, ToastLength.Short).Show();
        }
    }
}