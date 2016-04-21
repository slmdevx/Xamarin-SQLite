using System;
using DatabaseDemo.ORM;
using Android.App;
using Android.OS;
using Android.Widget;


namespace DatabaseDemo
{
    [Activity(Label = "InsertTaskActivity")]
    public class InsertTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.InsertTaskLayout);

            Button btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EditText txtText = FindViewById<EditText>(Resource.Id.txtText);
            DBRepository dbr = new DBRepository();
            string result = dbr.InsertRecord(txtText.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}