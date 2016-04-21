using System;

using Android.App;
using Android.OS;
using Android.Widget;
using DatabaseDemo.ORM;

namespace DatabaseDemo
{
    [Activity(Label = "RemoveTaskActivity")]
    public class RemoveTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RemoveTaskLayout);
            Button btnRemove = FindViewById<Button>(Resource.Id.btnDelete);
            btnRemove.Click += BtnRemove_Click;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtTaskID = FindViewById<EditText>(Resource.Id.txtTaskID);
            string result = dbr.RemoveTask(int.Parse(txtTaskID.Text));
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}