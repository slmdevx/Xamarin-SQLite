using System;

using Android.App;
using Android.OS;
using Android.Widget;
using DatabaseDemo.ORM;

namespace DatabaseDemo
{
    [Activity(Label = "UpdateTaskActivity")]
    public class UpdateTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UpdateTaskLayout);

            //Search (Button_Click)
            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += BtnSearch_Click;

            //Update (Button_Click)
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            DBRepository dbr = new DBRepository();
            string result = dbr.UpdateRecord(int.Parse(txtId.Text), txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            txtTask.Text = dbr.GetTaskByID(int.Parse(txtId.Text));
        }
    }
}