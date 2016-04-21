using System;
using Android.App;
using Android.Widget;
using Android.OS;
using DatabaseDemo.ORM;

namespace DatabaseDemo
{
    [Activity(Label = "DatabaseDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "Home" layout resource
            SetContentView(Resource.Layout.Home);

            // Create the Database...
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            btnCreateDB.Click += BtnCreateDB_Click;

            // Create the Table...
            Button btnCreateTable = FindViewById<Button>(Resource.Id.btnCreateTable);
            btnCreateTable.Click += BtnCreateTable_Click;

            // To Insert the Record...
            Button btnAddRecord = FindViewById<Button>(Resource.Id.btnInsert);
            btnAddRecord.Click += BtnAddRecord_Click;

            // To Retrieve the Data...
            Button btnGetAll = FindViewById<Button>(Resource.Id.btnGetData);
            btnGetAll.Click += BtnGetAll_Click;

            // To Retrieve Specific Record...
            Button btnGetById = FindViewById<Button>(Resource.Id.btnGetDataByID);
            btnGetById.Click += BtnGetById_Click;

            //To Update Record...

            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += BtnUpdate_Click;

            //To Delete Record...
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RemoveTaskActivity));
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UpdateTaskActivity));
        }

        private void BtnGetById_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SearchActivity));
        }

        private void BtnGetAll_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.GetAllRecords();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void BtnAddRecord_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InsertTaskActivity));
        }

        private void BtnCreateTable_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void BtnCreateDB_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();
            Toast.MakeText(this,result,ToastLength.Short).Show();
        }

    }
}

